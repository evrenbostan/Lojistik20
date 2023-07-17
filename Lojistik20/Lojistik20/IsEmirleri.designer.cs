namespace Lojistik20
{
    partial class IsEmirleri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsEmirleri));
            this.grdIsEmirleri = new System.Windows.Forms.DataGridView();
            this.txtAciklama = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnAcik = new System.Windows.Forms.RadioButton();
            this.rBtnKapali = new System.Windows.Forms.RadioButton();
            this.rBtnTumu = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbxYeniIsEmri = new System.Windows.Forms.GroupBox();
            this.btnIsEmriOlustur = new System.Windows.Forms.Button();
            this.gbxSorgu = new System.Windows.Forms.GroupBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.panelUstBilgi = new System.Windows.Forms.Panel();
            this.panelBilgi = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdIsEmirleri)).BeginInit();
            this.gbxYeniIsEmri.SuspendLayout();
            this.gbxSorgu.SuspendLayout();
            this.panelUstBilgi.SuspendLayout();
            this.panelBilgi.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIsEmirleri
            // 
            this.grdIsEmirleri.AllowUserToAddRows = false;
            this.grdIsEmirleri.AllowUserToDeleteRows = false;
            this.grdIsEmirleri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdIsEmirleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIsEmirleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIsEmirleri.Location = new System.Drawing.Point(0, 0);
            this.grdIsEmirleri.Name = "grdIsEmirleri";
            this.grdIsEmirleri.ReadOnly = true;
            this.grdIsEmirleri.Size = new System.Drawing.Size(875, 355);
            this.grdIsEmirleri.TabIndex = 0;
            this.grdIsEmirleri.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdIsEmirleri_CellDoubleClick);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(97, 23);
            this.txtAciklama.MaxLength = 150;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(310, 91);
            this.txtAciklama.TabIndex = 1;
            this.txtAciklama.Text = "";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "AÇIKLAMA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtnAcik
            // 
            this.rbtnAcik.AutoSize = true;
            this.rbtnAcik.Location = new System.Drawing.Point(6, 22);
            this.rbtnAcik.Name = "rbtnAcik";
            this.rbtnAcik.Size = new System.Drawing.Size(110, 21);
            this.rbtnAcik.TabIndex = 8;
            this.rbtnAcik.Text = "Açık İş Emirleri";
            this.rbtnAcik.UseVisualStyleBackColor = true;
            // 
            // rBtnKapali
            // 
            this.rBtnKapali.AutoSize = true;
            this.rBtnKapali.Location = new System.Drawing.Point(6, 44);
            this.rBtnKapali.Name = "rBtnKapali";
            this.rBtnKapali.Size = new System.Drawing.Size(123, 21);
            this.rBtnKapali.TabIndex = 9;
            this.rBtnKapali.Text = "Kapalı İş Emirleri";
            this.rBtnKapali.UseVisualStyleBackColor = true;
            // 
            // rBtnTumu
            // 
            this.rBtnTumu.AutoSize = true;
            this.rBtnTumu.Checked = true;
            this.rBtnTumu.Location = new System.Drawing.Point(6, 64);
            this.rBtnTumu.Name = "rBtnTumu";
            this.rBtnTumu.Size = new System.Drawing.Size(112, 21);
            this.rBtnTumu.TabIndex = 10;
            this.rBtnTumu.TabStop = true;
            this.rBtnTumu.Text = "Tüm İş Emirleri";
            this.rBtnTumu.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(7, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "AÇIKLAMA:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 25);
            this.textBox1.TabIndex = 12;
            // 
            // gbxYeniIsEmri
            // 
            this.gbxYeniIsEmri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxYeniIsEmri.Controls.Add(this.label2);
            this.gbxYeniIsEmri.Controls.Add(this.btnIsEmriOlustur);
            this.gbxYeniIsEmri.Controls.Add(this.txtAciklama);
            this.gbxYeniIsEmri.Location = new System.Drawing.Point(450, 12);
            this.gbxYeniIsEmri.Name = "gbxYeniIsEmri";
            this.gbxYeniIsEmri.Size = new System.Drawing.Size(413, 150);
            this.gbxYeniIsEmri.TabIndex = 0;
            this.gbxYeniIsEmri.TabStop = false;
            this.gbxYeniIsEmri.Text = "YENİ İŞ EMRİ OLUŞTUR";
            // 
            // btnIsEmriOlustur
            // 
            this.btnIsEmriOlustur.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIsEmriOlustur.Image = global::Lojistik20.Properties.Resources.save;
            this.btnIsEmriOlustur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIsEmriOlustur.Location = new System.Drawing.Point(253, 114);
            this.btnIsEmriOlustur.Name = "btnIsEmriOlustur";
            this.btnIsEmriOlustur.Size = new System.Drawing.Size(154, 35);
            this.btnIsEmriOlustur.TabIndex = 2;
            this.btnIsEmriOlustur.Text = "YENİ İŞ EMRİ AÇ";
            this.btnIsEmriOlustur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIsEmriOlustur.UseVisualStyleBackColor = true;
            this.btnIsEmriOlustur.Click += new System.EventHandler(this.btnIsEmriOlustur_Click);
            // 
            // gbxSorgu
            // 
            this.gbxSorgu.Controls.Add(this.rbtnAcik);
            this.gbxSorgu.Controls.Add(this.btnAra);
            this.gbxSorgu.Controls.Add(this.rBtnKapali);
            this.gbxSorgu.Controls.Add(this.rBtnTumu);
            this.gbxSorgu.Controls.Add(this.label3);
            this.gbxSorgu.Controls.Add(this.textBox1);
            this.gbxSorgu.Location = new System.Drawing.Point(12, 12);
            this.gbxSorgu.Name = "gbxSorgu";
            this.gbxSorgu.Size = new System.Drawing.Size(438, 150);
            this.gbxSorgu.TabIndex = 1;
            this.gbxSorgu.TabStop = false;
            this.gbxSorgu.Text = "İŞ EMRİ SORGULA";
            // 
            // btnAra
            // 
            this.btnAra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Image = global::Lojistik20.Properties.Resources.search;
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.Location = new System.Drawing.Point(369, 116);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(66, 28);
            this.btnAra.TabIndex = 19;
            this.btnAra.Text = "ARA";
            this.btnAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // panelUstBilgi
            // 
            this.panelUstBilgi.BackgroundImage = global::Lojistik20.Properties.Resources.dts_logo;
            this.panelUstBilgi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelUstBilgi.Controls.Add(this.gbxYeniIsEmri);
            this.panelUstBilgi.Controls.Add(this.gbxSorgu);
            this.panelUstBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUstBilgi.Location = new System.Drawing.Point(0, 0);
            this.panelUstBilgi.Name = "panelUstBilgi";
            this.panelUstBilgi.Size = new System.Drawing.Size(875, 174);
            this.panelUstBilgi.TabIndex = 0;
            // 
            // panelBilgi
            // 
            this.panelBilgi.Controls.Add(this.grdIsEmirleri);
            this.panelBilgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBilgi.Location = new System.Drawing.Point(0, 174);
            this.panelBilgi.Name = "panelBilgi";
            this.panelBilgi.Size = new System.Drawing.Size(875, 355);
            this.panelBilgi.TabIndex = 10;
            // 
            // IsEmirleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(875, 529);
            this.Controls.Add(this.panelBilgi);
            this.Controls.Add(this.panelUstBilgi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IsEmirleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Emirleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsEmirleri_FormClosing);
            this.Load += new System.EventHandler(this.IsEmirleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIsEmirleri)).EndInit();
            this.gbxYeniIsEmri.ResumeLayout(false);
            this.gbxSorgu.ResumeLayout(false);
            this.gbxSorgu.PerformLayout();
            this.panelUstBilgi.ResumeLayout(false);
            this.panelBilgi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdIsEmirleri;
        private System.Windows.Forms.Button btnIsEmriOlustur;
        private System.Windows.Forms.RichTextBox txtAciklama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnAcik;
        private System.Windows.Forms.RadioButton rBtnKapali;
        private System.Windows.Forms.RadioButton rBtnTumu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbxYeniIsEmri;
        private System.Windows.Forms.GroupBox gbxSorgu;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Panel panelUstBilgi;
        private System.Windows.Forms.Panel panelBilgi;
    }
}