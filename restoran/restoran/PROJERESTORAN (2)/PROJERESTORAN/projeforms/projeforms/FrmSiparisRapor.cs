using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    internal class FrmSiparisRapor:Form
    {
        public FrmSiparisRapor()
        {
            InitializeComponent();
        }

        private DataGridView dgvWeeklyOrders;
        private DataGridView dgvMonthlyOrders;
        private DataGridView dgvTopSellingProducts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvDailyOrders;

        private void InitializeComponent()
        {
            this.dgvDailyOrders = new System.Windows.Forms.DataGridView();
            this.dgvWeeklyOrders = new System.Windows.Forms.DataGridView();
            this.dgvMonthlyOrders = new System.Windows.Forms.DataGridView();
            this.dgvTopSellingProducts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellingProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDailyOrders
            // 
            this.dgvDailyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDailyOrders.Location = new System.Drawing.Point(1, 159);
            this.dgvDailyOrders.Name = "dgvDailyOrders";
            this.dgvDailyOrders.RowHeadersWidth = 51;
            this.dgvDailyOrders.RowTemplate.Height = 24;
            this.dgvDailyOrders.Size = new System.Drawing.Size(240, 150);
            this.dgvDailyOrders.TabIndex = 0;
            // 
            // dgvWeeklyOrders
            // 
            this.dgvWeeklyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeeklyOrders.Location = new System.Drawing.Point(340, 159);
            this.dgvWeeklyOrders.Name = "dgvWeeklyOrders";
            this.dgvWeeklyOrders.RowHeadersWidth = 51;
            this.dgvWeeklyOrders.RowTemplate.Height = 24;
            this.dgvWeeklyOrders.Size = new System.Drawing.Size(240, 150);
            this.dgvWeeklyOrders.TabIndex = 1;
            // 
            // dgvMonthlyOrders
            // 
            this.dgvMonthlyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonthlyOrders.Location = new System.Drawing.Point(683, 159);
            this.dgvMonthlyOrders.Name = "dgvMonthlyOrders";
            this.dgvMonthlyOrders.RowHeadersWidth = 51;
            this.dgvMonthlyOrders.RowTemplate.Height = 24;
            this.dgvMonthlyOrders.Size = new System.Drawing.Size(240, 150);
            this.dgvMonthlyOrders.TabIndex = 2;
            // 
            // dgvTopSellingProducts
            // 
            this.dgvTopSellingProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSellingProducts.Location = new System.Drawing.Point(358, 387);
            this.dgvTopSellingProducts.Name = "dgvTopSellingProducts";
            this.dgvTopSellingProducts.RowHeadersWidth = 51;
            this.dgvTopSellingProducts.RowTemplate.Height = 24;
            this.dgvTopSellingProducts.Size = new System.Drawing.Size(240, 150);
            this.dgvTopSellingProducts.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Günlük Siparişler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(349, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Haftalık Siparişler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(688, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Aylık Siparişler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(366, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "En Çok Satılan Ürünler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sipariş İşlemleri";
            // 
            // FrmSiparisRapor
            // 
            this.ClientSize = new System.Drawing.Size(1477, 689);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTopSellingProducts);
            this.Controls.Add(this.dgvMonthlyOrders);
            this.Controls.Add(this.dgvWeeklyOrders);
            this.Controls.Add(this.dgvDailyOrders);
            this.Name = "FrmSiparisRapor";
            this.Load += new System.EventHandler(this.FrmSiparisRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellingProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmSiparisRapor_Load(object sender, EventArgs e)
        {
            // Günlük, haftalık ve aylık raporları yükle
            LoadDailyOrders();
            LoadWeeklyOrders();
            LoadMonthlyOrders();
            LoadTopSellingProducts();
        }
        private void LoadDailyOrders()
        {
            string query = "SELECT SiparisID, Tarih, ToplamTutar FROM Siparişler WHERE CAST(Tarih AS DATE) = CAST(GETDATE() AS DATE)";
            LoadDataToGrid(query, dgvDailyOrders);
        }

        private void LoadWeeklyOrders()
        {
            string query = "SELECT SiparisID, Tarih, ToplamTutar FROM Siparişler WHERE DATEPART(ISO_WEEK, Tarih) = DATEPART(ISO_WEEK, GETDATE())";
            LoadDataToGrid(query, dgvWeeklyOrders);
        }

        private void LoadMonthlyOrders()
        {
            string query = "SELECT SiparisID, Tarih, ToplamTutar FROM Siparişler WHERE MONTH(Tarih) = MONTH(GETDATE()) AND YEAR(Tarih) = YEAR(GETDATE())";
            LoadDataToGrid(query, dgvMonthlyOrders);
        }
        private void LoadTopSellingProducts()
        {
            string query = @"
                SELECT TOP 10 UrunAdi, SUM(Adet) AS ToplamAdet
                FROM SiparişDetayları
                INNER JOIN Menü ON SiparişDetayları.UrunID = Menü.UrunID
                GROUP BY UrunAdi
                ORDER BY ToplamAdet DESC";
            LoadDataToGrid(query, dgvTopSellingProducts);
        }
 private void LoadDataToGrid(string query, DataGridView grid)
        {
            try
            {
                DbHelper dbHelper = new DbHelper();  // DbHelper nesnesi oluşturuluyor
                DataTable table = dbHelper.ExecuteReader(query, null); // Sorguyu çalıştırıp, DataTable döndürülüyor
                grid.DataSource = table;  // DataGridView'e veri yükleniyor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
