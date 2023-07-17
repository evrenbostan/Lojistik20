using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lojistik20
{
    class YolGuzergahBilgisiGetir
    {
        public static string hata;
        public static IWebDriver driver;
        public static ChromeDriverService service = ChromeDriverService.CreateDefaultService();

        public static IWebElement WaitToLoadCssSelector(IWebElement x, string strCssSelector)
        {
            int i = 0;
            while (i < 3)
            {
                i++;
                Thread.Sleep(100); // sleep 100 ms
                try
                {
                    IWebElement ret = x.FindElement(By.CssSelector(strCssSelector));
                    if (ret != null)
                    {
                        return ret;
                    }
                }
                catch { }
            }
            return null;
        }


        public static bool RotaBilgileri(string dosyaYolu, int durakSayisi ,string yolKartAracRota)
        {
            try
            {
                service.HideCommandPromptWindow = true;
                driver = new ChromeDriver(service);
                driver.Manage().Window.Minimize();
                driver.Manage().Window.Position = new Point(-3000, -3000);

                IJavaScriptExecutor jsExec = (IJavaScriptExecutor)driver;
                driver.Url = "file:///" + dosyaYolu;
               
                
                IWebElement directionsPanel = driver.FindElement(By.CssSelector("div.directionsPanel"));

                if (directionsPanel == null)
                {
                    hata = "Bilgilere Erişilemedi. Hata yeri >>> directionsPanel";
                    return false;
                }

                IList<IWebElement> div = directionsPanel.FindElements(By.CssSelector("div>table>tr>td"));

                if (div == null)
                {
                    hata = "Bilgilere Erişilemedi. Hata yeri >>> div";
                    return false;
                }

                string sonAciklama = "";
                string sonKm = "";

                
                foreach (IWebElement item in div)
                {
                    if (!String.IsNullOrWhiteSpace(item.Text))
                    {

                        item.Click();

                        IWebElement x = item.FindElement(By.XPath("//li[@class='drTitle selected']"));

                        IWebElement saat = WaitToLoadCssSelector(x, ".drHours"); //x.FindElement(By.CssSelector(".drHours"));
                        IWebElement dakika = WaitToLoadCssSelector(x, ".drMins"); //x.FindElement(By.CssSelector(".drMins"));
                        IWebElement trafikDurumu = WaitToLoadCssSelector(x, ".traffic.light"); // x.FindElement(By.CssSelector(".traffic.light"));
                        IWebElement aciklama = WaitToLoadCssSelector(x, ".drTitleText");// x.FindElement(By.CssSelector(".drTitleText"));
                        IWebElement ucretDurumu = WaitToLoadCssSelector(x, ".drEmbellishRed"); //x.FindElement(By.CssSelector(".drEmbellishRed"));
                        IWebElement km = WaitToLoadCssSelector(x, ".drTitleRight"); //x.FindElement(By.CssSelector(".drTitleRight"));
                        

                        //if (sonAciklama != aciklama.Text && sonKm != km.Text)
                        if (sonKm != km.Text)
                        {
                            string rotaID = Guid.NewGuid().ToString().ToUpper();

                            int saatBilgisi = 0;
                            int dakikaBilgisi = 0;
                            string trafikDurumBilgisi = "";
                            string aciklamaBilgisi = "";
                            string ucretDurumBilgisi = "";
                            decimal kmBilgisi = 0;

                            if (saat != null)
                            {
                                if (!String.IsNullOrWhiteSpace(saat.Text))
                                {
                                    saatBilgisi = Convert.ToInt32(saat.Text);
                                }
                            }

                            if (dakika != null)
                            {
                                if (!String.IsNullOrWhiteSpace(dakika.Text))
                                {
                                    dakikaBilgisi = Convert.ToInt32(dakika.Text);
                                }
                            }

                            if (trafikDurumu != null)
                            {
                                trafikDurumBilgisi = trafikDurumu.Text;
                            }

                            if (aciklama != null)
                            {
                                aciklamaBilgisi = aciklama.Text;
                            }

                            if (ucretDurumu != null)
                            {
                                ucretDurumBilgisi = ucretDurumu.Text;
                            }

                            if (km != null)
                            {
                                if (!String.IsNullOrWhiteSpace(km.Text))
                                {
                                    kmBilgisi = Convert.ToDecimal(km.Text.Replace("km", "").Trim());
                                }
                            }


                            bool ret = Lojistik.YolKartAracRotaSecimleriEkle(rotaID, yolKartAracRota, durakSayisi, saatBilgisi, dakikaBilgisi, trafikDurumBilgisi, aciklamaBilgisi, ucretDurumBilgisi, kmBilgisi);
                            if (!ret)
                            {
                                hata = Lojistik.hata;
                                return false;
                            }

                            IWebElement yolTarifiBul = driver.FindElement(By.CssSelector("div.directionsPanel"));

                            IWebElement yolTarif = yolTarifiBul.FindElement(By.XPath("//div[@data-tag='dirInstructions']"));

                            string[] tarif = yolTarif.Text.Split('\r');

                            int siraNo = 0;

                            foreach (var tarifSatiri in tarif)
                            {
                                siraNo++;

                                bool ret2 = Lojistik.YolKartAracRotaSecimTarifiEkle(rotaID, siraNo, tarifSatiri.Replace(" km", " km devam edin").Replace(" m", " metre devam edin").Replace(" yol yoluna ", " "));
                                if (!ret2)
                                {
                                    hata = Lojistik.hata;
                                    return false;
                                }
                            }

                        }
                        
                        sonAciklama = aciklama.Text;
                        sonKm = km.Text;
                    }
                }


            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                driver.Dispose();
            }
            return true;
        }
    }
}
