namespace Lojistik20
{
    partial class IsEmriDetayi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsEmriDetayi));
            this.panelBilgi = new System.Windows.Forms.Panel();
            this.flowKartlar = new System.Windows.Forms.FlowLayoutPanel();
            this.panelUstBilgi = new System.Windows.Forms.Panel();
            this.gbxYeniIsEmri = new System.Windows.Forms.GroupBox();
            this.btnYeniYolKartAc = new System.Windows.Forms.Button();
            this.lblNotlar = new System.Windows.Forms.Label();
            this.btnNotuGuncelle = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.RichTextBox();
            this.panelBilgi.SuspendLayout();
            this.panelUstBilgi.SuspendLayout();
            this.gbxYeniIsEmri.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBilgi
            // 
            this.panelBilgi.Controls.Add(this.flowKartlar);
            this.panelBilgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBilgi.Location = new System.Drawing.Point(0, 160);
            this.panelBilgi.Name = "panelBilgi";
            this.panelBilgi.Size = new System.Drawing.Size(1350, 551);
            this.panelBilgi.TabIndex = 12;
            // 
            // flowKartlar
            // 
            this.flowKartlar.AutoScroll = true;
            this.flowKartlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowKartlar.Location = new System.Drawing.Point(0, 0);
            this.flowKartlar.Name = "flowKartlar";
            this.flowKartlar.Size = new System.Drawing.Size(1350, 551);
            this.flowKartlar.TabIndex = 0;
            // 
            // panelUstBilgi
            // 
            this.panelUstBilgi.BackgroundImage = global::Lojistik20.Properties.Resources.dts_logo;
            this.panelUstBilgi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelUstBilgi.Controls.Add(this.gbxYeniIsEmri);
            this.panelUstBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUstBilgi.Location = new System.Drawing.Point(0, 0);
            this.panelUstBilgi.Name = "panelUstBilgi";
            this.panelUstBilgi.Size = new System.Drawing.Size(1350, 160);
            this.panelUstBilgi.TabIndex = 11;
            // 
            // gbxYeniIsEmri
            // 
            this.gbxYeniIsEmri.Controls.Add(this.btnYeniYolKartAc);
            this.gbxYeniIsEmri.Controls.Add(this.lblNotlar);
            this.gbxYeniIsEmri.Controls.Add(this.btnNotuGuncelle);
            this.gbxYeniIsEmri.Controls.Add(this.txtAciklama);
            this.gbxYeniIsEmri.Location = new System.Drawing.Point(6, 4);
            this.gbxYeniIsEmri.Name = "gbxYeniIsEmri";
            this.gbxYeniIsEmri.Size = new System.Drawing.Size(392, 150);
            this.gbxYeniIsEmri.TabIndex = 55;
            this.gbxYeniIsEmri.TabStop = false;
            this.gbxYeniIsEmri.Text = "YENİ İŞ EMRİ OLUŞTUR";
            // 
            // btnYeniYolKartAc
            // 
            this.btnYeniYolKartAc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniYolKartAc.Image = global::Lojistik20.Properties.Resources.Place_selection_icon;
            this.btnYeniYolKartAc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYeniYolKartAc.Location = new System.Drawing.Point(235, 113);
            this.btnYeniYolKartAc.Name = "btnYeniYolKartAc";
            this.btnYeniYolKartAc.Size = new System.Drawing.Size(153, 35);
            this.btnYeniYolKartAc.TabIndex = 56;
            this.btnYeniYolKartAc.Text = "YENİ YOL KARTI AÇ";
            this.btnYeniYolKartAc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYeniYolKartAc.UseVisualStyleBackColor = true;
            this.btnYeniYolKartAc.Click += new System.EventHandler(this.btnYeniYolKartAc_Click);
            // 
            // lblNotlar
            // 
            this.lblNotlar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotlar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNotlar.Location = new System.Drawing.Point(6, 52);
            this.lblNotlar.Name = "lblNotlar";
            this.lblNotlar.Size = new System.Drawing.Size(68, 25);
            this.lblNotlar.TabIndex = 7;
            this.lblNotlar.Text = "NOTLAR:";
            this.lblNotlar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNotuGuncelle
            // 
            this.btnNotuGuncelle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNotuGuncelle.Image = global::Lojistik20.Properties.Resources.save;
            this.btnNotuGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNotuGuncelle.Location = new System.Drawing.Point(80, 113);
            this.btnNotuGuncelle.Name = "btnNotuGuncelle";
            this.btnNotuGuncelle.Size = new System.Drawing.Size(147, 35);
            this.btnNotuGuncelle.TabIndex = 2;
            this.btnNotuGuncelle.Text = "NOTU GÜNCELLE";
            this.btnNotuGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNotuGuncelle.UseVisualStyleBackColor = true;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(80, 22);
            this.txtAciklama.MaxLength = 150;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(308, 91);
            this.txtAciklama.TabIndex = 1;
            this.txtAciklama.Text = "";
            // 
            // IsEmriDetayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1350, 711);
            this.Controls.Add(this.panelBilgi);
            this.Controls.Add(this.panelUstBilgi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IsEmriDetayi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İş Emri Detayı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IsEmriDetayi_Load);
            this.panelBilgi.ResumeLayout(false);
            this.panelUstBilgi.ResumeLayout(false);
            this.gbxYeniIsEmri.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUstBilgi;
        private System.Windows.Forms.Panel panelBilgi;
        private System.Windows.Forms.FlowLayoutPanel flowKartlar;
        private System.Windows.Forms.GroupBox gbxYeniIsEmri;
        private System.Windows.Forms.Label lblNotlar;
        private System.Windows.Forms.Button btnNotuGuncelle;
        private System.Windows.Forms.RichTextBox txtAciklama;
        private System.Windows.Forms.Button btnYeniYolKartAc;
    }
}