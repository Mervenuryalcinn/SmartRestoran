using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    public partial class YöneticiForm : Form
    {
        public YöneticiForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent.Controls.Clear();

            // Çalışan işlemleri formunu oluştur
            FrmCalisanlar calisanForm = new FrmCalisanlar();
            calisanForm.TopLevel = false; // Formun üst seviye değil, alt form olarak çalışmasını sağlar
            calisanForm.FormBorderStyle = FormBorderStyle.None; // Kenarlık kaldırılır
            calisanForm.Dock = DockStyle.Fill; // Paneli doldurur

            // Formu panele ekle
            panelContent.Controls.Add(calisanForm);
            calisanForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent.Controls.Clear();

            // Ürün işlemleri formunu oluştur
            FrmUrunIslemleri urunForm = new FrmUrunIslemleri();
            urunForm.TopLevel = false; // Formun üst seviye değil, alt form olarak çalışmasını sağlar
            urunForm.FormBorderStyle = FormBorderStyle.None; // Kenarlık kaldırılır
            urunForm.Dock = DockStyle.Fill; // Paneli doldurur

            // Formu panele ekle
            panelContent.Controls.Add(urunForm);
            urunForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void YöneticiForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent.Controls.Clear();

            // Kategori işlemleri formunu oluştur
            FrmKategoriler kategoriForm = new FrmKategoriler();
            kategoriForm.TopLevel = false; // Formun üst seviye değil, alt form olarak çalışmasını sağlar
            kategoriForm.FormBorderStyle = FormBorderStyle.None; // Kenarlık kaldırılır
            kategoriForm.Dock = DockStyle.Fill; // Paneli doldurur

            // Formu panele ekle
            panelContent.Controls.Add(kategoriForm);
            kategoriForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Panel içerisindeki önceki kontrolleri temizle
            panelContent.Controls.Clear();

            // Sipariş raporu formunu oluştur
            FrmSiparisRapor siparisRaporForm = new FrmSiparisRapor();
            siparisRaporForm.TopLevel = false; // Formun üst seviye değil, alt form olarak çalışmasını sağlar
            siparisRaporForm.FormBorderStyle = FormBorderStyle.None; // Kenarlık kaldırılır
            siparisRaporForm.Dock = DockStyle.Fill; // Paneli doldurur

            // Formu panele ekle
            panelContent.Controls.Add(siparisRaporForm);
            siparisRaporForm.Show();
        }
    }
}
