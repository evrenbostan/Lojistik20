using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lojistik20
{
    public partial class IsEmriDetayi : Form
    {

        string isEmri;
        string isEmriID;

        bool ret;

        public IsEmriDetayi(string ID, string isEmriNo, string aciklama)
        {
            InitializeComponent();

            this.Text = isEmriNo + " NUMARALI İŞ EMRİNE AİT YOL KARTLARI";
            isEmri = isEmriNo;
            txtAciklama.Text = aciklama;

            isEmriID = ID;
        }
        
        private void IsEmriDetayi_Load(object sender, EventArgs e)
        {
            YolKartGetir(true);
        }
        
        private void btnYeniYolKartAc_Click(object sender, EventArgs e)
        {
            ret = Lojistik.YolKartEkle(isEmriID, null);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                YolKartGetir(false);
            }
        }

        private void YolKartGetir(bool yolKartGetir)
        {
            flowKartlar.Controls.Clear();

            ret = Lojistik.IsEmrineBagliYolKartlar(isEmriID);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataRow dr in Lojistik.dt.Rows)
                {

                    YolKartNesneOlustur(dr);
                }
            }
        }
        

        private void YolKartNesneOlustur(DataRow dr)
        {
            //GRUP NESNE
            GroupBox grbYolKart = new GroupBox();
            grbYolKart.Name = dr["ID"].ToString();
            grbYolKart.Location = new Point(10, 40);
            grbYolKart.Size = new Size(471, 235);
            grbYolKart.Font = new Font(Font, FontStyle.Bold);
            grbYolKart.Text = isEmri + " - " + dr["SIRA_NO"].ToString() + " NO'LU YOL KARTI";
            grbYolKart.BackColor = SystemColors.Menu;

            //LABEL NESNE
            Label lblKalkisBilgisi = new Label();
            lblKalkisBilgisi.Name = dr["ID"].ToString();
            lblKalkisBilgisi.Size = new Size(61, 25);
            lblKalkisBilgisi.Location = new Point(16, 59);
            lblKalkisBilgisi.BorderStyle = BorderStyle.FixedSingle;
            lblKalkisBilgisi.Font = new Font(Font, FontStyle.Bold);
            lblKalkisBilgisi.Text = "KALKIŞ";
            lblKalkisBilgisi.TextAlign = ContentAlignment.MiddleRight;

            Label lblVarisBilgisi = new Label();
            lblVarisBilgisi.Name = dr["ID"].ToString();
            lblVarisBilgisi.Size = new Size(61, 25);
            lblVarisBilgisi.Location = new Point(287, 59);
            lblVarisBilgisi.BorderStyle = BorderStyle.FixedSingle;
            lblVarisBilgisi.Font = new Font(Font, FontStyle.Bold);
            lblVarisBilgisi.Text = "VARIŞ";
            lblVarisBilgisi.TextAlign = ContentAlignment.MiddleRight;

            Label lblKalkisLokasyon = new Label();
            lblKalkisLokasyon.Name = dr["ID"].ToString();
            lblKalkisLokasyon.Size = new Size(165, 145);
            lblKalkisLokasyon.Location = new Point(16, 85);
            lblKalkisLokasyon.BorderStyle = BorderStyle.FixedSingle;
            lblKalkisLokasyon.Font = new Font(Font, FontStyle.Bold);
            lblKalkisLokasyon.Text = "KALKIŞ LOKASYON";
            lblKalkisLokasyon.TextAlign = ContentAlignment.TopLeft;

            Label lblVarisLokasyon = new Label();
            lblVarisLokasyon.Name = dr["ID"].ToString();
            lblVarisLokasyon.Size = new Size(165, 145);
            lblVarisLokasyon.Location = new Point(287, 85);
            lblVarisLokasyon.BorderStyle = BorderStyle.FixedSingle;
            lblVarisLokasyon.Font = new Font(Font, FontStyle.Bold);
            lblVarisLokasyon.Text = "VARIŞ LOKASYON";
            lblVarisLokasyon.TextAlign = ContentAlignment.BottomRight;

            Label lblMesafe = new Label();
            lblMesafe.Name = dr["ID"].ToString();
            lblMesafe.Size = new Size(95, 25);
            lblMesafe.Location = new Point(186, 59);
            lblMesafe.BorderStyle = BorderStyle.FixedSingle;
            lblMesafe.Font = new Font(Font, FontStyle.Bold);
            lblMesafe.Text = "< .... KM >";
            lblMesafe.TextAlign = ContentAlignment.MiddleCenter;

            //MASKTEXT NESNE
            MaskedTextBox masktxtKalkisZaman = new MaskedTextBox();
            masktxtKalkisZaman.Name = dr["ID"].ToString();
            masktxtKalkisZaman.Size = new Size(98, 25);
            masktxtKalkisZaman.Location = new Point(84, 59);
            masktxtKalkisZaman.Mask = "00/00/0000 90:00";

            MaskedTextBox masktxtVarisZaman = new MaskedTextBox();
            masktxtVarisZaman.Name = dr["ID"].ToString();
            masktxtVarisZaman.Size = new Size(98, 25);
            masktxtVarisZaman.Location = new Point(354, 59);
            masktxtVarisZaman.Mask = "00/00/0000 90:00";


            //GÖRSEL NESNE
            PictureBox pbxArac = new PictureBox();
            pbxArac.Name = dr["ID"].ToString();
            pbxArac.Size = new Size(95, 70);
            pbxArac.Location = new Point(186, 85);
            pbxArac.SizeMode = PictureBoxSizeMode.Zoom;
            pbxArac.Image = Lojistik20.Properties.Resources.kamyonet;
            pbxArac.SendToBack();
            pbxArac.Click += PbxArac_Click;

            PictureBox pbxLogo = new PictureBox();
            pbxLogo.Name = dr["ID"].ToString();
            pbxLogo.Size = new Size(50, 20);
            pbxLogo.Location = new Point(1, 20);
            pbxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbxLogo.Image = Lojistik20.Properties.Resources.dts_logo;

            PictureBox pbxGuzergah = new PictureBox();
            pbxGuzergah.Name = dr["ID"].ToString();
            pbxGuzergah.Size = new Size(95, 70);
            pbxGuzergah.Location = new Point(186, 161);
            pbxGuzergah.SizeMode = PictureBoxSizeMode.Zoom;
            pbxGuzergah.Image = Lojistik20.Properties.Resources.map_icons_closeup;


            //MENÜ
            MenuStrip msYolMenu = new MenuStrip();
            msYolMenu.Name = dr["ID"].ToString();


            ToolStripMenuItem menuMusteri = new ToolStripMenuItem("MÜŞTERİ");
            menuMusteri.Name = dr["ID"].ToString();
            menuMusteri.Image = Lojistik20.Properties.Resources.chart_icon;
            menuMusteri.Click += MenuMusteri_Click;

            ToolStripMenuItem menuArac = new ToolStripMenuItem("ARAÇ");
            menuArac.Name = dr["ID"].ToString();
            menuArac.Image = Lojistik20.Properties.Resources.Dura_Truck32_blue_icon;
            menuArac.Click += MenuArac_Click;

            ToolStripMenuItem menuSurucu = new ToolStripMenuItem("SÜRÜCÜ");
            menuSurucu.Name = dr["ID"].ToString();
            menuSurucu.Image = Lojistik20.Properties.Resources.Transport_Driver_icon;
            menuSurucu.Click += MenuSurucu_Click;

            ToolStripMenuItem menuYukleme = new ToolStripMenuItem("YÜK");
            menuYukleme.Name = dr["ID"].ToString();
            menuYukleme.Image = Lojistik20.Properties.Resources.forklift_icon24;
            menuYukleme.Click += MenuYukleme_Click;

            ToolStripMenuItem menuFinans = new ToolStripMenuItem("FİNANS");
            menuFinans.Name = dr["ID"].ToString();
            menuFinans.Image = Lojistik20.Properties.Resources.Cash_register32icon;
            menuFinans.Click += MenuFinans_Click;

            ToolStripMenuItem menuRota = new ToolStripMenuItem("ROTA");
            menuRota.Name = dr["ID"].ToString();
            menuRota.Image = Lojistik20.Properties.Resources.maps_icon;
            menuRota.Click += MenuRota_Click;

            msYolMenu.Items.Add(menuMusteri);
            msYolMenu.Items.Add(menuArac);
            msYolMenu.Items.Add(menuSurucu);
            msYolMenu.Items.Add(menuYukleme);
            msYolMenu.Items.Add(menuFinans);
            msYolMenu.Items.Add(menuRota);
            msYolMenu.Dock = DockStyle.Top;
            msYolMenu.BackColor = SystemColors.ActiveCaption;
            MainMenuStrip = msYolMenu;


            //GRUBU PANELE DAHİL ETME
            flowKartlar.Controls.Add(grbYolKart);

            //GRUP İÇİNE NESNE ALMA
            grbYolKart.Controls.Add(msYolMenu);
            grbYolKart.Controls.Add(lblKalkisBilgisi);
            grbYolKart.Controls.Add(masktxtKalkisZaman);
            grbYolKart.Controls.Add(lblKalkisLokasyon);
            grbYolKart.Controls.Add(lblMesafe);
            grbYolKart.Controls.Add(lblVarisBilgisi);
            grbYolKart.Controls.Add(masktxtVarisZaman);
            grbYolKart.Controls.Add(lblVarisLokasyon);
            grbYolKart.Controls.Add(pbxArac);
            grbYolKart.Controls.Add(pbxGuzergah);

            //GÖRSEL İÇİNE LOGO ALMA
            pbxArac.Controls.Add(pbxLogo);
        }
        
        private void MenuMusteri_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("MÜŞTERİ", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }
        
        private void MenuArac_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("ARAÇ", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }

        private void MenuSurucu_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("SÜRÜCÜ", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }

        private void MenuYukleme_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("YÜK", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }

        private void MenuFinans_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("FİNANS", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }

        private void MenuRota_Click(object sender, EventArgs e)
        {
            string kartBaslik = ((System.Windows.Forms.Control.ControlAccessibleObject)((System.Windows.Forms.ToolStripItem.ToolStripItemAccessibleObject)((System.Windows.Forms.ToolStripItem)sender).AccessibilityObject).Parent).Parent.Parent.Name;

            YolKart ac = new YolKart("ROTA", (sender as ToolStripMenuItem).Name, kartBaslik);
            ac.ShowDialog();
        }

        private void PbxArac_Click(object sender, EventArgs e)
        {
            string name = (sender as PictureBox).Name;
            MessageBox.Show(name);
        }

    }
}
