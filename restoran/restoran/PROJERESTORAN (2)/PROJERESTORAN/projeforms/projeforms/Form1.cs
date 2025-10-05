using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public int GetKullaniciIdByEmail(string email)
        {
            string query = "SELECT KullaniciID FROM Kullanicilar WHERE Email = @Email";
            SqlParameter[] parameters = {
        new SqlParameter("@Email", email)
    };

            DbHelper dbHelper = new DbHelper();
            DataTable userTable = dbHelper.ExecuteReader(query, parameters);

            if (userTable.Rows.Count > 0)
            {
                return Convert.ToInt32(userTable.Rows[0]["KullaniciID"]);
            }
            else
            {
                throw new Exception("Kullanıcı bulunamadı!");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim().ToLower(); // E-posta adresi
            string password = txtPassword.Text.Trim(); // Şifre
            string kullaniciTipi = cmbKullaniciTipi.SelectedItem?.ToString().Trim(); // Kullanıcı tipi

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(kullaniciTipi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbHelper dbHelper = new DbHelper();

            // Kullanıcı rolünü sorgulamak için SQL
            string queryRole = "SELECT Rol,KullaniciID FROM Kullanıcılar WHERE Email = @Email AND Sifre = @Sifre";

            // Parametreleri ekliyoruz
            SqlParameter[] parametersRole = new SqlParameter[] {
            new SqlParameter("@Email", username),
            new SqlParameter("@Sifre", password)
            };

            // DBHelper ile ExecuteScalar kullanarak rolü alıyoruz
            object resultRole = dbHelper.ExecuteScalar(queryRole, parametersRole);

            if (resultRole != null)
            {
                string roleFromDb = resultRole.ToString(); // Veritabanından gelen rol

                // E-posta adresine göre kullanıcı ID'sini almak için SQL sorgusu
                string queryID = "SELECT KullaniciID FROM Kullanıcılar WHERE Email = @Email";
                SqlParameter[] parametersID = new SqlParameter[] {
                new SqlParameter("@Email", username)
                };

                // DBHelper ile ExecuteScalar kullanarak ID'yi alıyoruz
                object resultID = dbHelper.ExecuteScalar(queryID, parametersID);

                if (resultID != null)
                {
                    int userID = Convert.ToInt32(resultID); // Kullanıcı ID'si alındı

                    // Rolü ComboBox seçimiyle karşılaştırıyoruz
                    if (roleFromDb.Equals(kullaniciTipi, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show($"Hoş geldiniz! Rolünüz: {roleFromDb}");

                        // Rol bazlı yönlendirme
                        if (roleFromDb == "Müşteri")
                        {
                            MüsteriForm musteriForm = new MüsteriForm(userID); // Kullanıcı ID'si ile formu açıyoruz
                            musteriForm.Show(); // Müşteri formunu aç
                            this.Hide(); // Bu formu gizle
                        }
                        else if (roleFromDb == "yönetici")
                        {
                            YöneticiForm yoneticiForm = new YöneticiForm();
                            yoneticiForm.ShowDialog(); // Yönetici formunu aç
                            this.Hide(); // Bu formu gizle
                        }
                        else if (roleFromDb == "çalışan")
                        {
                            CalisanForm1 calisanForm = new CalisanForm1(username); // E-posta ile çalışan formunu aç
                            calisanForm.Show(); // Çalışan formunu aç
                            this.Hide(); // Bu formu gizle
                        }
                        else
                        {
                            MessageBox.Show("Bilinmeyen bir rol ile giriş yapmaya çalıştınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seçilen rol ile sistemdeki rolünüz uyuşmuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı ID'si alınırken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı adı veya şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            uyeolForm uyeOlForm = new uyeolForm();
            uyeOlForm.ShowDialog();


        }

        private void cmbKullaniciTipi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}