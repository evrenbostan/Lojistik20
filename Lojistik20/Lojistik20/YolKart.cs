using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Lojistik20
{
    public partial class YolKart : Form
    {
        private string bingMapKey = "AoM7fmDEfxf_wPry0qqrtxRI5PdB8v7f9y6rEv8lnhL0QMnlP7Vx8QJcIoeToQDl";

        private DataSet dsLokasyonBilgisi = null;

        private string yolKartAracID = "";
        private string yolKartAracRotaID = "";
        private string aracPlaka = "";
        private string aracSonUlke = "";
        private string aracSonSehir = "";
        private string aracSonIlce = "";
        private string aracSonBolge = "";
        private string aracSonCadSokKapi = "";
        private string aracSonPostaKodu = "";
        private string aracSonLokasyonTanimi = "";
        private string aracSonLat = "";
        private string aracSonLong = "";
        private string yolKartRotaSecimID = "";
        private DateTime aracSonVarisZamani = new DateTime();
        private int yolSaat =0;
        private int yolDakika = 0;


        XmlReader xmlLokasyon;

        bool ret;
        string yolKartID;

        Label lblRotaSecimYapmaUyarisi = new Label();

        public YolKart(string tabSecenek, string kartID, string kartBaslik)
        {
            InitializeComponent();
            
            yolKartID = kartID;

            this.Text = kartBaslik;

            switch (tabSecenek)
            {
                case "MÜŞTERİ":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabMusteri"];
                    tabMusteriLoad();

                    /*tabYolKart.TabPages.Remove(tabArac);
                    tabYolKart.TabPages.Remove(tabSurucu);
                    tabYolKart.TabPages.Remove(tabYuk);
                    tabYolKart.TabPages.Remove(tabFinans);*/

                    break;
                case "ARAÇ":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabArac"];
                    tabAracLoad();

                    /*tabYolKart.TabPages.Remove(tabMusteri);
                    tabYolKart.TabPages.Remove(tabSurucu);
                    tabYolKart.TabPages.Remove(tabYuk);
                    tabYolKart.TabPages.Remove(tabFinans);*/

                    break;
                case "SÜRÜCÜ":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabSurucu"];
                    tabSurucuLoad();

                    /*tabYolKart.TabPages.Remove(tabMusteri);
                    tabYolKart.TabPages.Remove(tabArac);
                    tabYolKart.TabPages.Remove(tabYuk);
                    tabYolKart.TabPages.Remove(tabFinans);*/

                    break;
                case "YÜK":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabYuk"];

                    /*tabYolKart.TabPages.Remove(tabMusteri);
                    tabYolKart.TabPages.Remove(tabArac);
                    tabYolKart.TabPages.Remove(tabSurucu);
                    tabYolKart.TabPages.Remove(tabFinans);*/

                    break;
                case "FİNANS":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabFinans"];

                    /*tabYolKart.TabPages.Remove(tabMusteri);
                    tabYolKart.TabPages.Remove(tabArac);
                    tabYolKart.TabPages.Remove(tabSurucu);
                    tabYolKart.TabPages.Remove(tabYuk);*/

                    break;
                case "ROTA":
                    tabYolKart.SelectedTab = tabYolKart.TabPages["tabRota"];

                    /*tabYolKart.TabPages.Remove(tabMusteri);
                    tabYolKart.TabPages.Remove(tabArac);
                    tabYolKart.TabPages.Remove(tabSurucu);
                    tabYolKart.TabPages.Remove(tabYuk);
                    tabYolKart.TabPages.Remove(tabFinans);*/

                    break;
            }

        }

        private void tabYolKart_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabYolKart.SelectedTab.Name)
            {
                case "tabMusteri":
                    tabMusteriLoad();
                    break;
                case "tabArac":
                    tabAracLoad();
                    break;
                case "tabSurucu":
                    tabSurucuLoad();
                    break;
                case "tabYuk":
                    break;
                case "tabFinans":
                    break;
                case "tabRota":
                    break;
            }
        }

        #region Müşteriler
        private void tabMusteriLoad()
        {
            grdMusterilerLoad(yolKartID);
            grdIsTanimlariLoad();
        }

        private void grdMusterilerLoad(string yolKartID)
        {
            LojistikDesign.DataGrid(grdMusteriler);

            ret = Lojistik.YolKartMusteriListesi(yolKartID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdMusteriler.DataSource = Lojistik.dt;

                DataGridViewButtonColumn btnMusteriKaldir = new DataGridViewButtonColumn();
                btnMusteriKaldir.Name = "";
                btnMusteriKaldir.Text = "MÜŞTERİYİ ÇIKAR";
                btnMusteriKaldir.UseColumnTextForButtonValue = true;
                btnMusteriKaldir.FillWeight = 25;
                btnMusteriKaldir.DisplayIndex = 4;
                btnMusteriKaldir.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnMusteriKaldir.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnMusteriKaldir.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdMusteriler.Columns["ID"].Visible = false;
                grdMusteriler.Columns["CARI_ID"].Visible = false;
                grdMusteriler.Columns["ACIKLAMA"].Visible = false;

                grdMusteriler.Columns["CARI_UNVAN"].HeaderText = "YOL KARTNA DAHİL EDİLEN MÜŞTERİLER";
                grdMusteriler.Columns["CARI_UNVAN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdMusteriler.Columns["CARI_UNVAN"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdMusteriler.Columns["CARI_UNVAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdMusteriler.Columns.Add(btnMusteriKaldir);

                grdMusteriler.ClearSelection();
            }
        }

        private void grdMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && grdMusteriler.CurrentCell.FormattedValue.ToString() == "MÜŞTERİYİ ÇIKAR")
            {
                string yolKartMusteriID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartMusteriSil(yolKartMusteriID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabMusteriLoad();
                    lblMusteriBilgi.Text = "";
                    txtMusteriNot.Visible = false;
                }
            }
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            SecimMusteriEkle();
        }

        private void SecimMusteriEkle()
        {
            SecimParametre ac = new SecimParametre("CARI_LISTESI", "CARİ LİSTESİ");
            ac.ShowDialog();


            if (!String.IsNullOrWhiteSpace(SecimParametre.secimID) && SecimParametre.secim == "OK")
            {
                ret = Lojistik.YolKartMusteriEkle(yolKartID, SecimParametre.secimID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ret = Lojistik.YolKartMusteriListesi(yolKartID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        grdMusterilerLoad(yolKartID);

                        for (int i = 0; i < grdMusteriler.Rows.Count; i++)
                        {
                            if (SecimParametre.secimID == grdMusteriler.Rows[i].Cells["CARI_ID"].Value.ToString())
                            {
                                grdMusteriler.Rows[i].Cells[0].Selected = true;
                            }
                        }

                    }
                }
            }
        }

        private void grdMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            grdIsTanimlariLoad();

            if (grdMusteriler.SelectedRows.Count > 0)
            {
                txtMusteriNot.Visible = true;
                string yolKartMusteriID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();
                lblMusteriBilgi.Text = grdMusteriler.SelectedRows[0].Cells["CARI_UNVAN"].Value.ToString();
                txtMusteriNot.Text = grdMusteriler.SelectedRows[0].Cells["ACIKLAMA"].Value.ToString();

                ret = Lojistik.YolKartMusteriAtananIsler(yolKartMusteriID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataRow dr in Lojistik.dt.Rows)
                    {
                        foreach (DataGridViewRow gridDR in grdIsTipleri.Rows)
                        {
                            if (gridDR.Cells["ID"].Value.ToString() == dr.ItemArray[0].ToString())
                            {
                                gridDR.Cells["SEÇİM"].Value = true;
                            }
                        }
                    }

                }

                grdMusteriDosyaLoad();

            }
        }

        private void grdIsTanimlariLoad()
        {
            LojistikDesign.DataGrid(grdIsTipleri);

            ret = Lojistik.ParametrikListeler("IS_TANIMI_LISTESI");
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdIsTipleri.DataSource = Lojistik.dt;

                DataGridViewCheckBoxColumn chkIsTanimlari = new DataGridViewCheckBoxColumn();
                chkIsTanimlari.Name = "SEÇİM";
                chkIsTanimlari.FillWeight = 25;
                chkIsTanimlari.DisplayIndex = 0;
                grdIsTipleri.Columns.Add(chkIsTanimlari);

                grdIsTipleri.Columns["ID"].Visible = false;

                grdIsTipleri.Columns["IS_TANIMI"].HeaderText = "MÜŞTERİ İŞ TANIMLARI";
                grdIsTipleri.Columns["IS_TANIMI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdIsTipleri.Columns["IS_TANIMI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdIsTipleri.Columns["IS_TANIMI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdIsTipleri.ClearSelection();
            }
        }

        private void grdMusteriDosyaLoad()
        {
            btnMusteriDosyaEkle.Visible = true;

            string yolKartMusteriID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();

            LojistikDesign.DataGrid(grdMusteriDosya);


            ret = Lojistik.YolKartMusteriDosyalar(yolKartMusteriID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdMusteriDosya.DataSource = Lojistik.dt;


                DataGridViewButtonColumn btnDosyaAc = new DataGridViewButtonColumn();
                btnDosyaAc.Name = "";
                btnDosyaAc.Text = "DOSYA AÇ";
                btnDosyaAc.UseColumnTextForButtonValue = true;
                btnDosyaAc.FillWeight = 15;
                btnDosyaAc.DisplayIndex = 5;
                btnDosyaAc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnDosyaAc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnDosyaAc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn btnDosyaSil = new DataGridViewButtonColumn();
                btnDosyaSil.Name = "";
                btnDosyaSil.Text = "DOSYA SİL";
                btnDosyaSil.UseColumnTextForButtonValue = true;
                btnDosyaSil.FillWeight = 15;
                btnDosyaAc.DisplayIndex = 6;
                btnDosyaSil.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnDosyaSil.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnDosyaSil.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                grdMusteriDosya.Columns["ID"].Visible = false;
                grdMusteriDosya.Columns["YOL_KART_MUSTERI"].Visible = false;
                grdMusteriDosya.Columns["DOSYA_TIPI"].Visible = false;
                grdMusteriDosya.Columns["DOSYA_BOYUTU"].Visible = false;

                grdMusteriDosya.Columns["DOSYA_ADI"].HeaderText = "DOSYA ADI";
                grdMusteriDosya.Columns["DOSYA_ADI"].FillWeight = 70;
                grdMusteriDosya.Columns["DOSYA_ADI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdMusteriDosya.Columns["DOSYA_ADI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdMusteriDosya.Columns["DOSYA_ADI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdMusteriDosya.Columns.Add(btnDosyaAc);
                grdMusteriDosya.Columns.Add(btnDosyaSil);


                grdIsTipleri.ClearSelection();
            }

        }

        private void grdIsTipleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 2 && grdMusteriler.SelectedRows.Count > 0)
            {
                string cariID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();
                string isTanimID = grdIsTipleri.SelectedRows[0].Cells["ID"].Value.ToString();

                if (Convert.ToBoolean(grdIsTipleri.SelectedRows[0].Cells["SEÇİM"].Value) == false)
                {
                    ret = Lojistik.YolKartMusteriyeIsTanimla(yolKartID, cariID, isTanimID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        grdIsTipleri.SelectedRows[0].Cells["SEÇİM"].Value = true;
                    }
                }
                else
                {
                    ret = Lojistik.YolKartMusteriyeTanimliIsSil(yolKartID, cariID, isTanimID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        grdIsTipleri.SelectedRows[0].Cells["SEÇİM"].Value = false;
                    }
                }

            }
        }

        private void txtMusteriNot_TextChanged(object sender, EventArgs e)
        {
            string yolKartMusteriID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();

            ret = Lojistik.YolKartMusteriNotGuncelle(yolKartMusteriID, txtMusteriNot.Text);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdMusteriler.SelectedRows[0].Cells["ACIKLAMA"].Value = txtMusteriNot.Text;
            }
        }

        private void btnMusteriDosyaEkle_Click(object sender, EventArgs e)
        {
            string yolKartMusteriID = grdMusteriler.SelectedRows[0].Cells["ID"].Value.ToString();

            ret = Lojistik.YolKartMusteriyeDosyaEkle(yolKartMusteriID);
            if (!ret)
            {
                if (Lojistik.hata != "Hatasız")
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                grdMusteriDosyaLoad();
            }
        }

        private void grdMusteriDosya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && grdMusteriDosya.CurrentCell.FormattedValue.ToString() == "DOSYA AÇ")
            {
                try
                {
                    string dosyaID = grdMusteriDosya.SelectedRows[0].Cells["ID"].Value.ToString();
                    ret = Lojistik.YolKartMusteriDosyaIcerik(dosyaID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        byte[] dosyaIcerik = (byte[])Lojistik.dt.Rows[0]["DOSYA_ICERIK"];
                        string path = Lojistik.dt.Rows[0]["DOSYA_ADI"].ToString();

                        FileInfo fi = new System.IO.FileInfo(path);
                        FileStream fs = fi.OpenWrite();
                        fs.Write(dosyaIcerik, 0, dosyaIcerik.Length);

                        fs.Close();

                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch
                {
                    MessageBox.Show("Açmaya Çalıştığınız Dosya Kullanılıyor Olabilir. Lütfen Kontrol Ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.RowIndex > -1 && grdMusteriDosya.CurrentCell.FormattedValue.ToString() == "DOSYA SİL")
            {
                string musteriDosyaID = grdMusteriDosya.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartMusteriDosyaSil(musteriDosyaID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdMusteriDosyaLoad();
                }
            }
        }
        #endregion

        #region Araçlar
        private void tabAracLoad()
        {
            yolKartAracID = "";
            lblAracBilgi.Text = "";
            grdAracRotasinaEkliLokasyonlar.DataSource = null;

            foreach (Control control in grbDataLokasyon.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }

            grdAraclarLoad(yolKartID);

        }

        private void grdAraclarLoad(string yolKartID)
        {
            LojistikDesign.DataGrid(grdAraclar);

            ret = Lojistik.YolKartAracListesi(yolKartID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdAraclar.DataSource = Lojistik.dt;


                DataGridViewButtonColumn btnKuyrukEkle = new DataGridViewButtonColumn();
                btnKuyrukEkle.Name = "";
                btnKuyrukEkle.Text = "KUYRUK EKLE";
                btnKuyrukEkle.UseColumnTextForButtonValue = true;
                btnKuyrukEkle.FillWeight = 10;
                btnKuyrukEkle.DisplayIndex = 8;
                btnKuyrukEkle.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnKuyrukEkle.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnKuyrukEkle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn btnAracKaldir = new DataGridViewButtonColumn();
                btnAracKaldir.Name = "";
                btnAracKaldir.Text = "ARACI ÇIKAR";
                btnAracKaldir.UseColumnTextForButtonValue = true;
                btnAracKaldir.FillWeight = 10;
                btnAracKaldir.DisplayIndex = 9;
                btnAracKaldir.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnAracKaldir.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnAracKaldir.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdAraclar.Columns["ID"].Visible = false;
                grdAraclar.Columns["ARAC_ID"].Visible = false;
                grdAraclar.Columns["ACIKLAMA"].Visible = false;
                grdAraclar.Columns["ROWNUM"].Visible = false;

                grdAraclar.Columns["PLAKA"].HeaderText = "PLAKA";
                grdAraclar.Columns["PLAKA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["PLAKA"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["PLAKA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["PLAKA"].FillWeight = 7;

                grdAraclar.Columns["ARAC_TIPI"].HeaderText = "ARAÇ TİPİ";
                grdAraclar.Columns["ARAC_TIPI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["ARAC_TIPI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["ARAC_TIPI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["ARAC_TIPI"].FillWeight = 7;

                grdAraclar.Columns["LOKASYON_TANIMI"].HeaderText = "ARAÇ SON\rVARDIĞI LOKASYON";
                grdAraclar.Columns["LOKASYON_TANIMI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["LOKASYON_TANIMI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["LOKASYON_TANIMI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdAraclar.Columns["LOKASYON_TANIMI"].FillWeight = 30;

                grdAraclar.Columns["SON_VARIS_ZAMANI"].HeaderText = "SON VARIŞ";
                grdAraclar.Columns["SON_VARIS_ZAMANI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["SON_VARIS_ZAMANI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["SON_VARIS_ZAMANI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["SON_VARIS_ZAMANI"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                grdAraclar.Columns["SON_VARIS_ZAMANI"].FillWeight = 15;

                grdAraclar.Columns["SON_KM"].HeaderText = "KM SAYACI";
                grdAraclar.Columns["SON_KM"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["SON_KM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["SON_KM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["SON_KM"].DefaultCellStyle.Format = "N2";
                grdAraclar.Columns["SON_KM"].FillWeight = 13;

                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].HeaderText = "DEPO\r(LT)";
                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].DefaultCellStyle.Format = "N2";
                grdAraclar.Columns["KALAN_YAKIT_MIKTARI"].FillWeight = 8;

                grdAraclar.Columns.Add(btnAracKaldir);
                grdAraclar.Columns.Add(btnKuyrukEkle);


                grdAraclar.ClearSelection();
            }

        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            SecimAracEkle();
        }

        private void SecimAracEkle()
        {
            SecimParametre ac = new SecimParametre("YOL_KARTA_ARAC_SECIMI", "ARAÇ LİSTESİ");
            ac.ShowDialog();


            if (!String.IsNullOrWhiteSpace(SecimParametre.secimID) && SecimParametre.secim == "OK")
            {
                ret = Lojistik.YolKartAracEkle(yolKartID, SecimParametre.secimID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdAraclarLoad(yolKartID);

                    for (int i = 0; i < grdAraclar.Rows.Count; i++)
                    {
                        if (SecimParametre.secimID == grdAraclar.Rows[i].Cells["ARAC_ID"].Value.ToString())
                        {
                            grdAraclar.Rows[i].Cells[0].Selected = true;
                        }
                    }
                }
            }
        }
        
        private void grdLokasyonAdreslerLoad()
        {
            dsLokasyonBilgisi = new DataSet();
            
            string[] latLong = txtKoordinat.Text.Trim().Split(',');

            try 
            {
                if (latLong.Length==4)
                {
                    xmlLokasyon = XmlReader.Create(@"http://dev.virtualearth.net/REST/v1/Locations/" + latLong[0] + "."+ latLong[1] +"," + latLong[2] + "."+ latLong[3] +"?o=xml&key=" + bingMapKey + "&includeNeighborhood=1", new XmlReaderSettings());
                }
                else if (latLong.Length==2)
                {
                    xmlLokasyon = XmlReader.Create(@"http://dev.virtualearth.net/REST/v1/Locations/" + latLong[0] + "," + latLong[1] + "?o=xml&key=" + bingMapKey + "&includeNeighborhood=1", new XmlReaderSettings());
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            dsLokasyonBilgisi.ReadXml(xmlLokasyon);
            LojistikDesign.DataGrid(grdLokasyonAdresler);

            if (xmlLokasyon==null)
            {
                return;
            }

            xmlLokasyon.Close();

            DataTable dtAddress = new DataTable();

            dtAddress = dsLokasyonBilgisi.Tables["Address"];

            if (dtAddress == null)
            {
                return;
            }
            

            foreach (DataColumn dc in dtAddress.Columns)
            {
                grdLokasyonAdresler.Columns.Add(dc.ColumnName, dc.ColumnName);    
            }

            grdLokasyonAdresler.Columns.Add("latLong","LatLong");
            

            for (int i = 0; i < dtAddress.Rows.Count; i++)
            {
                grdLokasyonAdresler.Rows.Add();

                for (int y = 0; y < dtAddress.Columns.Count; y++)
                {
                    grdLokasyonAdresler.Rows[i].Cells[y].Value = dtAddress.Rows[i].ItemArray[y].ToString();

                    grdLokasyonAdresler.Rows[i].Cells["LatLong"].Value = txtKoordinat.Text.Trim();
                }
            }
            

            grdLokasyonAdresler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;


            if (grdLokasyonAdresler.Columns["Location_Id"] != null)
            {
                grdLokasyonAdresler.Columns["Location_Id"].Visible = false;
            }

            if (grdLokasyonAdresler.Columns["Intersection"] != null)
            {
                grdLokasyonAdresler.Columns["Intersection"].Visible = false;
            }

            if (grdLokasyonAdresler.Columns["Locality"] != null)
            {
                grdLokasyonAdresler.Columns["Locality"].Visible = false;
            }

            if (grdLokasyonAdresler.Columns["LatLong"] != null)
            {
                grdLokasyonAdresler.Columns["LatLong"].Visible = false;
            }

            if (grdLokasyonAdresler.Columns["CountryRegion"] != null)
            {
                grdLokasyonAdresler.Columns["CountryRegion"].HeaderText = "Ülke";
                grdLokasyonAdresler.Columns["CountryRegion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["CountryRegion"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["CountryRegion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //grdLokasyonAdresler.Columns["CountryRegion"].DisplayIndex = 0;
            }

            if (grdLokasyonAdresler.Columns["AdminDistrict"] != null)
            {
                grdLokasyonAdresler.Columns["AdminDistrict"].HeaderText = "Şehir";
                grdLokasyonAdresler.Columns["AdminDistrict"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["AdminDistrict"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["AdminDistrict"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //grdLokasyonAdresler.Columns["AdminDistrict"].DisplayIndex = 1;
            }

            if (grdLokasyonAdresler.Columns["AdminDistrict2"] != null)
            {
                grdLokasyonAdresler.Columns["AdminDistrict2"].HeaderText = "İlçe";
                grdLokasyonAdresler.Columns["AdminDistrict2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["AdminDistrict2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["AdminDistrict2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //grdLokasyonAdresler.Columns["AdminDistrict2"].DisplayIndex = 2;
            }

            if (grdLokasyonAdresler.Columns["Neighborhood"] != null)
            {
                grdLokasyonAdresler.Columns["Neighborhood"].HeaderText = "Mahalle";
                grdLokasyonAdresler.Columns["Neighborhood"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["Neighborhood"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["Neighborhood"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["Neighborhood"].DisplayIndex = 3;
            }

            if (grdLokasyonAdresler.Columns["AddressLine"] != null)
            {
                grdLokasyonAdresler.Columns["AddressLine"].HeaderText = "Sokak/Cadde/Kapı No";
                grdLokasyonAdresler.Columns["AddressLine"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["AddressLine"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["AddressLine"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //grdLokasyonAdresler.Columns["AddressLine"].DisplayIndex = 4;
            }


            if (grdLokasyonAdresler.Columns["PostalCode"] != null)
            {
                grdLokasyonAdresler.Columns["PostalCode"].HeaderText = "Posta Kodu";
                grdLokasyonAdresler.Columns["PostalCode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["PostalCode"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["PostalCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //grdLokasyonAdresler.Columns["PostalCode"].DisplayIndex = 5;
            }


            if (grdLokasyonAdresler.Columns["FormattedAddress"] != null)
            {
                grdLokasyonAdresler.Columns["FormattedAddress"].Visible = false;
                grdLokasyonAdresler.Columns["FormattedAddress"].HeaderText = "Adres Görüntüsü";
                grdLokasyonAdresler.Columns["FormattedAddress"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonAdresler.Columns["FormattedAddress"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonAdresler.Columns["FormattedAddress"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                //grdLokasyonAdresler.Columns["FormattedAddress"].DisplayIndex = 6;
            }
            
            grdLokasyonAdresler.ClearSelection();
        }
        
        private void grdLokasyonVeritabaniKayitlariLoad()
        {
            LojistikDesign.DataGrid(grdLokasyonVeritabaniKayitlari);

            string[] latLong = txtKoordinat.Text.Split(',');

            decimal lat = 0;
            decimal longa = 0;

            if (latLong.Length == 4)
            {
                lat = Convert.ToDecimal(latLong[0] + "," + latLong[1]);
                longa = Convert.ToDecimal(latLong[2] + "," + latLong[3]);
            }
            else if (latLong.Length == 2)
            {
                lat = Convert.ToDecimal(latLong[0].Replace(".",","));
                longa = Convert.ToDecimal(latLong[1].Replace(".", ","));
            }

            ret = Lojistik.LokasyonVeritabaniKayitlari(lat,longa);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdLokasyonVeritabaniKayitlari.DataSource = Lojistik.dt;

                grdLokasyonVeritabaniKayitlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                
                grdLokasyonVeritabaniKayitlari.Columns["ID"].Visible = false;
                grdLokasyonVeritabaniKayitlari.Columns["LATLONG"].Visible = false;


                grdLokasyonVeritabaniKayitlari.Columns["LOKASYON_TANIMI"].HeaderText = "Lokasyon Tanımı";
                grdLokasyonVeritabaniKayitlari.Columns["LOKASYON_TANIMI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["LOKASYON_TANIMI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["LOKASYON_TANIMI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["LOKASYON_TANIMI"].DisplayIndex = 0;
                
                grdLokasyonVeritabaniKayitlari.Columns["ULKE"].HeaderText = "Ülke";
                grdLokasyonVeritabaniKayitlari.Columns["ULKE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["ULKE"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["ULKE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["ULKE"].DisplayIndex = 1;

                grdLokasyonVeritabaniKayitlari.Columns["SEHIR"].HeaderText = "Şehir";
                grdLokasyonVeritabaniKayitlari.Columns["SEHIR"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["SEHIR"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["SEHIR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["SEHIR"].DisplayIndex = 2;

                grdLokasyonVeritabaniKayitlari.Columns["ILCE"].HeaderText = "İlçe/Semt";
                grdLokasyonVeritabaniKayitlari.Columns["ILCE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["ILCE"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["ILCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["ILCE"].DisplayIndex = 3;

                grdLokasyonVeritabaniKayitlari.Columns["BOLGE"].HeaderText = "Mah.Böl.";
                grdLokasyonVeritabaniKayitlari.Columns["BOLGE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["BOLGE"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["BOLGE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["BOLGE"].DisplayIndex = 4;

                grdLokasyonVeritabaniKayitlari.Columns["CAD_SOK_KAPI"].HeaderText = "Cd.Sk.Kapı.";
                grdLokasyonVeritabaniKayitlari.Columns["CAD_SOK_KAPI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["CAD_SOK_KAPI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["CAD_SOK_KAPI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdLokasyonVeritabaniKayitlari.Columns["CAD_SOK_KAPI"].DisplayIndex = 5;

                grdLokasyonVeritabaniKayitlari.Columns["POSTA_KODU"].HeaderText = "Posta Kodu";
                grdLokasyonVeritabaniKayitlari.Columns["POSTA_KODU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["POSTA_KODU"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["POSTA_KODU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["POSTA_KODU"].DisplayIndex = 6;
                
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].HeaderText = "Kayıt Tarihi";
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].DefaultCellStyle.Format = "dd/MM/yyyy";
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdLokasyonVeritabaniKayitlari.Columns["KAYIT_TARIHI"].DisplayIndex = 7;

                grdAraclar.ClearSelection();
            }
        }

        private void grdLokasyonVeritabaniKayitlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtUlke.Text = "";
                txtSehir.Text = "";
                txtIlce.Text = "";
                txtMah.Text = "";
                txtCadSok.Text = "";
                txtPostaKodu.Text = "";
                txtLokasyonTanimi.Text = "";
                txtLokasyonKoordinat.Text = "";
                
                txtUlke.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["ULKE"].Value.ToString();
                txtSehir.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["SEHIR"].Value.ToString();
                txtIlce.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["ILCE"].Value.ToString();
                txtMah.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["BOLGE"].Value.ToString();
                txtCadSok.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["CAD_SOK_KAPI"].Value.ToString();
                txtPostaKodu.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["POSTA_KODU"].Value.ToString();
                txtLokasyonTanimi.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["LOKASYON_TANIMI"].Value.ToString();
                txtLokasyonKoordinat.Text = grdLokasyonVeritabaniKayitlari.SelectedRows[0].Cells["LATLONG"].Value.ToString();

                tabLokasyon.SelectedTab = tabLokasyon.TabPages["tabSeciliAdres"];
            }
        }

        private void btnRotaDurakEkle_Click(object sender, EventArgs e)
        {

        }

        private void txtKoordinat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                grdLokasyonAdreslerLoad();
                grdLokasyonVeritabaniKayitlariLoad();
                tabLokasyon.SelectedTab = tabLokasyon.TabPages["tabServisSaglayiciAdresler"];
            }
        }

        private void btnLokasyonGetir_Click(object sender, EventArgs e)
        {
            grdLokasyonAdreslerLoad();
            grdLokasyonVeritabaniKayitlariLoad();
            tabLokasyon.SelectedTab = tabLokasyon.TabPages["tabServisSaglayiciAdresler"];
        }

        private void grdLokasyonAdresler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtUlke.Text = "";
                txtSehir.Text = "";
                txtIlce.Text = "";
                txtMah.Text = "";
                txtCadSok.Text = "";
                txtPostaKodu.Text = "";
                txtLokasyonTanimi.Text = "";
                txtLokasyonKoordinat.Text = "";
                

                if (grdLokasyonAdresler.Columns.Contains("CountryRegion"))
                {
                    txtUlke.Text = grdLokasyonAdresler.SelectedRows[0].Cells["CountryRegion"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("AdminDistrict"))
                {
                    txtSehir.Text = grdLokasyonAdresler.SelectedRows[0].Cells["AdminDistrict"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("AdminDistrict2"))
                {
                    txtIlce.Text = grdLokasyonAdresler.SelectedRows[0].Cells["AdminDistrict2"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("Neighborhood"))
                {
                    txtMah.Text = grdLokasyonAdresler.SelectedRows[0].Cells["Neighborhood"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("AddressLine"))
                {
                    txtCadSok.Text = grdLokasyonAdresler.SelectedRows[0].Cells["AddressLine"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("PostalCode"))
                {
                    txtPostaKodu.Text = grdLokasyonAdresler.SelectedRows[0].Cells["PostalCode"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("FormattedAddress"))
                {
                    txtLokasyonTanimi.Text = grdLokasyonAdresler.SelectedRows[0].Cells["FormattedAddress"].Value.ToString();
                }

                if (grdLokasyonAdresler.Columns.Contains("LatLong"))
                {
                    txtLokasyonKoordinat.Text = grdLokasyonAdresler.SelectedRows[0].Cells["LatLong"].Value.ToString();
                }


                tabLokasyon.SelectedTab = tabLokasyon.TabPages["tabSeciliAdres"];
            }
        }
        
        private void grdAraclar_SelectionChanged(object sender, EventArgs e)
        {
            if (grdAraclar.SelectedRows.Count > 0)
            {
                yolKartRotaSecimID = "";
                txtAracNot.Visible = true;
                yolKartAracID = grdAraclar.SelectedRows[0].Cells["ID"].Value.ToString();
                string aracID = grdAraclar.SelectedRows[0].Cells["ARAC_ID"].Value.ToString();
                txtAracNot.Text = grdAraclar.SelectedRows[0].Cells["ACIKLAMA"].Value.ToString();
                txtKalkisKm.Text = Convert.ToDecimal(grdAraclar.SelectedRows[0].Cells["SON_KM"].Value.ToString()).ToString("N2");
                aracSonVarisZamani = Convert.ToDateTime(grdAraclar.SelectedRows[0].Cells["SON_VARIS_ZAMANI"].Value.ToString());

                ret = Lojistik.YolKartAracRotaSecimOnaySorgula(yolKartAracID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Lojistik.dt.Rows.Count>0)
                    {
                        yolKartRotaSecimID = Lojistik.dt.Rows[0]["YOL_KART_ROTA_SECIM_ID"].ToString();
                        lblSecilenYolGuzergah.Text = Lojistik.dt.Rows[0]["ACIKLAMA"].ToString() +" "+ Convert.ToDecimal(Lojistik.dt.Rows[0]["KM"].ToString()).ToString("N2") +" KM";
                        lblAracTahminiKalkis.Text = Lojistik.dt.Rows[0]["TAHMINI_KALKIS"].ToString();
                        lblAracTahminiVaris.Text = Lojistik.dt.Rows[0]["TAHMINI_VARIS"].ToString();
                        txtVarisKm.Text = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(txtKalkisKm.Text) + Convert.ToDecimal(Lojistik.dt.Rows[0]["TOP_MESAFE"].ToString()))).ToString("N2");
                    }

                    ret = Lojistik.AracSonLokasyonBilgisi(aracID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        aracPlaka = Lojistik.dt.Rows[0]["PLAKA"].ToString();
                        aracSonUlke = Lojistik.dt.Rows[0]["ULKE"].ToString();
                        aracSonSehir = Lojistik.dt.Rows[0]["SEHIR"].ToString();
                        aracSonIlce = Lojistik.dt.Rows[0]["ILCE"].ToString();
                        aracSonBolge = Lojistik.dt.Rows[0]["BOLGE"].ToString();
                        aracSonCadSokKapi = Lojistik.dt.Rows[0]["CAD_SOK_KAPI"].ToString();
                        aracSonPostaKodu = Lojistik.dt.Rows[0]["POSTA_KODU"].ToString();
                        aracSonLokasyonTanimi = Lojistik.dt.Rows[0]["LOKASYON_TANIMI"].ToString();
                        aracSonLat = Lojistik.dt.Rows[0]["LAT"].ToString();
                        aracSonLong = Lojistik.dt.Rows[0]["LONG"].ToString();

                        txtAracBasKoordinat.Text = Lojistik.dt.Rows[0]["LAT"].ToString() + "," + Lojistik.dt.Rows[0]["LONG"].ToString();
                    }

                    if (String.IsNullOrEmpty(yolKartRotaSecimID))
                    {
                        AracRotasiOnayDurumu(false);
                        
                        lblAracBilgi.Text = aracPlaka + " PLAKALI ARAÇ KAYITLARA GÖRE; '" + aracSonLokasyonTanimi + "' TANIMLI LOKASYONDADIR";

                        grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);
                        grdRotaSecimleriLoad(yolKartAracRotaID);

                        tabAracDiger.SelectedIndex = 0;
                    }
                    else
                    {
                        txtAracBasKoordinat.Text = "";

                        lblAracBilgi.Text = aracPlaka + " PLAKALI ARACIN YENİ VARIŞ ROTASI ONAYLANMIŞTIR. KAYITLAR AŞAĞIDAKİ GİBİDİR";

                        grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);

                        tabAracDiger.SelectedIndex = 0;

                        AracRotasiOnayDurumu(true);
                    }
                    
                }

                grdAracDosyaLoad();
            }
        }

        private void grdAracRotasinaEkliLokasyonlarLoad(string yolKartAracID, out string yolKartAracRotaID)
        {
            string hata = "";
            LojistikDesign.DataGrid(grdAracRotasinaEkliLokasyonlar);

            ret = Lojistik.AracRotaLokasyonBilgisi(yolKartAracID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdAracRotasinaEkliLokasyonlar.DataSource = Lojistik.dt;

                DataGridViewButtonColumn btnYukariTasi = new DataGridViewButtonColumn();
                btnYukariTasi.Name = "";
                btnYukariTasi.Text = "↑";
                btnYukariTasi.UseColumnTextForButtonValue = true;
                btnYukariTasi.FillWeight = 15;
                btnYukariTasi.DisplayIndex = 2;
                btnYukariTasi.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnYukariTasi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnYukariTasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn btnAsagiTasi = new DataGridViewButtonColumn();
                btnAsagiTasi.Name = "";
                btnAsagiTasi.Text = "↓";
                btnAsagiTasi.UseColumnTextForButtonValue = true;
                btnAsagiTasi.FillWeight = 15;
                btnAsagiTasi.DisplayIndex = 3;
                btnAsagiTasi.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnAsagiTasi.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnAsagiTasi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn btnRotadanCikar = new DataGridViewButtonColumn();
                btnRotadanCikar.Name = "";
                btnRotadanCikar.Text = "❌";
                btnRotadanCikar.UseColumnTextForButtonValue = true;
                btnRotadanCikar.FillWeight = 15;
                btnRotadanCikar.DisplayIndex = 4;
                btnRotadanCikar.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnRotadanCikar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnRotadanCikar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                grdAracRotasinaEkliLokasyonlar.Columns["ID"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["SIRA_NO"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["ULKE"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["SEHIR"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["ILCE"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["BOLGE"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["CAD_SOK_KAPI"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["POSTA_KODU"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["LAT"].Visible = false;
                grdAracRotasinaEkliLokasyonlar.Columns["LONG"].Visible = false;

                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].HeaderText = "Rota Tipi";
                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].FillWeight = 30;
                grdAracRotasinaEkliLokasyonlar.Columns["ROTA_TIPI"].DisplayIndex = 0;

                grdAracRotasinaEkliLokasyonlar.Columns["LOKASYON_TANIMI"].HeaderText = "Lokasyon Tanımı";
                grdAracRotasinaEkliLokasyonlar.Columns["LOKASYON_TANIMI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAracRotasinaEkliLokasyonlar.Columns["LOKASYON_TANIMI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAracRotasinaEkliLokasyonlar.Columns["LOKASYON_TANIMI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdAracRotasinaEkliLokasyonlar.Columns["LOKASYON_TANIMI"].DisplayIndex = 1;

                grdAracRotasinaEkliLokasyonlar.Columns.Add(btnRotadanCikar);
                grdAracRotasinaEkliLokasyonlar.Columns.Add(btnYukariTasi);
                grdAracRotasinaEkliLokasyonlar.Columns.Add(btnAsagiTasi);
                
                grdAracRotasinaEkliLokasyonlar.ClearSelection();
            }

            string aracRotaID = "";

            try { aracRotaID = grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString();} catch(Exception ex) { hata = ex.ToString(); }

            yolKartAracRotaID = aracRotaID;
            
        }

        private void grdRotaSecimleriLoad(string yolKartAracRotaID)
        {

            grdRotaSecimleri.DataSource = null;

            LojistikDesign.DataGrid(grdRotaSecimleri);

            ret = Lojistik.YolKartAracRotaSecimleriGetir(yolKartAracRotaID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdRotaSecimleri.DataSource = Lojistik.dt;

                grdRotaSecimleri.Columns["ID"].Visible = false;
                grdRotaSecimleri.Columns["YOL_KART_ARAC_ROTA"].Visible = false;
                grdRotaSecimleri.Columns["DURAK_SAYISI"].Visible = false;

                grdRotaSecimleri.Columns["SAAT"].HeaderText = "Saat";
                grdRotaSecimleri.Columns["SAAT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["SAAT"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["SAAT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["SAAT"].FillWeight = 10;

                grdRotaSecimleri.Columns["DAKIKA"].HeaderText = "Dakika";
                grdRotaSecimleri.Columns["DAKIKA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["DAKIKA"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["DAKIKA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["DAKIKA"].FillWeight = 10;

                grdRotaSecimleri.Columns["ACIKLAMA"].HeaderText = "Açıklama";
                grdRotaSecimleri.Columns["ACIKLAMA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["ACIKLAMA"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["ACIKLAMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdRotaSecimleri.Columns["ACIKLAMA"].FillWeight = 30;

                grdRotaSecimleri.Columns["UCRET_DURUMU"].HeaderText = "Ücretli Yol Durumu";
                grdRotaSecimleri.Columns["UCRET_DURUMU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["UCRET_DURUMU"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["UCRET_DURUMU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["UCRET_DURUMU"].FillWeight = 30;
                
                grdRotaSecimleri.Columns["KM"].HeaderText = "Toplam Mesafe";
                grdRotaSecimleri.Columns["KM"].DefaultCellStyle.Format = "N2";
                grdRotaSecimleri.Columns["KM"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["KM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["KM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["KM"].FillWeight = 10;
                
                grdRotaSecimleri.ClearSelection();
            }

        }

        private void grdRotaSecimTarifiLoad(string yolKartAracRotaSecim)
        {
            grdRotaSecimleri.DataSource = null;

            LojistikDesign.DataGrid(grdRotaSecimleri);

            ret = Lojistik.YolKartAracRotaSecimTarifGetir(yolKartAracRotaSecim);
            if (!ret)
            {
                MessageBox.Show(YolGuzergahBilgisiGetir.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                grdRotaSecimleri.DataSource = Lojistik.dt;

                grdRotaSecimleri.Columns["ID"].Visible = false;
                grdRotaSecimleri.Columns["SECIM_ID"].Visible = false;

                grdRotaSecimleri.Columns["TARIF"].HeaderText = "Güzergah Yol Tarifi";
                grdRotaSecimleri.Columns["TARIF"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdRotaSecimleri.Columns["TARIF"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRotaSecimleri.Columns["TARIF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdRotaSecimleri.ClearSelection();

                btnRotaSecenekler.Visible = true;
            }

        }

        private void btnRotaSecimi_Click(object sender, EventArgs e)
        {
            //ret = Lojistik.HtmlRotaOlustur(aracSonLokasyon,txtLokasyonTanimi.Text);

            string[] baslangicLatLang = txtAracBasKoordinat.Text.Split(',');
            string[] varisLatLang = txtKoordinat.Text.Split(',');
            
        }

        private void btnRotayaEkle_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLokasyonKoordinat.Text) || String.IsNullOrWhiteSpace(txtLokasyonTanimi.Text) || String.IsNullOrWhiteSpace(yolKartAracID))
            {
                MessageBox.Show("Koordinat Bilgisi ile gelen verilerden;\rEn az Lokasyon Adres Tanımının yapılarak,\rAraç Seçiminin de olması gerekmektedir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Decimal lat = new Decimal();
                Decimal longa = new Decimal();
                
                string[] latLong = txtLokasyonKoordinat.Text.Trim().Split(',');

                try
                {
                    
                    if (latLong.Length == 2)
                    {
                        lat = Convert.ToDecimal(latLong[0].Replace(".",","));
                        longa = Convert.ToDecimal(latLong[1].Replace(".", ","));
                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }

                ret = Lojistik.YolKartAracRotaEkle(yolKartAracID, txtUlke.Text, txtSehir.Text, txtIlce.Text, txtMah.Text, txtCadSok.Text, txtPostaKodu.Text, txtLokasyonTanimi.Text, lat, longa);
                if (!ret)
                {
                    if (Lojistik.hata != "Hatasız")
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);
                }

                tabAracDiger.TabIndex = 0;

                RotaSecenekleriniSil();

            }
        }

        private void btnKoordinatGoruntule_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLokasyonKoordinat.Text) || String.IsNullOrWhiteSpace(txtLokasyonTanimi.Text))
            {
                MessageBox.Show("En az Lokasyon Adres Tanımının yapılmış ve Koordinat bilgisinin olması gerekmektedir", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] latLong = txtLokasyonKoordinat.Text.Trim().Split(',');

                try
                {
                    if (latLong.Length == 4)
                    {
                        System.Diagnostics.Process.Start("https://www.google.com.tr/maps/place/" + latLong[0] + "." + latLong[1] + "," + latLong[2] + "." + latLong[3] + "");
                    }
                    else if (latLong.Length == 2)
                    {
                        System.Diagnostics.Process.Start("https://www.google.com.tr/maps/place/" + latLong[0] + "," + latLong[1] + "");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }


        }

        private void btnYandexGoruntule_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLokasyonKoordinat.Text) || String.IsNullOrWhiteSpace(txtLokasyonTanimi.Text))
            {
                MessageBox.Show("En az Lokasyon Adres Tanımının yapılmış ve Koordinat bilgisinin olması gerekmektedir", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] latLong = txtLokasyonKoordinat.Text.Trim().Split(',');

                try
                {
                    if (latLong.Length == 4)
                    {
                        System.Diagnostics.Process.Start("https://yandex.com.tr/harita/?from=morda_new&ll=" + latLong[2] + "." + latLong[3] + "," + latLong[0] + "." + latLong[1] + "&z=21");
                    }
                    else if (latLong.Length == 2)
                    {
                        System.Diagnostics.Process.Start("https://yandex.com.tr/harita/?from=morda_new&ll=" + latLong[1] + "," + latLong[0] + "&z=10.1");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }

        private void btnBingMapGoruntule_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLokasyonKoordinat.Text) || String.IsNullOrWhiteSpace(txtLokasyonTanimi.Text))
            {
                MessageBox.Show("En az Lokasyon Adres Tanımının yapılmış ve Koordinat bilgisinin olması gerekmektedir", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string[] latLong = txtLokasyonKoordinat.Text.Trim().Split(',');

                try
                {
                    if (latLong.Length == 4)
                    {
                        System.Diagnostics.Process.Start("https://bing.com/maps/default.aspx?cp=" + latLong[0] + "." + latLong[1] + "," + latLong[2] + "." + latLong[3] + "");
                    }
                    else if (latLong.Length == 2)
                    {
                        System.Diagnostics.Process.Start("https://bing.com/maps/default.aspx?cp=" + latLong[0] + "," + latLong[1] + "");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }
        
        private void grdAraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && grdAraclar.CurrentCell.FormattedValue.ToString() == "ARACI ÇIKAR")
            {
                string yolKartAracID = grdAraclar.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartAracSil(yolKartAracID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabAracLoad();
                }
            }
        }

        private void RotaSeceneklerineDon()
        {
            panelRotaSecimOnay.Visible = false;
            
            txtVarisKm.Text = "";
            
            lblRotaSecimYapmaUyarisi.Visible = true;
            lblRotaSecimYapmaUyarisi.Text = "Lütfen Rota Seciminizi Yapınız";
            lblRotaSecimYapmaUyarisi.Font = new Font(Font, FontStyle.Bold);
            lblRotaSecimYapmaUyarisi.Size = new Size(200, 17);

            tabAracRotaYolMesafe.Controls.Add(lblRotaSecimYapmaUyarisi);

            grdRotaSecimleri.Location = new Point(3, 23);
            grdRotaSecimleri.Size = new Size(535,325);


            grdRotaSecimleriLoad(grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString());
        }

        private void grdAracRotasinaEkliLokasyonlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "❌")
            {
                if (e.RowIndex != grdAracRotasinaEkliLokasyonlar.Rows.Count-1)
                {
                    MessageBox.Show("ROTADAN DURAK ÇIKARMA İŞLEMİ YALNIZCA SON SATIRDAN YAPILABİLMEKTEDİR.\r\rLÜTFEN ARADAN ÇIKARMAK İSTEDİĞİNİZ SATIRI EN SONA TAŞIYINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    string yolKartAracRotaID = grdAracRotasinaEkliLokasyonlar.SelectedRows[0].Cells["ID"].Value.ToString();
                    ret = Lojistik.YolKartAracRotaSil(yolKartAracRotaID, yolKartAracID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        RotaSeceneklerineDon();
                        RotaSecenekleriniSil();
                        grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);
                        return;
                    }
                }
            }
            else if (e.RowIndex > 0 && grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "↑")
            {
                int siraNo = Convert.ToInt32(grdAracRotasinaEkliLokasyonlar.SelectedRows[0].Cells["SIRA_NO"].Value.ToString());
                string yolKartAracRotaID = grdAracRotasinaEkliLokasyonlar.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartAracRotaSirasiniDegistir(yolKartAracRotaID,yolKartAracID,siraNo,"YUKARI");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RotaSeceneklerineDon();
                    RotaSecenekleriniSil();
                    grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);
                    return;
                }
            }
            else if (e.RowIndex > 0 && grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "↓")
            {
                int siraNo = Convert.ToInt32(grdAracRotasinaEkliLokasyonlar.SelectedRows[0].Cells["SIRA_NO"].Value.ToString());
                string yolKartAracRotaID = grdAracRotasinaEkliLokasyonlar.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartAracRotaSirasiniDegistir(yolKartAracRotaID, yolKartAracID, siraNo, "AŞAĞI");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RotaSeceneklerineDon();
                    RotaSecenekleriniSil();
                    grdAracRotasinaEkliLokasyonlarLoad(yolKartAracID, out yolKartAracRotaID);
                    return;
                }
            }
            else if(e.RowIndex==0 && (grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "↓" || grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "↑" || grdAracRotasinaEkliLokasyonlar.CurrentCell.FormattedValue.ToString() == "❌"))
            {
                MessageBox.Show("ARACIN BAŞLANGIÇ ROTASINA İŞLEM YAPAMAZSINIZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabAracDiger_Selected(object sender, TabControlEventArgs e)
        {
            if (tabAracDiger.SelectedTab.Name == "tabAracRotaYolMesafe")
            {
                if ((grdAracRotasinaEkliLokasyonlar.Rows.Count>1 || grdRotaSecimleri.Rows.Count>0) && !lblAracBilgi.Text.Contains("VARIŞ ROTASI ONAYLANMIŞTIR"))
                {
                    RotaSeceneklerineDon();
                    GuzergahSecenekleri();
                }
                else if (grdAracRotasinaEkliLokasyonlar.Rows.Count < 2 && !lblAracBilgi.Text.Contains("VARIŞ ROTASI ONAYLANMIŞTIR"))
                {
                    tabAracDiger.SelectedIndex = 0;
                    MessageBox.Show("Rotada sadece Başlagıç Bilgisi Yer Aldığından İşlem Yapılamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (lblAracBilgi.Text.Contains("VARIŞ ROTASI ONAYLANMIŞTIR"))
                {
                    AracRotasiOnayDurumu(true);
                }
            }
        }

        private void AracRotaDosyasiAc(string aracPlakasi)
        {
            try
            {
                string dosyaYolu = @"" + this.Text + " - " + aracPlakasi + ".html";

                ret = Lojistik.YolKartAracRotaHTMLDosyaIcerik(dosyaYolu);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    byte[] dosyaIcerik = (byte[])Lojistik.dt.Rows[0]["DOSYA_ICERIK"];
                    string path = Lojistik.dt.Rows[0]["DOSYA_ADI"].ToString();

                    FileInfo fi = new System.IO.FileInfo(path);
                    FileStream fs = fi.OpenWrite();
                    fs.Write(dosyaIcerik, 0, dosyaIcerik.Length);

                    fs.Close();

                    System.Diagnostics.Process.Start(path);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç Rotasına Ait Güzergah Seçenekleri Yok veya Dosya Kullanılıyor Olabilir. Lütfen Kontrol Ediniz.\r\r\r" + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRotaGoster_Click(object sender, EventArgs e)
        {
            AracRotaDosyasiAc(aracPlaka);
        }
        
        private void btnRotaSecenekler_Click(object sender, EventArgs e)
        {
            GuzergahSecenekleri();
        }

        private void GuzergahSecenekleri()
        {
            RotaSeceneklerineDon();

            if (grdRotaSecimleri.Rows.Count == 0 || grdAracRotasinaEkliLokasyonlar.Rows.Count != Convert.ToInt32(grdRotaSecimleri.Rows[0].Cells["DURAK_SAYISI"].Value.ToString()))
            {

                if (grdAracRotasinaEkliLokasyonlar.Rows.Count > 1)
                {

                    BindingSource bs = new BindingSource();
                    bs.DataSource = grdAracRotasinaEkliLokasyonlar.DataSource;
                    DataTable dt = (DataTable)(bs.DataSource);

                    string HTML = "";
                    string dosyaYolu = "";

                    Lojistik.HtmlRotaOlustur(this.Text, aracPlaka, dt, out HTML);

                    dosyaYolu = @"" + Application.StartupPath + "/" + this.Text + " - " + aracPlaka + ".html";

                    using (FileStream fs = new FileStream(dosyaYolu, FileMode.Create))
                    {
                        using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                        {
                            w.WriteLine(HTML);
                        }
                    }

                    int noktaSayisi = grdAracRotasinaEkliLokasyonlar.Rows.Count;


                    ret = Lojistik.YolKartAracRotaHTMLDosyaYukle(yolKartAracID, noktaSayisi, this.Text, aracPlaka, dosyaYolu);
                    if (!ret)
                    {
                        MessageBox.Show(YolGuzergahBilgisiGetir.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ret = YolGuzergahBilgisiGetir.RotaBilgileri(dosyaYolu, grdAracRotasinaEkliLokasyonlar.Rows.Count, grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString());
                        if (!ret)
                        {
                            MessageBox.Show(YolGuzergahBilgisiGetir.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            File.Delete(dosyaYolu);
                            grdRotaSecimleriLoad(grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString());
                        }
                    }

                    btnRotaSecenekler.Visible = false;
                }
            }
        }

        private void RotaSecenekleriniSil()
        {
            for (int i = 0; i < grdRotaSecimleri.Rows.Count; i++)
            {
                ret = Lojistik.YolKartAracRotaTarifleriSil(grdRotaSecimleri.Rows[i].Cells["ID"].Value.ToString());
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            ret = Lojistik.YolKartAracRotaHTMLSil(yolKartAracID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                ret = Lojistik.YolKartAracRotaSecimleriSil(grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString());

                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    grdRotaSecimleriLoad(grdAracRotasinaEkliLokasyonlar.Rows[0].Cells["ID"].Value.ToString());
                }
            }
        }

        private void grdRotaSecimleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && !grdRotaSecimleri.Columns.Contains("TARIF"))
            {
                panelRotaSecimOnay.Visible = true;
                lblRotaSecimYapmaUyarisi.Visible = false;
                grdRotaSecimleri.Location = new Point(3, 6);
                grdRotaSecimleri.Size = new Size(535,159);

                yolSaat = Convert.ToInt32(grdRotaSecimleri.SelectedRows[0].Cells["SAAT"].Value.ToString());
                yolDakika = Convert.ToInt32(grdRotaSecimleri.SelectedRows[0].Cells["DAKIKA"].Value.ToString());
                
                VarisZamanHesapla();

                decimal aracSonVarisKm = Convert.ToDecimal(txtKalkisKm.Text) + Convert.ToDecimal(grdRotaSecimleri.SelectedRows[0].Cells["KM"].Value.ToString());
                txtVarisKm.Text = aracSonVarisKm.ToString("N2");

                grdRotaSecimTarifiLoad(grdRotaSecimleri.SelectedRows[0].Cells["ID"].Value.ToString());

            }
        }
        
        private void dteTahminiKalkisTarih_Validating(object sender, CancelEventArgs e)
        {
            VarisZamanHesapla();
        }

        private void dteTahminiKalkisZaman_Validating(object sender, CancelEventArgs e)
        {
            VarisZamanHesapla();
        }

        private void btnRotaOnay_Click(object sender, EventArgs e)
        {
            DateTime tahminiKalkisZaman = new DateTime();
            DateTime tahminiVarisZaman = new DateTime();
            DateTime hesaplananVarisZamani = new DateTime();

            tahminiKalkisZaman = Convert.ToDateTime(dteTahminiKalkisTarih.Value.ToShortDateString() + " " + dteTahminiKalkisZaman.Value.ToLongTimeString());
            tahminiVarisZaman = Convert.ToDateTime(dteTahminiVarisTarih.Value.ToShortDateString() + " " + dteTahminiVarisZaman.Value.ToLongTimeString());

            TimeSpan zamanFarki = tahminiVarisZaman.Subtract(tahminiKalkisZaman);

            int toplamYolDk = (yolSaat * 60) + yolDakika;
            int ekMolaDk = toplamYolDk / 240;
            int toplamYolSuresiDk = toplamYolDk + (ekMolaDk *30);

            hesaplananVarisZamani = tahminiKalkisZaman.AddMinutes(toplamYolSuresiDk);

            if (zamanFarki.TotalMinutes < toplamYolSuresiDk)
            {
                MessageBox.Show("Lütfen aracın ortalama 4 saatte bir kez 30 dk. mola verdiğini hesap ederek, Tahmini Varış Zamanı belirleyiniz\r\rVarış zamanı ortalama hesaplamanın daha altında olamaz!\r\rHesaplanan ortalama varış zamanı aşağıdaki gibidir\r\r"+ hesaplananVarisZamani.ToLongDateString() +" " + hesaplananVarisZamani.ToLongTimeString() +"", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ret = Lojistik.YolKartAracRotaSecimOnayla(grdRotaSecimleri.Rows[0].Cells["SECIM_ID"].Value.ToString(),tahminiKalkisZaman, hesaplananVarisZamani, Convert.ToDecimal(Convert.ToDecimal(txtVarisKm.Text)- Convert.ToDecimal(txtKalkisKm.Text)), Convert.ToDecimal(txtKalkisKm.Text), Convert.ToDecimal(txtVarisKm.Text), "ONAY");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AracRotasiOnayDurumu(true);
                }
            }
            
        }

        private void dteTahminiKalkisTarih_ValueChanged(object sender, EventArgs e)
        {
            VarisZamanHesapla();
        }

        private void dteTahminiKalkisZaman_ValueChanged(object sender, EventArgs e)
        {
            VarisZamanHesapla();
        }

        private void VarisZamanHesapla()
        {
            DateTime tahminiKalkisZaman = new DateTime();
            DateTime tahminiVarisZaman = new DateTime();
            DateTime hesaplananVarisZamani = new DateTime();

            tahminiKalkisZaman = Convert.ToDateTime(dteTahminiKalkisTarih.Value.ToShortDateString() + " " + dteTahminiKalkisZaman.Value.ToLongTimeString());

            if (tahminiKalkisZaman < aracSonVarisZamani)
            {
                dteTahminiKalkisTarih.Value = aracSonVarisZamani;
                dteTahminiKalkisZaman.Value = aracSonVarisZamani;
                return;
            }

            tahminiVarisZaman = tahminiKalkisZaman.AddHours(yolSaat);
            tahminiVarisZaman = tahminiVarisZaman.AddMinutes(yolDakika);

            TimeSpan zamanFarki = tahminiVarisZaman.Subtract(tahminiKalkisZaman);

            int toplamYolDk = (yolSaat * 60) + yolDakika;
            int ekMolaDk = toplamYolDk / 240;
            int toplamYolSuresiDk = toplamYolDk + (ekMolaDk * 30);

            hesaplananVarisZamani = tahminiKalkisZaman.AddMinutes(toplamYolSuresiDk);

            dteTahminiVarisTarih.Value = hesaplananVarisZamani;
            dteTahminiVarisZaman.Value = hesaplananVarisZamani;
        }

        private void AracRotasiOnayDurumu(bool rotaSecimOnayli)
        {
            for (int i = 0; i < grdAraclar.Rows.Count; i++)
            {
                if (yolKartAracID == grdAraclar.Rows[i].Cells["ARAC_ID"].Value.ToString())
                {
                    grdAraclar.Rows[i].Cells[0].Selected = true;
                }
            }


            if (rotaSecimOnayli)
            {
                tabAracDiger.SelectedIndex = 1;

                lblRotaSecimYapmaUyarisi.Visible = false;

                grdRotaSecimTarifiLoad(yolKartRotaSecimID);
                

                grdRotaSecimleri.Location = new Point(3,6);
                grdRotaSecimleri.Size = new Size(535,159);
                panelRotaSecimOnay.Visible = true;

                btnRotaOnay.Visible = false;
                btnRotaOnayIptal.Visible = true;
                txtKoordinat.Visible = false;
                btnLokasyonGetir.Visible = false;
                lblKoordinatNokta.Visible = false;
                tabLokasyon.Visible = false;
                btnRotaSecenekler.Visible = false;
                lblSecilenYolGuzergahBilgi.Visible = true;
                lblSecilenYolGuzergah.Visible = true;

                lblAracTahminiKalkis.Visible = true;
                lblAracTahminiVaris.Visible = true;

                dteTahminiKalkisTarih.Visible = false;
                dteTahminiKalkisZaman.Visible = false;
                dteTahminiVarisTarih.Visible = false;
                dteTahminiVarisZaman.Visible = false;

                grdAracRotasinaEkliLokasyonlar.Enabled = false;
            }
            else
            {
                btnRotaOnay.Visible = true;
                btnRotaOnayIptal.Visible = false;
                txtKoordinat.Visible = true;
                btnLokasyonGetir.Visible = true;
                lblKoordinatNokta.Visible = true;
                tabLokasyon.Visible = true;
                btnRotaSecenekler.Visible = true;
                lblSecilenYolGuzergahBilgi.Visible = false;
                lblSecilenYolGuzergah.Visible = false;

                lblAracTahminiKalkis.Visible = false;
                lblAracTahminiVaris.Visible = false;

                dteTahminiKalkisTarih.Visible = true;
                dteTahminiKalkisZaman.Visible = true;
                dteTahminiVarisTarih.Visible = true;
                dteTahminiVarisZaman.Visible = true;

                grdAracRotasinaEkliLokasyonlar.Enabled = true;
            }
        }

        private void btnRotaOnayIptal_Click(object sender, EventArgs e)
        {
            if (grdRotaSecimleri.Rows.Count>0)
            {
                ret = Lojistik.YolKartAracRotaSecimOnayla(grdRotaSecimleri.Rows[0].Cells["SECIM_ID"].Value.ToString(), null, null, null, null, null, "IPTAL");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AracRotasiOnayDurumu(false);
                }
            }
            else
            {
                grdAraclar.ClearSelection();

                for (int i = 0; i < grdAraclar.Rows.Count; i++)
                {
                    if (yolKartAracID == grdAraclar.Rows[i].Cells["ID"].Value.ToString())
                    {
                        grdAraclar.Rows[i].Cells[0].Selected = true;
                    }
                }

                ret = Lojistik.YolKartAracRotaSecimOnayla(grdRotaSecimleri.Rows[0].Cells["SECIM_ID"].Value.ToString(), null, null, null, null, null, "IPTAL");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AracRotasiOnayDurumu(false);
                }
            }
        }
        
        private void txtAracNot_TextChanged(object sender, EventArgs e)
        {
            string yolKartArc = grdAraclar.SelectedRows[0].Cells["ID"].Value.ToString();

            ret = Lojistik.YolKartAracNotGuncelle(yolKartArc, txtAracNot.Text);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdAraclar.SelectedRows[0].Cells["ACIKLAMA"].Value = txtAracNot.Text;
            }
        }

        private void grdAracDosyaLoad()
        {
            btnAracDosyaEkle.Visible = true;

            string yolKartAracID = grdAraclar.SelectedRows[0].Cells["ID"].Value.ToString();

            LojistikDesign.DataGrid(grdAracDosya);


            ret = Lojistik.YolKartAracDosyalar(yolKartAracID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdAracDosya.DataSource = Lojistik.dt;


                DataGridViewButtonColumn btnDosyaAc = new DataGridViewButtonColumn();
                btnDosyaAc.Name = "";
                btnDosyaAc.Text = "DOSYA AÇ";
                btnDosyaAc.UseColumnTextForButtonValue = true;
                btnDosyaAc.FillWeight = 15;
                btnDosyaAc.DisplayIndex = 5;
                btnDosyaAc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnDosyaAc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnDosyaAc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn btnDosyaSil = new DataGridViewButtonColumn();
                btnDosyaSil.Name = "";
                btnDosyaSil.Text = "DOSYA SİL";
                btnDosyaSil.UseColumnTextForButtonValue = true;
                btnDosyaSil.FillWeight = 15;
                btnDosyaAc.DisplayIndex = 6;
                btnDosyaSil.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnDosyaSil.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnDosyaSil.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                grdAracDosya.Columns["ID"].Visible = false;
                grdAracDosya.Columns["YOL_KART_ARAC"].Visible = false;
                grdAracDosya.Columns["DOSYA_TIPI"].Visible = false;
                grdAracDosya.Columns["DOSYA_BOYUTU"].Visible = false;

                grdAracDosya.Columns["DOSYA_ADI"].HeaderText = "DOSYA ADI";
                grdAracDosya.Columns["DOSYA_ADI"].FillWeight = 70;
                grdAracDosya.Columns["DOSYA_ADI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAracDosya.Columns["DOSYA_ADI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdAracDosya.Columns["DOSYA_ADI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdAracDosya.Columns.Add(btnDosyaAc);
                grdAracDosya.Columns.Add(btnDosyaSil);
            }

        }
        
        private void btnAracDosyaEkle_Click(object sender, EventArgs e)
        {
            string yolKartAracID = grdAraclar.SelectedRows[0].Cells["ID"].Value.ToString();

            ret = Lojistik.YolKartAracaDosyaEkle(yolKartAracID);
            if (!ret)
            {
                if (Lojistik.hata != "Hatasız")
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                grdAracDosyaLoad();
            }
        }


        private void grdAracDosya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && grdAracDosya.CurrentCell.FormattedValue.ToString() == "DOSYA AÇ")
            {
                try
                {
                    string dosyaID = grdAracDosya.SelectedRows[0].Cells["ID"].Value.ToString();
                    ret = Lojistik.YolKartAracDosyaIcerik(dosyaID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        byte[] dosyaIcerik = (byte[])Lojistik.dt.Rows[0]["DOSYA_ICERIK"];
                        string path = Lojistik.dt.Rows[0]["DOSYA_ADI"].ToString();

                        FileInfo fi = new System.IO.FileInfo(path);
                        FileStream fs = fi.OpenWrite();
                        fs.Write(dosyaIcerik, 0, dosyaIcerik.Length);

                        fs.Close();

                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch
                {
                    MessageBox.Show("Açmaya Çalıştığınız Dosya Kullanılıyor Olabilir. Lütfen Kontrol Ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.RowIndex > -1 && grdAracDosya.CurrentCell.FormattedValue.ToString() == "DOSYA SİL")
            {
                string aracDosyaID = grdAracDosya.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartAracDosyaSil(aracDosyaID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdAracDosyaLoad();
                }
            }
        }
        #endregion

        #region Sürücüler
        private void tabSurucuLoad()
        {
            grdSuruculerLoad(yolKartID);
        }

        private void grdSuruculerLoad(string yolKartID)
        {
            LojistikDesign.DataGrid(grdSuruculer);

            ret = Lojistik.YolKartSurucuListesi(yolKartID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdSuruculer.DataSource = Lojistik.dt;
                
                
                DataGridViewButtonColumn btnSurucuKaldir = new DataGridViewButtonColumn();
                btnSurucuKaldir.Name = "";
                btnSurucuKaldir.Text = "SÜRÜCÜYÜ ÇIKAR";
                btnSurucuKaldir.UseColumnTextForButtonValue = true;
                btnSurucuKaldir.FillWeight = 20;
                btnSurucuKaldir.DisplayIndex = 9;
                btnSurucuKaldir.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnSurucuKaldir.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnSurucuKaldir.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdSuruculer.Columns["ID"].Visible = false;
                grdSuruculer.Columns["SURUCU_ID"].Visible = false;
                grdSuruculer.Columns["ACIKLAMA"].Visible = false;

                grdSuruculer.Columns["SICIL"].HeaderText = "SİCİL";
                grdSuruculer.Columns["SICIL"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSuruculer.Columns["SICIL"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSuruculer.Columns["SICIL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSuruculer.Columns["SICIL"].FillWeight = 10;

                grdSuruculer.Columns["SURUCU_AD_SOYAD"].HeaderText = "SÜRÜCÜ AD SOYAD";
                grdSuruculer.Columns["SURUCU_AD_SOYAD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSuruculer.Columns["SURUCU_AD_SOYAD"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSuruculer.Columns["SURUCU_AD_SOYAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdSuruculer.Columns["SURUCU_AD_SOYAD"].FillWeight = 30;

                grdSuruculer.Columns["KAN_GRUBU"].HeaderText = "KAN GRUBU";
                grdSuruculer.Columns["KAN_GRUBU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSuruculer.Columns["KAN_GRUBU"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSuruculer.Columns["KAN_GRUBU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSuruculer.Columns["KAN_GRUBU"].FillWeight = 10;

                grdSuruculer.Columns.Add(btnSurucuKaldir);

                grdSuruculer.ClearSelection();
            }

        }

        private void grdSurucuSeyirDefteriLoad(string yolKartSurucuID)
        {
            LojistikDesign.DataGrid(grdSurucuSeyirDefteri);

            ret = Lojistik.YolKartSurucuSeyirDefteri(yolKartSurucuID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdSurucuSeyirDefteri.DataSource = Lojistik.dt;

                DataGridViewButtonColumn btnSil = new DataGridViewButtonColumn();
                btnSil.Name = "";
                btnSil.Text = "SİL";
                btnSil.UseColumnTextForButtonValue = true;
                btnSil.FillWeight = 10;
                btnSil.DisplayIndex = 9;
                btnSil.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnSil.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                btnSil.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdSurucuSeyirDefteri.Columns["ID"].Visible = false;
                grdSurucuSeyirDefteri.Columns["YOL_KART_SURUCU"].Visible = false;
                grdSurucuSeyirDefteri.Columns["YOL_KART_ARAC"].Visible = false;

                grdSurucuSeyirDefteri.Columns["PLAKA"].HeaderText = "PLAKA";
                grdSurucuSeyirDefteri.Columns["PLAKA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["PLAKA"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSurucuSeyirDefteri.Columns["PLAKA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["PLAKA"].FillWeight = 10;
                

                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].HeaderText = "DURAKLAMA YAPILAN KM";
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].DefaultCellStyle.Format = "N2";
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_KM"].FillWeight = 15;

                grdSurucuSeyirDefteri.Columns["KONTAK_KAPATILAN_LOKASYON"].HeaderText = "AÇIKLAMA / LOKASYON";
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPATILAN_LOKASYON"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPATILAN_LOKASYON"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPATILAN_LOKASYON"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPATILAN_LOKASYON"].FillWeight = 50;

                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].HeaderText = "VARIŞ ZAMANI";
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                grdSurucuSeyirDefteri.Columns["KONTAK_KAPANIS_ZAMANI"].FillWeight = 15;

                grdSurucuSeyirDefteri.Columns.Add(btnSil);

                grdSurucuSeyirDefteri.ClearSelection();



                if (Lojistik.dt.Rows.Count > 0)
                {
                    cmbYolKartAraclar.SelectedValue = Lojistik.dt.Rows[0]["YOL_KART_ARAC"];
                    btnSurucuyuAracaEkle.Enabled = false;
                    cmbYolKartAraclar.Enabled = false;

                    nudKontakAcilisKm.Maximum = Convert.ToDecimal(grdSurucuSeyirDefteri.Rows[grdSurucuSeyirDefteri.Rows.Count - 1].Cells["KONTAK_KAPANIS_KM"].Value.ToString());
                    nudKontakAcilisKm.Minimum = Convert.ToDecimal(grdSurucuSeyirDefteri.Rows[grdSurucuSeyirDefteri.Rows.Count - 1].Cells["KONTAK_KAPANIS_KM"].Value.ToString());
                    nudKontakAcilisKm.Value = Convert.ToDecimal(grdSurucuSeyirDefteri.Rows[grdSurucuSeyirDefteri.Rows.Count-1].Cells["KONTAK_KAPANIS_KM"].Value.ToString());
                    
                    nudKontakKapanisKm.Minimum = nudKontakAcilisKm.Value + Convert.ToDecimal("0,01");
                }
                else
                {
                    btnSurucuyuAracaEkle.Enabled = true;
                    cmbYolKartAraclar.Enabled = true;
                    
                    nudKontakAcilisKm.Maximum = 0;
                    nudKontakAcilisKm.Minimum = 0;
                    nudKontakAcilisKm.Value = 0;
                }

            }

        }

        private void btnSurucuEkle_Click(object sender, EventArgs e)
        {
            SecimSurucuEkle();
        }

        private void SecimSurucuEkle()
        {
            SecimParametre ac = new SecimParametre("YOL_KARTA_SURUCU_SECIMI", "SÜRÜCÜ LİSTESİ");
            ac.ShowDialog();


            if (!String.IsNullOrWhiteSpace(SecimParametre.secimID) && SecimParametre.secim == "OK")
            {
                ret = Lojistik.YolKartSurucuEkle(yolKartID, SecimParametre.secimID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ret = Lojistik.YolKartSurucuListesi(yolKartID);
                    if (!ret)
                    {
                        MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        grdSuruculerLoad(yolKartID);

                        for (int i = 0; i < grdSuruculer.Rows.Count; i++)
                        {
                            if (SecimParametre.secimID == grdSuruculer.Rows[i].Cells["SURUCU_ID"].Value.ToString())
                            {
                                grdSuruculer.Rows[i].Cells[0].Selected = true;
                            }
                        }

                    }
                }
            }
        }
        
        private void grdSuruculer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            bool validClick = (e.RowIndex != -1 && e.ColumnIndex != -1); //Make sure the clicked row/column is valid.
            var datagridview = sender as DataGridView;

            // Check to make sure the cell clicked is the cell containing the combobox 
            if (datagridview.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && validClick)
            {
                datagridview.BeginEdit(true);
                ((ComboBox)datagridview.EditingControl).DroppedDown = true;
            }
        }

        private void grdSuruculer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && grdSuruculer.CurrentCell.FormattedValue.ToString() == "SÜRÜCÜYÜ ÇIKAR")
            {
                string yolKartSurucuID = grdSuruculer.SelectedRows[0].Cells["ID"].Value.ToString();
                ret = Lojistik.YolKartSurucuyuSil(yolKartSurucuID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabSurucuLoad();
                    lblSurucuBilgi.Text = "";
                    txtSurucuNot.Visible = false;
                    grdSurucuSeyirDefteriLoad(yolKartSurucuID);
                }
            }
        }

        private void grdSuruculer_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSuruculer.SelectedRows.Count > 0)
            {
                txtSurucuNot.Visible = true;
                string yolKartSurucuID = grdSuruculer.SelectedRows[0].Cells["ID"].Value.ToString();
                lblSurucuBilgi.Text = grdSuruculer.SelectedRows[0].Cells["SURUCU_AD_SOYAD"].Value.ToString();
                txtSurucuNot.Text = grdSuruculer.SelectedRows[0].Cells["ACIKLAMA"].Value.ToString();

                ret = Lojistik.YolKartSurucuyeAracSorgula(yolKartID);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmbYolKartAraclar.DataSource = Lojistik.dt;
                    cmbYolKartAraclar.ValueMember = "YOL_KART_ARAC_ID";
                    cmbYolKartAraclar.DisplayMember = "PLAKA";
                }

                grdSurucuSeyirDefteriLoad(yolKartSurucuID);


                //grdSurucuDosyaLoad();

            }
        }
        
        private void btnGuzergahGor_Click(object sender, EventArgs e)
        {
            if (cmbYolKartAraclar.SelectedIndex>-1)
            {
                AracRotaDosyasiAc(cmbYolKartAraclar.Text);
            }
        }

        private void cmbYolKartAraclar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbYolKartAraclar.SelectedIndex > -1)
            {
                ret = Lojistik.YolKartAracRotaSecimOnaySorgula(cmbYolKartAraclar.SelectedValue.ToString());
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Lojistik.dt.Rows.Count > 0)
                    {
                        yolKartRotaSecimID = Lojistik.dt.Rows[0]["YOL_KART_ROTA_SECIM_ID"].ToString();
                        txtAracYolGuzergahAciklamasi.Text = Lojistik.dt.Rows[0]["ACIKLAMA"].ToString();
                        lblAracTahminiKalkis2.Text = Lojistik.dt.Rows[0]["TAHMINI_KALKIS"].ToString();
                        lblAracTahminiVaris2.Text = Lojistik.dt.Rows[0]["TAHMINI_VARIS"].ToString();
                        txtKalkisKm2.Text = Convert.ToDecimal(Lojistik.dt.Rows[0]["CIKIS_KM"].ToString()).ToString("N2");
                        txtVarisKm2.Text = Convert.ToDecimal(Lojistik.dt.Rows[0]["VARIS_KM"].ToString()).ToString("N2");
                        nudGuzergahToplamKm.Maximum = Convert.ToDecimal(Lojistik.dt.Rows[0]["KM"].ToString());
                        nudGuzergahToplamKm.Minimum = Convert.ToDecimal(Lojistik.dt.Rows[0]["KM"].ToString());
                        nudGuzergahToplamKm.Value = Convert.ToDecimal(Lojistik.dt.Rows[0]["KM"].ToString());
                    }
                }
            }
            else
            {
                txtAracYolGuzergahAciklamasi.Text = "";
                lblAracTahminiKalkis2.Text = "";
                lblAracTahminiVaris2.Text = "";
                txtKalkisKm2.Text = "";
                txtVarisKm2.Text = "";
                nudGuzergahToplamKm.Maximum = 0;
                nudGuzergahToplamKm.Minimum = 0;
                nudGuzergahToplamKm.Value = 0;
            }
        }

        private void cmbYolKartAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudKontakKapanisKm.Maximum = nudGuzergahToplamKm.Value;
            nudKontakKapanisKm.Value = nudGuzergahToplamKm.Value;
        }

        private void btnGuzergahiGor_Click(object sender, EventArgs e)
        {
            if (cmbYolKartAraclar.SelectedIndex > -1)
            {
                AracRotaDosyasiAc(cmbYolKartAraclar.Text);
            }
        }

        private void btnSurucuyuAracaEkle_Click(object sender, EventArgs e)
        {
            if (grdSuruculer.SelectedRows.Count>0)
            {
                string yolKartSurucuID = grdSuruculer.SelectedRows[0].Cells["ID"].Value.ToString();
                string yolKartAracID = cmbYolKartAraclar.SelectedValue.ToString();
                
                ret = Lojistik.YolKartAracSurucusuEkle(yolKartSurucuID, yolKartAracID, yolKartRotaSecimID,0,null,"SÜRÜCÜNÜN ARAÇLA HAREKET KAYDI");
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdSurucuSeyirDefteriLoad(yolKartSurucuID);
                }
            }
            
        }
        #endregion

        private void btnSurucuDurusEkle_Click(object sender, EventArgs e)
        {
            if (grdSuruculer.SelectedRows.Count > 0)
            {
                string yolKartSurucuID = grdSuruculer.SelectedRows[0].Cells["ID"].Value.ToString();
                string yolKartAracID = cmbYolKartAraclar.SelectedValue.ToString();
                DateTime kontakKapamaZamani = Convert.ToDateTime(dteKontakKapatmaTarihi.Value.ToShortDateString() + " " + dteKontakKapatmaZamani.Value.ToLongTimeString());

                ret = Lojistik.YolKartAracSurucusuEkle(yolKartSurucuID, yolKartAracID, yolKartRotaSecimID, nudKontakKapanisKm.Value, kontakKapamaZamani, txtDuraklamaLokasyon.Text);
                if (!ret)
                {
                    MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    grdSurucuSeyirDefteriLoad(yolKartSurucuID);
                }
            }
        }
    }
}
