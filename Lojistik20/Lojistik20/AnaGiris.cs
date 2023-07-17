using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lojistik20
{
    public partial class AnaGiris : Form
    {
        bool formTasiniyor = false;
        Point baslangicNoktasi = new Point(0, 0);

        bool ret;

        public AnaGiris()
        {
            InitializeComponent();
        }

        private void AnaGiris_Load(object sender, EventArgs e)
        {
            VersiyonKontrol();
        }

        private void VersiyonKontrol()
        {

            ret = Lojistik.VersiyonGetir();
            if (!ret)
            {
                MessageBox.Show(Dinamik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ret = Dinamik.VersiyonKontrol(Lojistik.dt.Rows[0].ItemArray[0].ToString());
                if (!ret)
                {
                    MessageBox.Show(Dinamik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Dinamik.dt.Rows.Count > 0)
                    {
                        string mevcutVersiyon = Lojistik.dt.Rows[0].ItemArray[1].ToString();
                        string guncelVersiyon = Dinamik.dt.Rows[0].ItemArray[1].ToString();

                        if (mevcutVersiyon != guncelVersiyon)
                        {
                            byte[] dosyaIcerik = (byte[])Dinamik.dt.Rows[0]["DOSYA_ICERIK"];
                            string path = Dinamik.dt.Rows[0]["DOSYA_ADI"].ToString();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void AnaGiris_MouseDown(object sender, MouseEventArgs e)
        {
            formTasiniyor = true;
            baslangicNoktasi = new Point(e.X, e.Y);
        }

        private void AnaGiris_MouseUp(object sender, MouseEventArgs e)
        {
            formTasiniyor = false;
        }

        private void AnaGiris_MouseMove(object sender, MouseEventArgs e)
        {
            if (formTasiniyor)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.baslangicNoktasi.X, p.Y - this.baslangicNoktasi.Y);
            }
        }

        private void AnaGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Application.Exit();
            }
            
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {

            this.Hide();

            IsEmirleri ac = new IsEmirleri();
            ac.ShowDialog();

        }

        private void AnaGiris_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D)
            {
                ret = Dinamik.YeniVersiyonDosyasiEkle();
                if (!ret)
                {
                    if (Dinamik.hata != "Hatasız")
                    {
                        MessageBox.Show(Dinamik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("DOSYA BAŞARIYLA YÜKLENDİ");
                }
            }
        }
    }
}
