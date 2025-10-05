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
    internal class FrmKategoriler:Form
    {
        private DataGridView dataGridView1;
        private TextBox txtKategoriAdi;
        private Button btnEkle;
        private Label label1;
        private Button btnSil;

        public FrmKategoriler()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-13, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1073, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(22, 73);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(100, 22);
            this.txtKategoriAdi.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(35, 115);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(167, 115);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori Listesi";
            // 
            // FrmKategoriler
            // 
            this.ClientSize = new System.Drawing.Size(1048, 738);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtKategoriAdi);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmKategoriler";
            this.Load += new System.EventHandler(this.FrmKategoriler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {
            ListeleKategoriler();
        }
        private void ListeleKategoriler()
        {
            try
            {
                string query = "SELECT KategoriID, KategoriAdi FROM Kategoriler";
                DbHelper dbHelper = new DbHelper();
                DataTable dt = dbHelper.ExecuteReader(query, null);
                dataGridView1.DataSource = dt;

                DataGridViewOzellestir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler listelenirken bir hata oluştu: " + ex.Message);
            }
        }
        private void DataGridViewOzellestir()
        {
            dataGridView1.Columns["KategoriID"].HeaderText = "Kategori ID";
            dataGridView1.Columns["KategoriAdi"].HeaderText = "Kategori Adı";

            dataGridView1.Columns["KategoriID"].Width = 50;
            dataGridView1.Columns["KategoriAdi"].Width = 200;

            dataGridView1.Columns["KategoriID"].ReadOnly = true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Kategoriler (KategoriAdi) VALUES (@KategoriAdi)";
                SqlParameter[] parameters = {
                    new SqlParameter("@KategoriAdi", txtKategoriAdi.Text)
                };

                DbHelper dbHelper = new DbHelper();
                int affectedRows = dbHelper.ExecuteNonQuery(query, parameters);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeleKategoriler();
                }
                else
                {
                    MessageBox.Show("Kategori eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int kategoriID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);

                DialogResult result = MessageBox.Show(
                    "Bu kategoriyi silmek istediğinizden emin misiniz?",
                    "Kategori Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Kategoriler WHERE KategoriID = @KategoriID";
                        SqlParameter[] parameters = {
                            new SqlParameter("@KategoriID", kategoriID)
                        };

                        DbHelper dbHelper = new DbHelper();
                        int affectedRows = dbHelper.ExecuteNonQuery(query, parameters);

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListeleKategoriler();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu. Kategori bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kategori silinirken bir hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kategoriyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
