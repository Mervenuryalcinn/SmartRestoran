using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    public partial class FrmUrunIslemleri : Form
    {
        public FrmUrunIslemleri()
        {
            InitializeComponent();
        }

        private void FrmUrunIslemleri_Load(object sender, EventArgs e)
        {
            ListeleUrunler();
        }


        private void ListeleUrunler()
        {
            try
            {
                string query = "SELECT UrunID, UrunAdi, KategoriID, Fiyat, Aciklama FROM Menü";
                DbHelper dbHelper = new DbHelper();
                DataTable dt = dbHelper.ExecuteReader(query, null);
                dataGridView1.DataSource = dt;
                DataGridViewOzellestir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void DataGridViewOzellestir()
        {
            dataGridView1.Columns["UrunID"].HeaderText = "Ürün ID";
            dataGridView1.Columns["UrunAdi"].HeaderText = "Ürün Adı";
            dataGridView1.Columns["KategoriID"].HeaderText = "Kategori ID";
            dataGridView1.Columns["Fiyat"].HeaderText = "Fiyat (₺)";
            dataGridView1.Columns["Aciklama"].HeaderText = "Açıklama";

            dataGridView1.Columns["UrunID"].Width = 50;
            dataGridView1.Columns["UrunAdi"].Width = 150;
            dataGridView1.Columns["KategoriID"].Width = 100;
            dataGridView1.Columns["Fiyat"].Width = 100;
            dataGridView1.Columns["Aciklama"].Width = 250;

            dataGridView1.Columns["UrunID"].ReadOnly = true;
        }
    
private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void UrunSil_Click(object sender, EventArgs e)
        {
            // Seçili bir ürün var mı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırdan UrunID'yi al
                int urunID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);

                // Kullanıcıya onay mesajı göster
                DialogResult result = MessageBox.Show(
                    "Bu ürünü silmek istediğinizden emin misiniz?",
                    "Ürün Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Silme sorgusunu oluştur
                        string query = "DELETE FROM Menü WHERE UrunID = @UrunID";

                        // Parametreyi oluştur
                        SqlParameter[] parameters = {
                    new SqlParameter("@UrunID", urunID)
                };

                        // Veritabanı yardımcı sınıfını kullan
                        DbHelper dbHelper = new DbHelper();
                        int affectedRows = dbHelper.ExecuteNonQuery(query, parameters);

                        // Silme başarılı mı kontrol et
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListeleUrunler(); // Ürün listesini yenile
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu. Ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda mesaj göster
                        MessageBox.Show("Ürün silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void UrunDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili bir ürün var mı kontrol et
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırdan ürün bilgilerini al
                int urunID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UrunID"].Value);
                string urunAdi = dataGridView1.SelectedRows[0].Cells["UrunAdi"].Value.ToString();
                int kategoriID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KategoriID"].Value);
                decimal fiyat = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells["Fiyat"].Value);
                string aciklama = dataGridView1.SelectedRows[0].Cells["Aciklama"].Value.ToString();

                // FrmUrunDuzenle formunu aç ve mevcut bilgileri doldur
                FrmUrunDuzenle frmUrunDuzenle = new FrmUrunDuzenle();
                frmUrunDuzenle.UrunID = urunID;
                frmUrunDuzenle.UrunAdi = urunAdi;
                frmUrunDuzenle.KategoriID = kategoriID;
                frmUrunDuzenle.Fiyat = fiyat;
                frmUrunDuzenle.Aciklama = aciklama;

                if (frmUrunDuzenle.ShowDialog() == DialogResult.OK)
                {
                    // Düzenleme işlemi sonrası listeyi yenile
                    ListeleUrunler();
                }
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz ürünü seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            FrmUrunEkle frmUrunEkle = new FrmUrunEkle();
            frmUrunEkle.ShowDialog();  // Modal olarak açar
            ListeleUrunler(); // Ürünler listelensin

        }
    }
}
