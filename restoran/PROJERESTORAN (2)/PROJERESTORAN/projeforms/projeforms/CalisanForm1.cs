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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projeforms
{
    public partial class CalisanForm1 : Form
    {

        private string Email; // Kullanıcı email bilgisi
        private string Ad;    // Kullanıcı adı 
        private string Soyad; // Kullanıcı soyadı
        private int KullaniciID; // Kullanıcı ID
        public CalisanForm1()
        {
            InitializeComponent();
        }

        private void panelContent1_Paint(object sender, PaintEventArgs e)
        {

        }

        public CalisanForm1(string email)
        {
            InitializeComponent();
            Email = email; // Email bilgisi giriş ekranından geliyor
        }

        private void LoadKullaniciBilgileri()
        {
            // Kullanıcı bilgilerini almak için DbHelper kullan
            DbHelper dbHelper = new DbHelper();
            string query = @"SELECT KullaniciID, Ad ,Soyad 
                         FROM Kullanıcılar 
                         WHERE Email = @Email";

            // Email parametresini ekle
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Email", Email)
            };

            // Veritabanından bilgileri al
            DataTable userInfo = dbHelper.ExecuteReader(query, parameters);

            if (userInfo.Rows.Count > 0) // Kullanıcı bilgisi bulunduysa
            {
                DataRow row = userInfo.Rows[0];
                KullaniciID = Convert.ToInt32(row["KullaniciID"]);
                Ad = row["Ad"].ToString();
                Soyad = row["Soyad"].ToString();

                // Kullanıcı bilgilerini form üzerinde göster
                lblKullaniciAd.Text = $"Ad: {Ad}";
                lblKullaniciSoyad.Text = $"Soyad: {Soyad}";
                lblKullaniciID.Text = $"ID: {KullaniciID}";
            }
            else
            {
                MessageBox.Show("Kullanıcı bilgisi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAktifSiparisler_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent1.Controls.Clear();

            // Aktif Siparişler formunu oluştur
            FrmAktifSiparisler aktifSiparislerForm = new FrmAktifSiparisler();
            aktifSiparislerForm.TopLevel = false; // Alt form olarak tanımla
            aktifSiparislerForm.FormBorderStyle = FormBorderStyle.None; // Kenarlıkları kaldır
            aktifSiparislerForm.Dock = DockStyle.Fill; // Formu paneli dolduracak şekilde ayarla

            // Formu panele ekle
            panelContent1.Controls.Add(aktifSiparislerForm);
            aktifSiparislerForm.Show();
        }

        private void btnGunlukOzet_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent1.Controls.Clear();

            // Aktif Siparişler formunu oluştur
            FrmGunlukOzet gunlukSiparisOzeti = new FrmGunlukOzet();
            gunlukSiparisOzeti.TopLevel = false; // Alt form olarak tanımla
            gunlukSiparisOzeti.FormBorderStyle = FormBorderStyle.None; // Kenarlıkları kaldır
            gunlukSiparisOzeti.Dock = DockStyle.Fill; // Formu paneli dolduracak şekilde ayarla

            // Formu panele ekle
            panelContent1.Controls.Add(gunlukSiparisOzeti);
            gunlukSiparisOzeti.Show();
        }

        private void CalisanForm1_Load(object sender, EventArgs e)
        {
            LoadKullaniciBilgileri();
        }
    }
}
