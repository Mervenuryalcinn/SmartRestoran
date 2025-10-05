using projeforms.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms

{

    internal class MüsteriForm : Form

    {
        
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel urunPanel;
        private PictureBox pb;
        private Label lblFiyat;
        private Label lblAciklama;
        private Label lblUrunAdi;
        private ComboBox cmbKategori;
        private TextBox txtMaxFiyat;
        private TextBox txtMinFiyat;
        private Button btnFiltrele;
        private Button BtnAddToCart;
        private Button button1;
        private Button btnAccountSettings;
        private PictureBox pictureBox;

        public MüsteriForm(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        private int LoggedInUserID; // Giriş yapan kullanıcının ID'sini tutar

        public MüsteriForm(int userID)
        {
            LoggedInUserID = userID; // Kullanıcı ID'yi constructor'dan al

            InitializeComponent();
            // Ürünleri yükleme
            LoadProducts();
            LoadCategories();
        }

        public MüsteriForm()
        {
        }

        private void LoadProducts(string kategori = null, decimal? minFiyat = null, decimal? maxFiyat = null)
        {
            DbHelper dbHelper = new DbHelper();

            // Build the dynamic query with filters
            StringBuilder query = new StringBuilder("SELECT UrunID,UrunAdi, Aciklama, Fiyat, Fotograf, KategoriAdi FROM Menü m JOIN Kategoriler k ON m.KategoriID = k.KategoriID WHERE 1=1");

            if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kategoriler")
            {
                query.Append(" AND k.KategoriAdi = @Kategori");
            }

            if (minFiyat.HasValue)
            {
                query.Append(" AND m.Fiyat >= @MinFiyat");
            }

            if (maxFiyat.HasValue)
            {
                query.Append(" AND m.Fiyat <= @MaxFiyat");
            }

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(kategori) && kategori != "Tüm Kategoriler")
            {
                parameters.Add(new SqlParameter("@Kategori", kategori));
            }

            if (minFiyat.HasValue)
            {
                parameters.Add(new SqlParameter("@MinFiyat", minFiyat));
            }

            if (maxFiyat.HasValue)
            {
                parameters.Add(new SqlParameter("@MaxFiyat", maxFiyat));
            }

            DataTable Menü = dbHelper.ExecuteReader(query.ToString(), parameters.ToArray());

            flowLayoutPanel1.Controls.Clear(); // Clear existing products

            // Add products to the flow layout panel
            foreach (DataRow row in Menü.Rows)
            {
                Panel urunPanel = new Panel
                {
                    Size = new Size(200, 300),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Ürün Resmi
                PictureBox pb = new PictureBox();
                pb.Size = new Size(180, 150);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Location = new Point(10, 10);

                // Resim verisi kontrolü
                if (row["Fotograf"] != DBNull.Value && row["Fotograf"] is byte[] fotografVerisi)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(fotografVerisi))
                        {
                            pb.Image = Image.FromStream(ms);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Resim yüklenirken hata oluştu: " + ex.Message);
                        pb.Image = Properties.Resources.cheessburger; // Varsayılan resim
                    }
                }
                else
                {
                    // Varsayılan resim
                    pb.Image = Properties.Resources.cheessburger;
                }

                // Product name
                Label lblUrunAdi = new Label
                {
                    Text = row["UrunAdi"].ToString(),
                    Location = new Point(10, 170),
                    AutoSize = true
                };

                // Product description
                Label lblAciklama = new Label
                {
                    Text = row["Aciklama"].ToString(),
                    Location = new Point(10, 190),
                    Size = new Size(180, 40)
                };

                // Product price
                Label lblFiyat = new Label
                {
                    Text = "Fiyat: " + row["Fiyat"].ToString() + " ₺",
                    Location = new Point(10, 240),
                    AutoSize = true
                };
                // Add the "Add to Cart" button
                Button btnAddToCart = new Button
                {
                    Text = "Sepete Ekle",
                    Location = new Point(10, 270),
                    Size = new Size(180, 30),
                    Tag = row["UrunID"] // Store product ID in Tag property
                };
                btnAddToCart.Click += BtnAddToCart_Click;

                // Add controls to the panel
                urunPanel.Controls.Add(pb);
                urunPanel.Controls.Add(lblUrunAdi);
                urunPanel.Controls.Add(lblAciklama);
                urunPanel.Controls.Add(lblFiyat);
                urunPanel.Controls.Add(btnAddToCart);

                // Add the panel to the flow layout panel
                flowLayoutPanel1.Controls.Add(urunPanel);
            }

    }

    private void InitializeComponent()
        {            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.urunPanel = new System.Windows.Forms.Panel();
            this.BtnAddToCart = new System.Windows.Forms.Button();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblUrunAdi = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.txtMaxFiyat = new System.Windows.Forms.TextBox();
            this.txtMinFiyat = new System.Windows.Forms.TextBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAccountSettings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.urunPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.urunPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(294, 118);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(879, 534);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // urunPanel
            // 
            this.urunPanel.Controls.Add(this.BtnAddToCart);
            this.urunPanel.Controls.Add(this.lblFiyat);
            this.urunPanel.Controls.Add(this.lblAciklama);
            this.urunPanel.Controls.Add(this.lblUrunAdi);
            this.urunPanel.Controls.Add(this.pb);
            this.urunPanel.Location = new System.Drawing.Point(3, 3);
            this.urunPanel.Name = "urunPanel";
            this.urunPanel.Size = new System.Drawing.Size(263, 240);
            this.urunPanel.TabIndex = 0;
            // 
            // BtnAddToCart
            // 
            this.BtnAddToCart.Location = new System.Drawing.Point(17, 204);
            this.BtnAddToCart.Name = "BtnAddToCart";
            this.BtnAddToCart.Size = new System.Drawing.Size(126, 23);
            this.BtnAddToCart.TabIndex = 4;
            this.BtnAddToCart.Text = "Sepete Ekle";
            this.BtnAddToCart.UseVisualStyleBackColor = true;
            this.BtnAddToCart.Click += new System.EventHandler(this.BtnAddToCart_Click);
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Location = new System.Drawing.Point(163, 150);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(44, 16);
            this.lblFiyat.TabIndex = 3;
            this.lblFiyat.Text = "label3";
            // 
            // lblAciklama
            // 
            this.lblAciklama.AutoSize = true;
            this.lblAciklama.Location = new System.Drawing.Point(163, 84);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(44, 16);
            this.lblAciklama.TabIndex = 2;
            this.lblAciklama.Text = "label2";
            // 
            // lblUrunAdi
            // 
            this.lblUrunAdi.AutoSize = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(163, 24);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(44, 16);
            this.lblUrunAdi.TabIndex = 1;
            this.lblUrunAdi.Text = "label1";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(17, 4);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 119);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(23, 161);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(148, 24);
            this.cmbKategori.TabIndex = 1;
            // 
            // txtMaxFiyat
            // 
            this.txtMaxFiyat.Location = new System.Drawing.Point(116, 234);
            this.txtMaxFiyat.Name = "txtMaxFiyat";
            this.txtMaxFiyat.Size = new System.Drawing.Size(52, 22);
            this.txtMaxFiyat.TabIndex = 3;
            // 
            // txtMinFiyat
            // 
            this.txtMinFiyat.Location = new System.Drawing.Point(12, 234);
            this.txtMinFiyat.Name = "txtMinFiyat";
            this.txtMinFiyat.Size = new System.Drawing.Size(52, 22);
            this.txtMinFiyat.TabIndex = 4;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(67, 303);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrele.TabIndex = 5;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(965, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sepetim";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAccountSettings
            // 
            this.btnAccountSettings.Location = new System.Drawing.Point(1068, 89);
            this.btnAccountSettings.Name = "btnAccountSettings";
            this.btnAccountSettings.Size = new System.Drawing.Size(86, 23);
            this.btnAccountSettings.TabIndex = 7;
            this.btnAccountSettings.Text = "Profil";
            this.btnAccountSettings.UseVisualStyleBackColor = true;
            this.btnAccountSettings.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // MüsteriForm
            // 
            this.ClientSize = new System.Drawing.Size(1233, 816);
            this.Controls.Add(this.btnAccountSettings);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.txtMinFiyat);
            this.Controls.Add(this.txtMaxFiyat);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MüsteriForm";
            this.Load += new System.EventHandler(this.MüsteriForm_Load_1);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.urunPanel.ResumeLayout(false);
            this.urunPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}

        private void MüsteriForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCategories()
        {
            

            DbHelper dbHelper = new DbHelper();
            string query = "SELECT KategoriID, KategoriAdi FROM Kategoriler";
            DataTable categories = dbHelper.ExecuteReader(query, null);

            cmbKategori.Items.Clear();
            cmbKategori.Items.Add("Tüm Kategoriler");

            foreach (DataRow row in categories.Rows)
            {
                cmbKategori.Items.Add(row["KategoriAdi"].ToString());
            }

            cmbKategori.SelectedItem = "Tüm Kategoriler"; // Set default selection
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            string selectedKategori = cmbKategori.SelectedItem.ToString();
            decimal? minFiyat = string.IsNullOrEmpty(txtMinFiyat.Text) ? (decimal?)null : decimal.Parse(txtMinFiyat.Text);
            decimal? maxFiyat = string.IsNullOrEmpty(txtMaxFiyat.Text) ? (decimal?)null : decimal.Parse(txtMaxFiyat.Text);

            LoadProducts(selectedKategori, minFiyat, maxFiyat); // Reload products with filters
        }

        private List<int> cart = new List<int>(); // To store product IDs of items in the cart

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                int UrunID = (int)btn.Tag; // Retrieve the product ID from the button's Tag

                // Add the product ID to the cart
                cart.Add(UrunID);

                // Optionally, show a message to the user
                MessageBox.Show("Ürün sepete eklendi!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open the CartForm and pass the cart data
            CartForm cartForm = new CartForm(cart); // 'cart' is the list storing the product IDs
            cartForm.Show(); // Show the CartForm
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            // Hesap yönetimi formunu aç
            AccountManagementForm accountForm = new AccountManagementForm();
            accountForm.Show();
        }

        private void MüsteriForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}