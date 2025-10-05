using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace projeforms
{
    internal class PaymentForm: Form
    {
        private TextBox txtName;
        private TextBox txtSurname;
        private TextBox txtAddress;
        private TextBox txtTelefon;
        private Label lblTotalAmount;
        private Button btnPay;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private decimal totalAmount;
        private SqlDbType currentUserId;

        public PaymentForm(decimal totalAmount)
        {
            this.totalAmount = totalAmount;
            InitializeComponent();
            lblTotalAmount.Text = $"Toplam Tutar: {totalAmount} ₺"; // Toplam tutarı etikete yazdır
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(460, 116);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 0;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(460, 176);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 22);
            this.txtSurname.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(460, 241);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 22);
            this.txtAddress.TabIndex = 2;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(460, 294);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(100, 22);
            this.txtTelefon.TabIndex = 3;
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(449, 422);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(149, 23);
            this.btnPay.TabIndex = 5;
            this.btnPay.Text = "ÖDEME YAP";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(472, 356);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(88, 16);
            this.lblTotalAmount.TabIndex = 6;
            this.lblTotalAmount.Text = "Toplam Tutar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Adınızı Giriniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Soyadı Giriniz:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Adres Bilgilerinizi Giriniz:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telefon:";
            // 
            // PaymentForm
            // 
            this.ClientSize = new System.Drawing.Size(1126, 704);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Name = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public class SiparisItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal TotalPrice { get; set; }
        }


        List<SiparisItem> cartItems = new List<SiparisItem>();

        private void btnPay_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string address = txtAddress.Text;
            string telefon = txtTelefon.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DbHelper dbHelper = new DbHelper();

                // Sipariş Ekleme
                string insertOrderQuery = "INSERT INTO Siparisler (KullaniciID, ToplamTutar, Durum, Tarih, Adres) " +
                                           "OUTPUT INSERTED.SiparisID " +
                                           "VALUES (@KullaniciID, @ToplamTutar, @Durum, @Tarih, @Adres)";
                List<SqlParameter> orderParameters = new List<SqlParameter>
                {
                    new SqlParameter("@KullaniciID", "CurrentUserId"), // Giriş yapan kullanıcı ID'si
                    new SqlParameter("@ToplamTutar", totalAmount),
                    new SqlParameter("@Durum", "Bekleniyor"),
                    new SqlParameter("@Tarih", DateTime.Now),
                    new SqlParameter("@Adres", address)
                };

                int siparisId = (int)dbHelper.ExecuteScalar(insertOrderQuery, orderParameters);

                List<SiparisItem> cartItems = new List<SiparisItem>();

                string query = "SELECT UrunID, Adet, BirimFiyat, (Adet * BirimFiyat) AS ToplamFiyat FROM Sepet WHERE KullaniciID = @KullaniciID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@KullaniciID", currentUserId)
                };

                DataTable dataTable = dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dataTable.Rows)
                {
                    cartItems.Add(new SiparisItem
                    {
                        ProductId = Convert.ToInt32(row["UrunID"]),
                        Quantity = Convert.ToInt32(row["Adet"]),
                        Price = Convert.ToDecimal(row["BirimFiyat"]),
                        TotalPrice = Convert.ToDecimal(row["ToplamFiyat"])
                    });
                }


                // Sipariş Detayları Ekleme
                foreach (var item in cartItems)
                {
                    string insertDetailQuery = "INSERT INTO SiparisDetaylari (SiparisID, UrunID, Adet, BirimFiyat, ToplamFiyat) " +
                                               "VALUES (@SiparisID, @UrunID, @Adet, @BirimFiyat, @ToplamFiyat)";
                    List<SqlParameter> detailParameters = new List<SqlParameter>
                {
                    new SqlParameter("@SiparisID", siparisId),
                    new SqlParameter("@UrunID", item.ProductId),
                    new SqlParameter("@Adet", item.Quantity),
                    new SqlParameter("@BirimFiyat", item.Price),
                    new SqlParameter("@ToplamFiyat", item.TotalPrice)
                };

                    dbHelper.ExecuteNonQuery1(insertDetailQuery, detailParameters);
                }

                MessageBox.Show($"Ödeme başarıyla tamamlandı!\n\nAd: {name} {surname}\nAdres: {address}",
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {

        }

        public override bool Equals(object obj)
        {
            return obj is PaymentForm form &&
                   this.totalAmount == form.totalAmount;
        }

        public override int GetHashCode()
        {
            return -901287175 + this.totalAmount.GetHashCode();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

