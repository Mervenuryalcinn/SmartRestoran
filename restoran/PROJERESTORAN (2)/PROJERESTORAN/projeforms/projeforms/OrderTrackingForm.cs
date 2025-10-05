using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projeforms
{
    public partial class OrderTrackingForm : Form
    {
        private ListBox lstOrders;
        private List<int> cart;

        public OrderTrackingForm(List<int> cart)
        {
            InitializeComponent();
            this.cart = cart;
        }

        private void InitializeComponent()
        {
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.ItemHeight = 16;
            this.lstOrders.Location = new System.Drawing.Point(370, 138);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(120, 84);
            this.lstOrders.TabIndex = 0;
            // 
            // OrderTrackingForm
            // 
            this.ClientSize = new System.Drawing.Size(825, 645);
            this.Controls.Add(this.lstOrders);
            this.Name = "OrderTrackingForm";
            this.Load += new System.EventHandler(this.OrderTrackingForm_Load);
            this.ResumeLayout(false);

        }

        private void OrderTrackingForm_Load(object sender, EventArgs e)
        {
            string query = @"
    SELECT SiparisID, Durum 
    FROM Siparişler
    WHERE MusteriID = (
        SELECT MusteriID 
        FROM Kullanıcılar 
        WHERE Rol = 'Müşteri' AND KullaniciID = @KullaniciID
    )";

            // Tek bir parametre varsa
            SqlParameter parameter = new SqlParameter("@KullaniciID", SqlDbType.Int) { Value = 1 };

            // Parametreleri diziye ekleyin
            SqlParameter[] parameters = new SqlParameter[] { parameter };

            // ExecuteReader metodunu parametre dizisi ile çağırın
            DbHelper dbHelper = new DbHelper();
            DataTable siparisler = dbHelper.ExecuteReader(query, parameters);

            // Sipariş bilgilerini listeye ekle
            foreach (DataRow row in siparisler.Rows)  // Burada 'siparisler' kullanmalısınız.
            {
                string orderInfo = $"Sipariş ID: {row["SiparisID"]}, Durum: {row["Durum"]}";
                lstOrders.Items.Add(orderInfo);
            }
        }
    }
}
