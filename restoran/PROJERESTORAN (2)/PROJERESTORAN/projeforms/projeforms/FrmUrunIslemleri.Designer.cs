namespace projeforms
{
    partial class FrmUrunIslemleri
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UrunDuzenle = new System.Windows.Forms.Button();
            this.UrunSil = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(935, 536);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.UseWaitCursor = true;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(49, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "ÜRÜN LİSTESİ";
            this.label1.UseWaitCursor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(403, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.UseWaitCursor = true;
            // 
            // UrunDuzenle
            // 
            this.UrunDuzenle.Location = new System.Drawing.Point(279, 96);
            this.UrunDuzenle.Name = "UrunDuzenle";
            this.UrunDuzenle.Size = new System.Drawing.Size(106, 40);
            this.UrunDuzenle.TabIndex = 10;
            this.UrunDuzenle.Text = "Ürün Düzenle";
            this.UrunDuzenle.UseVisualStyleBackColor = true;
            this.UrunDuzenle.UseWaitCursor = true;
            this.UrunDuzenle.Click += new System.EventHandler(this.UrunDuzenle_Click);
            // 
            // UrunSil
            // 
            this.UrunSil.Location = new System.Drawing.Point(171, 96);
            this.UrunSil.Name = "UrunSil";
            this.UrunSil.Size = new System.Drawing.Size(95, 40);
            this.UrunSil.TabIndex = 12;
            this.UrunSil.Text = "Ürün Sil";
            this.UrunSil.UseVisualStyleBackColor = true;
            this.UrunSil.UseWaitCursor = true;
            this.UrunSil.Click += new System.EventHandler(this.UrunSil_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(55, 93);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(101, 43);
            this.btnUrunEkle.TabIndex = 13;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.UseWaitCursor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // FrmUrunIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 753);
            this.Controls.Add(this.btnUrunEkle);
            this.Controls.Add(this.UrunSil);
            this.Controls.Add(this.UrunDuzenle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUrunIslemleri";
            this.Text = "FrmUrunIslemleri";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FrmUrunIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button UrunDuzenle;
        private System.Windows.Forms.Button UrunSil;
        private System.Windows.Forms.Button btnUrunEkle;
    }
}