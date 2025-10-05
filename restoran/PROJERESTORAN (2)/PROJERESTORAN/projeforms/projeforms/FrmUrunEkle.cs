using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projeforms
{
    internal class FrmUrunEkle : Form
    {
        private Button btnEkle;
        private TextBox txtUrunAdi;
        private TextBox txtFiyat;
        private TextBox txtAciklama;
        private TextBox txtKategoriID;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        public FrmUrunEkle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnEkle = new System.Windows.Forms.Button();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.txtKategoriID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(330, 340);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(168, 52);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ürün Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click_1);
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(359, 82);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(100, 22);
            this.txtUrunAdi.TabIndex = 1;
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(359, 143);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(100, 22);
            this.txtFiyat.TabIndex = 2;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(359, 204);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(100, 22);
            this.txtAciklama.TabIndex = 3;
            // 
            // txtKategoriID
            // 
            this.txtKategoriID.Location = new System.Drawing.Point(359, 258);
            this.txtKategoriID.Name = "txtKategoriID";
            this.txtKategoriID.Size = new System.Drawing.Size(100, 22);
            this.txtKategoriID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Açıklama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kategori Id";
            // 
            // FrmUrunEkle
            // 
            this.ClientSize = new System.Drawing.Size(882, 765);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKategoriID);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtUrunAdi);
            this.Controls.Add(this.btnEkle);
            this.Name = "FrmUrunEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
            
        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            string urunAdi = txtUrunAdi.Text;
            int kategoriID;
            decimal fiyat;
            string aciklama = txtAciklama.Text;

            // Veri doğrulama
            if (string.IsNullOrEmpty(urunAdi) || !int.TryParse(txtKategoriID.Text, out kategoriID) || !decimal.TryParse(txtFiyat.Text, out fiyat))
            {
                MessageBox.Show("Geçersiz giriş, lütfen tüm alanları doğru şekilde doldurun.");
                return;
            }

            string query = "INSERT INTO Menü (UrunAdi, KategoriID, Fiyat, Aciklama) VALUES (@UrunAdi, @KategoriID, @Fiyat, @Aciklama)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@UrunAdi", urunAdi),
                new SqlParameter("@KategoriID", kategoriID),
                new SqlParameter("@Fiyat", fiyat),
                new SqlParameter("@Aciklama", aciklama)
            };

            DbHelper dbHelper = new DbHelper();
            int rowsAffected = dbHelper.ExecuteNonQuery(query, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Ürün başarıyla eklendi.");
                this.Close(); // Formu kapat
            }
            else
            {
                MessageBox.Show("Ürün eklenirken bir hata oluştu.");
            }
        }

    }
}

