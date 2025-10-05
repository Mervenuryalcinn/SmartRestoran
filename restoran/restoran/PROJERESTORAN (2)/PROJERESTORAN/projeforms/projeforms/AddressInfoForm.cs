using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    internal class AddressInfoForm:Form
    {
        private TextBox txtAdres;
        private Button btnSaveAddress;

        public AddressInfoForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnSaveAddress = new System.Windows.Forms.Button();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSaveAddress
            // 
            this.btnSaveAddress.Location = new System.Drawing.Point(347, 328);
            this.btnSaveAddress.Name = "btnSaveAddress";
            this.btnSaveAddress.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAddress.TabIndex = 1;
            this.btnSaveAddress.Text = "Kaydet";
            this.btnSaveAddress.UseVisualStyleBackColor = true;
            this.btnSaveAddress.Click += new System.EventHandler(this.btnSaveAddress_Click);
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(347, 207);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(100, 22);
            this.txtAdres.TabIndex = 2;
            // 
            // AddressInfoForm
            // 
            this.ClientSize = new System.Drawing.Size(835, 756);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.btnSaveAddress);
            this.Name = "AddressInfoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSaveAddress_Click(object sender, EventArgs e)
        {
            // Adres bilgilerini güncelle
            DbHelper dbHelper = new DbHelper();
            string query = "UPDATE MusteriAdres SET Adres = @Adres WHERE MusteriID = @MusteriID";
            SqlParameter[] parameters = {
                new SqlParameter("@Adres", txtAdres.Text),
                new SqlParameter("@MusteriID", 1) // Örnek: Müşteri ID'si 1
            };

            dbHelper.ExecuteNonQuery(query, parameters);
            MessageBox.Show("Adres bilgileriniz güncellendi!");
        }
    }
    }

