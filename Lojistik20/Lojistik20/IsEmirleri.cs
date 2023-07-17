using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lojistik20
{
    public partial class IsEmirleri : Form
    {
        bool ret;

        public IsEmirleri()
        {
            InitializeComponent();
        }
        
        private void IsEmirleri_Load(object sender, EventArgs e)
        {
            grdIsEmirleriLoad();
        }

        public void grdIsEmirleriLoad()
        {
            LojistikDesign.DataGrid(grdIsEmirleri);

            ret = Lojistik.IsEmriListesi();
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata,"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                grdIsEmirleri.DataSource = Lojistik.dt;

                grdIsEmirleri.Columns["ID"].Visible = false;

                grdIsEmirleri.Columns["IS_EMRI_NO"].HeaderText = "İŞ EMRİ NO";
                grdIsEmirleri.Columns["IS_EMRI_NO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdIsEmirleri.Columns["IS_EMRI_NO"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdIsEmirleri.Columns["IS_EMRI_NO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdIsEmirleri.Columns["ACIKLAMA"].HeaderText = "AÇIKLAMA";
                grdIsEmirleri.Columns["ACIKLAMA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdIsEmirleri.Columns["ACIKLAMA"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdIsEmirleri.Columns["ACIKLAMA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                grdIsEmirleri.Columns["DIGER"].HeaderText = "DİĞER";
                grdIsEmirleri.Columns["DIGER"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdIsEmirleri.Columns["DIGER"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdIsEmirleri.Columns["DIGER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                
                grdIsEmirleri.ClearSelection();
            }
            
        }

        private void btnIsEmriOlustur_Click(object sender, EventArgs e)
        {
            string sirketKisaAd= Lojistik.sirketKisaAd;
            string aciklama = txtAciklama.Text;
            ret = Lojistik.IsEmirleri("INSERT", null, sirketKisaAd, aciklama);
            if (!ret)
            {
                MessageBox.Show(Lojistik.hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("İş Emri Kaydı Açıldı","ONAY", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                grdIsEmirleriLoad();
            }
        }

        private void grdIsEmirleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                string ID = grdIsEmirleri.SelectedRows[0].Cells["ID"].Value.ToString();
                string isemriNo = grdIsEmirleri.SelectedRows[0].Cells["IS_EMRI_NO"].Value.ToString();
                string aciklama = grdIsEmirleri.SelectedRows[0].Cells["ACIKLAMA"].Value.ToString();

                IsEmriDetayi ac = new IsEmriDetayi(ID, isemriNo, aciklama);
                ac.ShowDialog();
            }
            
        }

        private void IsEmirleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
