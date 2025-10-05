namespace projeforms
{
    partial class CalisanForm1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelContent1 = new System.Windows.Forms.Panel();
            this.btnAktifSiparisler = new System.Windows.Forms.Button();
            this.btnGunlukOzet = new System.Windows.Forms.Button();
            this.lblKullaniciAd = new System.Windows.Forms.Label();
            this.lblKullaniciSoyad = new System.Windows.Forms.Label();
            this.lblKullaniciID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnGunlukOzet);
            this.panel1.Controls.Add(this.btnAktifSiparisler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 609);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.lblKullaniciID);
            this.panel2.Controls.Add(this.lblKullaniciSoyad);
            this.panel2.Controls.Add(this.lblKullaniciAd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(376, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 100);
            this.panel2.TabIndex = 1;
            // 
            // panelContent1
            // 
            this.panelContent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent1.Location = new System.Drawing.Point(376, 100);
            this.panelContent1.Name = "panelContent1";
            this.panelContent1.Size = new System.Drawing.Size(950, 509);
            this.panelContent1.TabIndex = 2;
            this.panelContent1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContent1_Paint);
            // 
            // btnAktifSiparisler
            // 
            this.btnAktifSiparisler.Location = new System.Drawing.Point(21, 153);
            this.btnAktifSiparisler.Name = "btnAktifSiparisler";
            this.btnAktifSiparisler.Size = new System.Drawing.Size(336, 121);
            this.btnAktifSiparisler.TabIndex = 1;
            this.btnAktifSiparisler.Text = "AKTİF SİPARİŞLER";
            this.btnAktifSiparisler.UseVisualStyleBackColor = true;
            this.btnAktifSiparisler.Click += new System.EventHandler(this.btnAktifSiparisler_Click);
            // 
            // btnGunlukOzet
            // 
            this.btnGunlukOzet.Location = new System.Drawing.Point(21, 365);
            this.btnGunlukOzet.Name = "btnGunlukOzet";
            this.btnGunlukOzet.Size = new System.Drawing.Size(336, 121);
            this.btnGunlukOzet.TabIndex = 2;
            this.btnGunlukOzet.Text = "GÜNLÜK SİPARİŞ ÖZETİ";
            this.btnGunlukOzet.UseVisualStyleBackColor = true;
            this.btnGunlukOzet.Click += new System.EventHandler(this.btnGunlukOzet_Click);
            // 
            // lblKullaniciAd
            // 
            this.lblKullaniciAd.AutoSize = true;
            this.lblKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAd.Location = new System.Drawing.Point(83, 38);
            this.lblKullaniciAd.Name = "lblKullaniciAd";
            this.lblKullaniciAd.Size = new System.Drawing.Size(64, 25);
            this.lblKullaniciAd.TabIndex = 1;
            this.lblKullaniciAd.Text = "label1";
            // 
            // lblKullaniciSoyad
            // 
            this.lblKullaniciSoyad.AutoSize = true;
            this.lblKullaniciSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciSoyad.Location = new System.Drawing.Point(224, 38);
            this.lblKullaniciSoyad.Name = "lblKullaniciSoyad";
            this.lblKullaniciSoyad.Size = new System.Drawing.Size(64, 25);
            this.lblKullaniciSoyad.TabIndex = 2;
            this.lblKullaniciSoyad.Text = "label2";
            // 
            // lblKullaniciID
            // 
            this.lblKullaniciID.AutoSize = true;
            this.lblKullaniciID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciID.Location = new System.Drawing.Point(364, 38);
            this.lblKullaniciID.Name = "lblKullaniciID";
            this.lblKullaniciID.Size = new System.Drawing.Size(64, 25);
            this.lblKullaniciID.TabIndex = 3;
            this.lblKullaniciID.Text = "label3";
            // 
            // CalisanForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 609);
            this.Controls.Add(this.panelContent1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CalisanForm1";
            this.Text = "CalisanForm1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelContent1;
        private System.Windows.Forms.Button btnAktifSiparisler;
        private System.Windows.Forms.Button btnGunlukOzet;
        private System.Windows.Forms.Label lblKullaniciAd;
        private System.Windows.Forms.Label lblKullaniciSoyad;
        private System.Windows.Forms.Label lblKullaniciID;
    }
}