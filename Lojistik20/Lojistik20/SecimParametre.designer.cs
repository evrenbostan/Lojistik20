namespace Lojistik20
{
    partial class SecimParametre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecimParametre));
            this.panelUstBilgi = new System.Windows.Forms.Panel();
            this.btnVazgeç = new System.Windows.Forms.Button();
            this.btnSecim = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lblArama = new System.Windows.Forms.Label();
            this.panelBilgi = new System.Windows.Forms.Panel();
            this.grdSecimListesi = new System.Windows.Forms.DataGridView();
            this.panelUstBilgi.SuspendLayout();
            this.panelBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSecimListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUstBilgi
            // 
            this.panelUstBilgi.Controls.Add(this.btnVazgeç);
            this.panelUstBilgi.Controls.Add(this.btnSecim);
            this.panelUstBilgi.Controls.Add(this.txtAra);
            this.panelUstBilgi.Controls.Add(this.lblArama);
            this.panelUstBilgi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUstBilgi.Location = new System.Drawing.Point(0, 0);
            this.panelUstBilgi.Name = "panelUstBilgi";
            this.panelUstBilgi.Size = new System.Drawing.Size(1173, 39);
            this.panelUstBilgi.TabIndex = 0;
            // 
            // btnVazgeç
            // 
            this.btnVazgeç.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVazgeç.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVazgeç.Image = global::Lojistik20.Properties.Resources.delete_icon;
            this.btnVazgeç.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVazgeç.Location = new System.Drawing.Point(1079, 3);
            this.btnVazgeç.Name = "btnVazgeç";
            this.btnVazgeç.Size = new System.Drawing.Size(91, 35);
            this.btnVazgeç.TabIndex = 59;
            this.btnVazgeç.Text = "VAZGEÇ";
            this.btnVazgeç.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVazgeç.UseVisualStyleBackColor = true;
            this.btnVazgeç.Click += new System.EventHandler(this.btnVazgeç_Click);
            // 
            // btnSecim
            // 
            this.btnSecim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSecim.Image = global::Lojistik20.Properties.Resources.add;
            this.btnSecim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecim.Location = new System.Drawing.Point(957, 3);
            this.btnSecim.Name = "btnSecim";
            this.btnSecim.Size = new System.Drawing.Size(116, 35);
            this.btnSecim.TabIndex = 58;
            this.btnSecim.Text = "SEÇİMİ EKLE";
            this.btnSecim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSecim.UseVisualStyleBackColor = true;
            this.btnSecim.Click += new System.EventHandler(this.btnSecim_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(139, 9);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(255, 25);
            this.txtAra.TabIndex = 11;
            this.txtAra.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // lblArama
            // 
            this.lblArama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArama.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblArama.Location = new System.Drawing.Point(12, 9);
            this.lblArama.Name = "lblArama";
            this.lblArama.Size = new System.Drawing.Size(121, 25);
            this.lblArama.TabIndex = 9;
            this.lblArama.Text = "ARAMA:";
            this.lblArama.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelBilgi
            // 
            this.panelBilgi.Controls.Add(this.grdSecimListesi);
            this.panelBilgi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBilgi.Location = new System.Drawing.Point(0, 39);
            this.panelBilgi.Name = "panelBilgi";
            this.panelBilgi.Size = new System.Drawing.Size(1173, 405);
            this.panelBilgi.TabIndex = 1;
            // 
            // grdSecimListesi
            // 
            this.grdSecimListesi.AllowUserToAddRows = false;
            this.grdSecimListesi.AllowUserToDeleteRows = false;
            this.grdSecimListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSecimListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSecimListesi.Location = new System.Drawing.Point(0, 0);
            this.grdSecimListesi.MultiSelect = false;
            this.grdSecimListesi.Name = "grdSecimListesi";
            this.grdSecimListesi.ReadOnly = true;
            this.grdSecimListesi.Size = new System.Drawing.Size(1173, 405);
            this.grdSecimListesi.TabIndex = 0;
            this.grdSecimListesi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSecimListesi_CellDoubleClick);
            // 
            // SecimParametre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1173, 444);
            this.Controls.Add(this.panelBilgi);
            this.Controls.Add(this.panelUstBilgi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SecimParametre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SecimParametre_Load);
            this.panelUstBilgi.ResumeLayout(false);
            this.panelUstBilgi.PerformLayout();
            this.panelBilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSecimListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUstBilgi;
        private System.Windows.Forms.Panel panelBilgi;
        private System.Windows.Forms.Label lblArama;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.DataGridView grdSecimListesi;
        private System.Windows.Forms.Button btnSecim;
        private System.Windows.Forms.Button btnVazgeç;
    }
}