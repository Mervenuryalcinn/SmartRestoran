using projeforms.model;
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
    public partial class FrmGunlukOzet : Form
    {
        public int CurrentUserID { get; private set; }
        public FrmGunlukOzet()
        {
            InitializeComponent();
        }

        private int GetCurrentUserID()
        {
            // Kullanıcı giriş yaptıktan sonra ID'si global bir değişkende tutulabilir.
            return CurrentUserID; // Global olarak tanımlanmış kullanıcı ID'si
        }

        private void FrmGunlukOzet_Load(object sender, EventArgs e)
        {
            GunlukOzetGoster();
        }

        private void GunlukOzetGoster()
        {
            // Günlük özet için paneli temizle
            panelContent.Controls.Clear();

            // Çalışanın tamamladığı siparişleri al
            var siparisler = GetCalisanSiparisleri();
            if (siparisler.Count == 0)
            {
                MessageBox.Show("Bugün tamamlanan sipariş bulunamadı.");
                return;
            }

            int toplamSiparisSayisi = siparisler.Count;
            decimal toplamTutar = siparisler.Sum(s => s.ToplamTutar);

            // Sipariş sayısı ve toplam tutar bilgilerini gösteren etiketler ekle
            Label lblToplamSiparis = new Label
            {
                Text = $"Toplam Sipariş Sayısı: {toplamSiparisSayisi}",
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Label lblToplamTutar = new Label
            {
                Text = $"Toplam Tutar: {toplamTutar} TL",
                AutoSize = true,
                Location = new Point(10, 40)
            };

            panelContent.Controls.Add(lblToplamSiparis);
            panelContent.Controls.Add(lblToplamTutar);
        }

        private List<Siparis> GetCalisanSiparisleri()
        {
            List<Siparis> siparisler = new List<Siparis>();
            string query = @"
                SELECT 
                    s.SiparisID, 
                    s.KullaniciID, 
                    u.Ad AS Ad, 
                    u.Soyad AS Soyad, 
                    u.Telefon AS Telefon, 
                    u.TeslimatAdresi, 
                    ISNULL(s.ToplamTutar, 0) AS ToplamTutar, 
                    s.Durum, 
                    s.Tarih 
                FROM Siparişler AS s
                JOIN Kullanıcılar AS u ON s.KullaniciID = u.KullaniciID
                WHERE s.Durum = 'Teslim Edildi' 
                AND s.Tarih = CAST(GETDATE() AS DATE)
                AND EXISTS (
                    SELECT 1 FROM CalisanSiparis AS cs 
                    WHERE cs.SiparisID = s.SiparisID 
                    AND cs.CalisanID = @CalisanID
                )";

            DbHelper dbHelper = new DbHelper();

            using (SqlConnection conn = new SqlConnection(dbHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@CalisanID", GetCurrentUserID()));
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        siparisler.Add(new Siparis
                        {
                            SiparisID = reader.GetInt32(reader.GetOrdinal("SiparisID")),
                            Ad = reader.GetString(reader.GetOrdinal("Ad")),
                            Soyad = reader.GetString(reader.GetOrdinal("Soyad")),
                            Telefon = reader.GetString(reader.GetOrdinal("Telefon")),
                            TeslimatAdresi = reader.IsDBNull(reader.GetOrdinal("TeslimatAdresi"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("TeslimatAdresi")),
                            ToplamTutar = reader.IsDBNull(reader.GetOrdinal("ToplamTutar"))
                                ? 0
                                : reader.GetDecimal(reader.GetOrdinal("ToplamTutar")),
                            Durum = reader.GetString(reader.GetOrdinal("Durum"))
                        });
                    }
                }
            }
            return siparisler;
        }

        private void CalisanSiparisEkle(int siparisID, int calisanID)
        {
            // CalisanSiparis tablosuna ekleme sorgusu
            string insertQuery = "INSERT INTO CalisanSiparis (CalisanID, SiparisID) VALUES (@CalisanID, @SiparisID)";
            SqlParameter[] insertParameters = {
        new SqlParameter("@CalisanID", calisanID),
        new SqlParameter("@SiparisID", siparisID)
    };

            DbHelper dbHelper = new DbHelper();

            try
            {
                dbHelper.ExecuteNonQuery(insertQuery, insertParameters);
                MessageBox.Show($"Sipariş {siparisID}, çalışan {calisanID} tarafından tamamlandı ve kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CalisanSiparis ekleme sırasında bir hata oluştu: {ex.Message}");
            }
        }


        private void SiparisDurumuGuncelle(int siparisID, string yeniDurum)
        {
            string query = "UPDATE Siparişler SET Durum = @Durum WHERE SiparisID = @SiparisID";

            SqlParameter[] parameters = {
                new SqlParameter("@Durum", yeniDurum),
                new SqlParameter("@SiparisID", siparisID)
            };

            DbHelper dbHelper = new DbHelper();

            try
            {
                // Sipariş durumu güncelle
                dbHelper.ExecuteNonQuery(query, parameters);

                if (yeniDurum == "Teslim Edildi")
                {
                    // Eğer "Teslim Edildi" durumu seçilmişse CalisanSiparis tablosuna ekle
                    int currentUserID = GetCurrentUserID(); // Giriş yapan kullanıcının ID'sini al

                    // CalisanSiparis tablosuna siparişi ekleyelim
                    CalisanSiparisEkle(siparisID, currentUserID);

                    MessageBox.Show($"Sipariş {siparisID} 'Teslim Edildi' olarak güncellendi ve çalışan kaydedildi.");
                }
                else
                {
                    MessageBox.Show($"Sipariş {siparisID} durumu '{yeniDurum}' olarak güncellendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}");
            }
        }
        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
