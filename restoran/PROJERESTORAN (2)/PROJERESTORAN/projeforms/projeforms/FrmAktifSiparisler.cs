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
    public partial class FrmAktifSiparisler : Form
    {
        public int CurrentUserID { get; private set; }


        public FrmAktifSiparisler()
        {
            InitializeComponent();
        }

        private int GetCurrentUserID()
        {
            // Kullanıcı giriş yaptıktan sonra ID'si global bir değişkende tutulabilir.
            return CurrentUserID; // Global olarak tanımlanmış kullanıcı ID'si
        }

        private void FrmAktifSiparisler_Load(object sender, EventArgs e)
        {
            SiparisleriGoster();
        }

        private List<Siparis> SiparisleriGetir()
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
        JOIN Kullanıcılar AS u ON s.KullaniciID = u.KullaniciID";

            DbHelper dbHelper = new DbHelper();
            using (SqlConnection conn = new SqlConnection(dbHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
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
        private void SiparisleriGoster()
        {
            panelContent.Controls.Clear();

            List<Siparis> siparisler = SiparisleriGetir();
            if (siparisler.Count == 0)
            {
                MessageBox.Show("Hiç sipariş bulunamadı.");
                return;
            }

            int x = 0;
            int y = 0;
            int panelWidth = (panelContent.Width / 2) - 20;

            // Her sipariş için bir kart oluştur
            foreach (var siparis in siparisler)
            {
                Panel siparisPanel = new Panel
                {
                    Width = panelWidth,
                    Height = 250,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(x, y),
                    Margin = new Padding(50)
                };

                Label lblSiparisID = new Label { Text = $"Sipariş ID: {siparis.SiparisID}", AutoSize = true, Location = new Point(10, 10) };
                Label lblKullanici = new Label { Text = $"Müşteri: {siparis.Ad} {siparis.Soyad}", AutoSize = true, Location = new Point(10, 40) };
                Label lblTelefon = new Label { Text = $"Telefon: {siparis.Telefon}", AutoSize = true, Location = new Point(10, 70) };
                Label lblTutar = new Label { Text = $"Toplam Tutar: {siparis.ToplamTutar} TL", AutoSize = true, Location = new Point(10, 100) };
                Label lblDurum = new Label { Text = $"Durum: {siparis.Durum}", AutoSize = true, Location = new Point(10, 130) };
                Label lblTeslimat = new Label { Text = $"Teslimat Adresi: {siparis.TeslimatAdresi}", AutoSize = true, Location = new Point(10, 160) };

                Button btnGuncelle = new Button
                {
                    Text = "Durumu Güncelle",
                    Width = 120,
                    Height = 40,
                    Location = new Point(10, 190)
                };

                btnGuncelle.Click += (sender, e) =>
                {
                    string yeniDurum = PromptForNewStatus();
                    SiparisDurumuGuncelle(siparis.SiparisID, yeniDurum);
                    lblDurum.Text = $"Durum: {yeniDurum}";
                };

                siparisPanel.Controls.Add(lblSiparisID);
                siparisPanel.Controls.Add(lblKullanici);
                siparisPanel.Controls.Add(lblTelefon);
                siparisPanel.Controls.Add(lblTutar);
                siparisPanel.Controls.Add(lblDurum);
                siparisPanel.Controls.Add(lblTeslimat);
                siparisPanel.Controls.Add(btnGuncelle);

                panelContent.Controls.Add(siparisPanel);

                x += panelWidth + 20;  // Bir sonraki paneli sağa kaydır

                if (x >= panelContent.Width)  // Satır tamamlanırsa
                {
                    x = 0;
                    y += 250;  // Bir satır aşağıya kaydır
                }
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

                    string calisanSiparisQuery = "INSERT INTO CalisanSiparis (KullaniciID, SiparisID) VALUES (@KullaniciID, @SiparisID)";

                    SqlParameter[] calisanSiparisParams = {
                new SqlParameter("@KullaniciID", currentUserID),
                new SqlParameter("@SiparisID", siparisID)
            };

                    dbHelper.ExecuteNonQuery(calisanSiparisQuery, calisanSiparisParams);

                    MessageBox.Show($"Sipariş {siparisID} 'Teslim Edildi' olarak güncellendi ve çalışan kaydedildi.");
                }
                else
                {
                    MessageBox.Show($"Sipariş {siparisID} durumunu '{yeniDurum}' olarak güncellendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme sırasında bir hata oluştu: {ex.Message}");
            }
        }

        private string PromptForNewStatus()
        {
            Form prompt = new Form
            {
                Width = 300,
                Height = 150,
                Text = "Yeni Durumu Seç"
            };

            // ComboBox oluştur
            ComboBox statusComboBox = new ComboBox
            {
                Left = 50,
                Top = 20,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Durum seçeneklerini ekle
            statusComboBox.Items.AddRange(new object[] { "Hazırlanıyor", "Kargoda", "Teslim Edildi" });

            // Güncelle butonu oluştur
            Button confirmation = new Button
            {
                Text = "Güncelle",
                Left = 200,
                Width = 80,
                Top = 70
            };

            confirmation.Click += (sender, e) =>
            {
                prompt.Close();
            };

            prompt.Controls.Add(statusComboBox);
            prompt.Controls.Add(confirmation);

            prompt.ShowDialog();

            return statusComboBox.SelectedItem?.ToString() ?? "Belirsiz";
        }



        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
