using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Lojistik20
{
    class Lojistik
    {
       
        public static string sirketTamAdi = "DTS LOJİSTİK";
        public static string sirketKisaAd = "DTS";
        public static string sirketSunucu = "185.122.201.4";
        public static string sirketDatabase = "DTSLOG";
        public static string sirketDbOwnerUser = "SA";
        public static string sirketDbPassword = "Evren2779+";

        public static SqlConnection con = new SqlConnection("Server="+ sirketSunucu +";Database="+ sirketDatabase +";User Id="+ sirketDbOwnerUser +";Password="+ sirketDbPassword + ";");


        public static string hata;
        
        public static DataTable dt = new DataTable();
        
        public static bool IsEmirleri(string islemTipi, string id, string basKey, string aciklama)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_IS_EMRI_ISLEMLERI", con);
                cmd.Parameters.AddWithValue("@ISLEM_TIPI", islemTipi);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@BAS_KEY", basKey);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                
                if (dt.Rows.Count>0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool IsEmriListesi()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_IS_EMIRLERI", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool IsEmrineBagliYolKartlar(string isEmriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART", con);
                cmd.Parameters.AddWithValue("@IS_EMIR", isEmriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartEkle(string isEmirID, string aciklama)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART", con);
                cmd.Parameters.AddWithValue("@IS_EMIR", isEmirID);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriEkle(string yolKartID, string cariID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_MUSTERI", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.Parameters.AddWithValue("@CARI", cariID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriListesi(string yolKartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_MUSTERI", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriSil(string yolKartMusteriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_MUSTERI", con);
                cmd.Parameters.AddWithValue("@ID", yolKartMusteriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriyeIsTanimla(string yolKartID, string cariID, string isTanimID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_MUSTERI_IS", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.Parameters.AddWithValue("@CARI", cariID);
                cmd.Parameters.AddWithValue("@IS_TANIMI", isTanimID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriAtananIsler(string yolKartMusteriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ISLER", con);
                cmd.Parameters.AddWithValue("@YOL_KART_MUSTERI", yolKartMusteriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriyeTanimliIsSil(string yolKartID, string cariID, string isTanimID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_MUSTERI_IS", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.Parameters.AddWithValue("@CARI", cariID);
                cmd.Parameters.AddWithValue("@IS_TANIMI", isTanimID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public static bool YolKartMusteriNotGuncelle(string yolKartMusteriID, string aciklama)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATE_YOL_KART_MUSTERI_NOT", con);
                cmd.Parameters.AddWithValue("@ID", yolKartMusteriID);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriyeDosyaEkle(string yolKartMusteriID)
        {
            try
            {
                string dosyaAdi = "";
                string dosyaTipi = "";
                decimal dosyaBoyutu = 0;
                string dosyaYolu = "";
                byte[] dosyaIcerik = null;

                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.ShowDialog();

                if (!String.IsNullOrEmpty(FileDialog.FileName))
                {
                    FileInfo ff = new FileInfo(FileDialog.FileName);
                    dosyaAdi = ff.Name;
                    dosyaTipi = ff.Extension;
                    dosyaBoyutu = ff.Length;
                    dosyaYolu = FileDialog.FileName;
                    dosyaIcerik = File.ReadAllBytes(dosyaYolu);
                }
                else
                {
                    hata = "Hatasız";
                    return false;
                }

                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_MUSTERI_DOSYA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_MUSTERI", yolKartMusteriID);
                cmd.Parameters.AddWithValue("@DOSYA_ADI", dosyaAdi);
                cmd.Parameters.AddWithValue("@DOSYA_TIPI", dosyaTipi);
                cmd.Parameters.AddWithValue("@DOSYA_BOYUTU", dosyaBoyutu);
                cmd.Parameters.AddWithValue("@DOSYA_ICERIK", dosyaIcerik);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public static bool YolKartMusteriDosyalar(string yolKartMusteriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_MUSTERI_DOSYA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_MUSTERI", yolKartMusteriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriDosyaIcerik(string dosyaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_MUSTERI_DOSYA_ICERIK", con);
                cmd.Parameters.AddWithValue("@ID", dosyaID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartMusteriDosyaSil(string musteriDosyaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_MUSTERI_DOSYA", con);
                cmd.Parameters.AddWithValue("@ID", musteriDosyaID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracEkle(string yolKartID, string aracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.Parameters.AddWithValue("@ARAC", aracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaEkle(string yolKartAracID, string ulke, string sehir, string ilce, string bolge, string cadSokKapi, string postaKodu, string lokasyonTanimi, decimal lat, decimal longa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_ROTA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.Parameters.AddWithValue("@ULKE", ulke);
                cmd.Parameters.AddWithValue("@SEHIR", sehir);
                cmd.Parameters.AddWithValue("@ILCE", ilce);
                cmd.Parameters.AddWithValue("@BOLGE", bolge);
                cmd.Parameters.AddWithValue("@CAD_SOK_KAPI", cadSokKapi);
                cmd.Parameters.AddWithValue("@POSTA_KODU", postaKodu);
                cmd.Parameters.AddWithValue("@LOKASYON_TANIMI", lokasyonTanimi);
                cmd.Parameters.AddWithValue("@LAT", lat);
                cmd.Parameters.AddWithValue("@LONG", longa);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSirasiniDegistir(string yolKartAracRotaID, string yolKartAracID, int siraNo, string siraYonu)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATE_YOL_KART_ROTA_SIRA_DEGISTIR", con);
                cmd.Parameters.AddWithValue("@ID", yolKartAracRotaID);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.Parameters.AddWithValue("@SIRA_NO", siraNo);
                cmd.Parameters.AddWithValue("@SIRA_YON", siraYonu);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracListesi(string yolKartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracSil(string yolKartMusteriID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC", con);
                cmd.Parameters.AddWithValue("@ID", yolKartMusteriID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public static bool YolKartAracRotaSil(string yolKartAracRotaID, string yolKartAracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC_ROTA", con);
                cmd.Parameters.AddWithValue("@ID", yolKartAracRotaID);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool LokasyonVeritabaniKayitlari(decimal lat, decimal longa)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_LOKASYON_KAYITLARI", con);
                cmd.Parameters.AddWithValue("@LAT", lat);
                cmd.Parameters.AddWithValue("@LONG", longa);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool AracSonLokasyonBilgisi(string aracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[SP_SELECT_ARAC_SON_LOKASYON_BILGISI]", con);
                cmd.Parameters.AddWithValue("@ARAC_ID", aracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool AracRotaLokasyonBilgisi(string yolKartAracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("[SP_SELECT_ARAC_ROTA_LOKASYON_BILGISI]", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ID", yolKartAracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaHTMLDosyaYukle(string yolKartAracID, int noktaSayisi, string kartBaslik, string aracPlaka, string dosyaYolu)
        {
            try
            {
                string dosyaAdi = "";
                string dosyaTipi = "";
                decimal dosyaBoyutu = 0;
                byte[] dosyaIcerik = null;

                dosyaYolu = "" + kartBaslik + " - " + aracPlaka + ".html";

                FileInfo ff = new FileInfo(dosyaYolu);
                dosyaAdi = ff.Name;
                dosyaTipi = ff.Extension;
                dosyaBoyutu = ff.Length;
                dosyaIcerik = File.ReadAllBytes(dosyaYolu);

                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_ROTA_HTML", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.Parameters.AddWithValue("@NOKTA_SAYISI", noktaSayisi);
                cmd.Parameters.AddWithValue("@DOSYA_ADI", dosyaAdi);
                cmd.Parameters.AddWithValue("@DOSYA_TIPI", dosyaTipi);
                cmd.Parameters.AddWithValue("@DOSYA_BOYUTU", dosyaBoyutu);
                cmd.Parameters.AddWithValue("@DOSYA_ICERIK", dosyaIcerik);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaHTMLDosyaIcerik(string dosyaAdi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC_ROTA_HTML_ICERIK", con);
                cmd.Parameters.AddWithValue("@DOSYA_ADI",dosyaAdi);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimleriEkle(string ID, string yolKartAracRota, int durakSayisi, int saat, int dakika, string trafikDurumu, string aciklama, string ucretDurumu, decimal km)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_ROTA_SECIM", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA", yolKartAracRota);
                cmd.Parameters.AddWithValue("@DURAK_SAYISI", durakSayisi);
                cmd.Parameters.AddWithValue("@SAAT", saat);
                cmd.Parameters.AddWithValue("@DAKIKA", dakika);
                cmd.Parameters.AddWithValue("@TRAFIK_DURUMU", trafikDurumu);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.Parameters.AddWithValue("@UCRET_DURUMU", ucretDurumu);
                cmd.Parameters.AddWithValue("@KM", km);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimTarifiEkle(string yolKartAracRotaSecimID, int siraNo, string tarif)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_ROTA_SECIM_TARIF", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA_SECIM", yolKartAracRotaSecimID);
                cmd.Parameters.AddWithValue("@SIRA_NO", siraNo);
                cmd.Parameters.AddWithValue("@TARIF", tarif);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimleriGetir(string yolKartAracRota)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC_ROTA_SECIM", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA", yolKartAracRota);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimTarifGetir(string yolKartAracRotaSecim)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC_ROTA_SECIM_TARIF", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA_SECIM", yolKartAracRotaSecim);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimOnayla(string yolKartAracRotaSecimID, DateTime? tahminiKalkis, DateTime? tahminiVaris, decimal? topMesafe, decimal? cikisKm, decimal? varisKm, string onayTuru)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATE_YOL_KART_ARAC_ROTA_SECIM_ONAY", con);
                cmd.Parameters.AddWithValue("@ID", yolKartAracRotaSecimID);
                cmd.Parameters.AddWithValue("@TAHMINI_KALKIS", tahminiKalkis);
                cmd.Parameters.AddWithValue("@TAHMINI_VARIS", tahminiVaris);
                cmd.Parameters.AddWithValue("@TOP_MESAFE", topMesafe);
                cmd.Parameters.AddWithValue("@CIKIS_KM", cikisKm);
                cmd.Parameters.AddWithValue("@VARIS_KM", varisKm);
                cmd.Parameters.AddWithValue("@ONAY", onayTuru);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimOnaySorgula(string yolKartAracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ROTA_SECIM_ONAY_SORGULA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ID", yolKartAracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaHTMLSil(string yolKartAracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC_ROTA_HTML", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaTarifleriSil(string yolKartAracRotaSecimID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC_ROTA_SECIM_TARIF", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA_SECIM", yolKartAracRotaSecimID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracRotaSecimleriSil(string yolKartAracRotaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC_ROTA_SECIM", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA", yolKartAracRotaID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool HtmlRotaOlustur(string kartBaslik, string AracPlaka, DataTable dtNoktalar, out string HTML)
        {
            HTML = "";
            HTML += "<!DOCTYPE html>\r";
            HTML += "<html>\r";
            HTML += "    <head>\r";
            HTML += "        <title>" + kartBaslik + "'nın " + AracPlaka + " Plakalı Aracı</title>\r";
            HTML += "        <meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>\r";
            HTML += "    </head>\r";
            HTML += "    <body>\r";
            HTML += "        <div id='printoutPanel'></div>\r";
            HTML += "\r";
            HTML += "        <div id='myMap' style='width: 100vw; height: 100vh;'></div>\r";
            HTML += "        <script type='text/javascript'>\r";
            HTML += "            function loadMapScenario() {\r";
            HTML += "                var map = new Microsoft.Maps.Map(document.getElementById('myMap'));\r";
            HTML += "                Microsoft.Maps.loadModule('Microsoft.Maps.Directions', function () {\r";
            HTML += "                    var directionsManager = new Microsoft.Maps.Directions.DirectionsManager(map);\r";
            HTML += "                    directionsManager.setRequestOptions({ routeMode: Microsoft.Maps.Directions.RouteMode.driving });\r";
            foreach (DataRow dr in dtNoktalar.Rows)
            {
                HTML += "                    var waypoint" + dr["SIRA_NO"] + " = new Microsoft.Maps.Directions.Waypoint({ address: '" + dr["LOKASYON_TANIMI"] + "', location: new Microsoft.Maps.Location(" + dr["LAT"].ToString().Replace(",", ".") + "," + dr["LONG"].ToString().Replace(",", ".") + ") });\r";
            }

            foreach (DataRow dr in dtNoktalar.Rows)
            {
                HTML += "                    directionsManager.addWaypoint(waypoint" + dr["SIRA_NO"] + ");\r";
            }

            HTML += "                    directionsManager.setRenderOptions({ itineraryContainer: document.getElementById('printoutPanel') });\r";
            HTML += "                    directionsManager.calculateDirections();\r";
            HTML += "                });\r";
            HTML += "            }\r";
            HTML += "        </script><script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?key=rDIKiU2MZa3nbVtSlne1~tBrRq3VBw8f8VRTT0Ub91g~AkOOS2A90FQUz33XYqpGUcxutL5uGTAs0eyvCJF8OZSaAB00VcbglCph5DfLp3d_&callback=loadMapScenario' async defer></script></body></html>";

            return true;
        }

        public static bool YolKartAracNotGuncelle(string yolKartAracID, string aciklama)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATE_YOL_KART_ARAC_NOT", con);
                cmd.Parameters.AddWithValue("@ID", yolKartAracID);
                cmd.Parameters.AddWithValue("@ACIKLAMA", aciklama);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracaDosyaEkle(string yolKartAracID)
        {
            try
            {
                string dosyaAdi = "";
                string dosyaTipi = "";
                decimal dosyaBoyutu = 0;
                string dosyaYolu = "";
                byte[] dosyaIcerik = null;

                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.ShowDialog();

                if (!String.IsNullOrEmpty(FileDialog.FileName))
                {
                    FileInfo ff = new FileInfo(FileDialog.FileName);
                    dosyaAdi = ff.Name;
                    dosyaTipi = ff.Extension;
                    dosyaBoyutu = ff.Length;
                    dosyaYolu = FileDialog.FileName;
                    dosyaIcerik = File.ReadAllBytes(dosyaYolu);
                }
                else
                {
                    hata = "Hatasız";
                    return false;
                }

                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_DOSYA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.Parameters.AddWithValue("@DOSYA_ADI", dosyaAdi);
                cmd.Parameters.AddWithValue("@DOSYA_TIPI", dosyaTipi);
                cmd.Parameters.AddWithValue("@DOSYA_BOYUTU", dosyaBoyutu);
                cmd.Parameters.AddWithValue("@DOSYA_ICERIK", dosyaIcerik);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracDosyalar(string yolKartAracID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC_DOSYA", con);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracDosyaIcerik(string dosyaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_ARAC_DOSYA_ICERIK", con);
                cmd.Parameters.AddWithValue("@ID", dosyaID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracDosyaSil(string aracDosyaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_ARAC_DOSYA", con);
                cmd.Parameters.AddWithValue("@ID", aracDosyaID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartSurucuListesi(string yolKartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_SURUCU", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartSurucuEkle(string yolKartID, string surucuID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_SURUCU", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.Parameters.AddWithValue("@SURUCU", surucuID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartSurucuyuSil(string yolKartSurucuID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_DELETE_YOL_KART_SURUCU", con);
                cmd.Parameters.AddWithValue("@ID", yolKartSurucuID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartSurucuyeAracSorgula(string yolKartID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_SURUCU_ARAC_SORGULA", con);
                cmd.Parameters.AddWithValue("@YOL_KART", yolKartID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartSurucuSeyirDefteri(string yolKartSurucuID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_YOL_KART_SURUCU_SEYIR_DEFTERI", con);
                cmd.Parameters.AddWithValue("@YOL_KART_SURUCU", yolKartSurucuID);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool YolKartAracSurucusuEkle(string yolKartSurucuID, string yolKartAracID, string yolKartAracRotaSecimID, decimal kontakKapanisKM, DateTime? kontakKapanisZamani, string kontakKapatilanLokasyon)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT_YOL_KART_ARAC_SURUCULERI", con);
                cmd.Parameters.AddWithValue("@YOL_KART_SURUCU", yolKartSurucuID);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC", yolKartAracID);
                cmd.Parameters.AddWithValue("@YOL_KART_ARAC_ROTA_SECIM", yolKartAracRotaSecimID);
                cmd.Parameters.AddWithValue("@KONTAK_KAPANIS_KM", kontakKapanisKM);
                cmd.Parameters.AddWithValue("@KONTAK_KAPANIS_ZAMANI", kontakKapanisZamani);
                cmd.Parameters.AddWithValue("@KONTAK_KAPATILAN_LOKASYON", kontakKapatilanLokasyon);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool ParametrikListeler(string islemTipi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_PARAMETRIK_LISTELER", con);
                cmd.Parameters.AddWithValue("@ISLEM_TIPI", islemTipi);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool VersiyonGetir()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SELECT_VERSIYON", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                if (dt.Rows.Count > 0 && dt.Columns[0].ToString() == "HATA_NO")
                {
                    hata = dt.Rows[0].ItemArray[1].ToString();
                    return false;
                }

                cmd.Parameters.Clear();
                return true;

            }
            catch (Exception ex)
            {
                hata = "AŞAĞIDAKİ TEKNİK HATAYI EKRAN ALINTISI YAPARAK YA DA DOĞRUDAN;\n05426170056 NUMARALI TELEFONA;\nevrenbostan@gmail.com MAİL ADRESİNE;\nLÜTFEN BİLDİRİNİZ\n\n" + ex.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

       

    }
}
