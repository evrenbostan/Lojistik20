using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lojistik20
{
    public partial class SecimParametre : Form
    {
        bool ret;
        string liste = "";
        public static string secimID = "";
        public static string secim ="";

        public SecimParametre(string listeAdi, string formAdi)
        {
            InitializeComponent();
            this.Text = formAdi;
            liste = listeAdi;
        }

        private void SecimParametre_Load(object sender, EventArgs e)
        {
            grdSecimlistesiLoad();
        }
        
        private void grdSecimlistesiLoad()
        {
            LojistikDesign.DataGrid(grdSecimListesi);

            ret = Lojistik.ParametrikListeler(liste);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                grdSecimListesi.DataSource = Lojistik.dt;

                grdSecimListesi.Columns["ID"].Visible = false;

                if (grdSecimListesi.Columns[1].Name == "CARI_UNVAN")
                {
                    grdSecimListesi.Columns["CARI_UNVAN"].HeaderText = "CARİ UNVANI";
                    grdSecimListesi.Columns["CARI_UNVAN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdSecimListesi.Columns["CARI_UNVAN"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    grdSecimListesi.Columns["CARI_UNVAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

            }

            grdSecimListesi.ClearSelection();
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            AramaKolon(liste);
        }
        
        private void btnSecim_Click(object sender, EventArgs e)
        {
            SecimVerisi();
        }
        
        private void grdSecimListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SecimVerisi();
        }
        
        public void SecimVerisi()
        {
            if (grdSecimListesi.SelectedRows.Count > 0)
            {
                secim = "OK";
                secimID = grdSecimListesi.SelectedRows[0].Cells["ID"].Value.ToString();
                this.Close();
            }
        }


        private void AramaKolon(string aramaKriteri)
        {
            DataView dv = Lojistik.dt.DefaultView;

            switch (aramaKriteri)
            {
                case "CARI_LISTESI":
                    dv.RowFilter = "[CARİ ÜNVAN] LIKE '%" + txtAra.Text + "%'";
                    grdSecimListesi.DataSource = dv;
                    break;
                case "YOL_KARTA_ARAC_SECIMI":
                    dv.RowFilter = "PLAKA LIKE '%" + txtAra.Text + "%' or " +
                                   "ARAC_TIPI LIKE '%" + txtAra.Text + "%' or " +
                                   "ULKE LIKE '%" + txtAra.Text + "%' or " +
                                   "SEHIR LIKE '%" + txtAra.Text + "%' or " +
                                   "ILCE LIKE '%" + txtAra.Text + "%'  or " +
                                   "BOLGE LIKE '%" + txtAra.Text + "%'  or " +
                                   "CAD_SOK_KAPI LIKE '%" + txtAra.Text + "%'  or " +
                                   "LOKASYON_TANIMI LIKE '%" + txtAra.Text + "%'";
                                   
                    grdSecimListesi.DataSource = dv;
                    break;
            }
        }

        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            secim = "YOK";
            this.Close();
        }
    }
}
