using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    internal class FrmUrunDuzenle: Form

    {

        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriID { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        private TextBox txtUrunAdi;
        private TextBox txtAciklama;
        private TextBox txtFiyat;
        private ComboBox cmbKategori;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnKaydet;
        private Label label4;
        public FrmUrunDuzenle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(339, 129);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(100, 22);
            this.txtUrunAdi.TabIndex = 0;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(339, 339);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(100, 22);
            this.txtAciklama.TabIndex = 1;
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(339, 272);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(100, 22);
            this.txtFiyat.TabIndex = 2;
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "1 (İçecekler)",
            "6(Tatlı)",
            "7(Hamburger)",
            "8(Pizza)"});
            this.cmbKategori.Location = new System.Drawing.Point(339, 193);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(121, 24);
            this.cmbKategori.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fiyat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Açıklama";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kategori";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(339, 430);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(142, 23);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // FrmUrunDuzenle
            // 
            this.ClientSize = new System.Drawing.Size(1132, 767);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtUrunAdi);
            this.Name = "FrmUrunDuzenle";
            this.Load += new System.EventHandler(this.FrmUrunDuzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmUrunDuzenle_Load(object sender, EventArgs e)
        {
            // Mevcut bilgileri doldur
            txtUrunAdi.Text = UrunAdi;
            cmbKategori.SelectedValue = KategoriID; // Kategori combobox için bir veri kaynağı kullanmalısınız.
            txtFiyat.Text = Fiyat.ToString();
            txtAciklama.Text = Aciklama;
            try
            {
                // Kategoriler tablosunu doldur
                string kategoriQuery = "SELECT KategoriID, KategoriAdi FROM Kategoriler";
                DbHelper dbHelper = new DbHelper();
                DataTable dtKategori = dbHelper.ExecuteReader(kategoriQuery, null);

                cmbKategori.DataSource = dtKategori;
                cmbKategori.DisplayMember = "KategoriAdi";
                cmbKategori.ValueMember = "KategoriID";

                // Mevcut kategori seçili hale getir
                cmbKategori.SelectedValue = KategoriID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler yüklenirken bir hata oluştu: " + ex.Message);
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
                try
                {
                    // Seçilen kategori doğrulaması
                    if (cmbKategori.SelectedValue == null || !int.TryParse(cmbKategori.SelectedValue.ToString(), out int kategoriID))
                    {
                        MessageBox.Show("Lütfen geçerli bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Güncelleme sorgusu
                    string query = "UPDATE Menü SET UrunAdi = @UrunAdi, KategoriID = @KategoriID, Fiyat = @Fiyat, Aciklama = @Aciklama WHERE UrunID = @UrunID";

                    // Parametreleri oluştur
                    SqlParameter[] parameters = {
            new SqlParameter("@UrunAdi", txtUrunAdi.Text),
            new SqlParameter("@KategoriID", kategoriID),
            new SqlParameter("@Fiyat", Convert.ToDecimal(txtFiyat.Text)),
            new SqlParameter("@Aciklama", txtAciklama.Text),
            new SqlParameter("@UrunID", UrunID)
        };

                    // Veritabanı işlemi
                    DbHelper dbHelper = new DbHelper();
                    int affectedRows = dbHelper.ExecuteNonQuery(query, parameters);

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün güncellenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }


