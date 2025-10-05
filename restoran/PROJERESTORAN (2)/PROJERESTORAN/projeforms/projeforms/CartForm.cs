using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Xml.Linq;

namespace projeforms
{
    internal class CartForm : Form
    {
        private ListBox lbCart;
        private Button btnPayment;
        private Label lblTotal;
        private decimal totalAmount; // Sınıf düzeyinde tanımlanan değişken
        private Button increaseButton;
        private Button decreaseButton;
        private Button removeButton;

        private class CartItem
        {
            public int ProductId { get; set; }  // Ürün ID
            public string ProductName { get; set; }  // Ürün adı
            public decimal Price { get; set; }  // Ürün fiyatı
            public int Quantity { get; set; }  // Ürün miktarı
            public decimal TotalPrice => Price * Quantity;  // Ürün toplam fiyatı

        }

        private List<CartItem> cartItems = new List<CartItem>(); // Sepet içeriği

        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.lbCart = new System.Windows.Forms.ListBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.increaseButton = new System.Windows.Forms.Button();
            this.decreaseButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(278, 604);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 16);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Toplam";
            // 
            // lbCart
            // 
            this.lbCart.FormattingEnabled = true;
            this.lbCart.ItemHeight = 16;
            this.lbCart.Location = new System.Drawing.Point(281, 72);
            this.lbCart.Name = "lbCart";
            this.lbCart.Size = new System.Drawing.Size(760, 516);
            this.lbCart.TabIndex = 2;
            this.lbCart.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbCart_DrawItem_1);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(281, 623);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(134, 23);
            this.btnPayment.TabIndex = 3;
            this.btnPayment.Text = "Ödeme Yap";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // increaseButton
            // 
            this.increaseButton.Location = new System.Drawing.Point(903, 72);
            this.increaseButton.Name = "increaseButton";
            this.increaseButton.Size = new System.Drawing.Size(42, 23);
            this.increaseButton.TabIndex = 4;
            this.increaseButton.Text = "Arttır";
            this.increaseButton.UseVisualStyleBackColor = true;
            this.increaseButton.Click += new System.EventHandler(this.increaseButton_Click);
            // 
            // decreaseButton
            // 
            this.decreaseButton.Location = new System.Drawing.Point(951, 72);
            this.decreaseButton.Name = "decreaseButton";
            this.decreaseButton.Size = new System.Drawing.Size(42, 23);
            this.decreaseButton.TabIndex = 5;
            this.decreaseButton.Text = "Azalt";
            this.decreaseButton.UseVisualStyleBackColor = true;
            this.decreaseButton.Click += new System.EventHandler(this.decreaseButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(999, 72);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(42, 23);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Sil";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // CartForm
            // 
            this.ClientSize = new System.Drawing.Size(1103, 718);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.decreaseButton);
            this.Controls.Add(this.increaseButton);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.lbCart);
            this.Controls.Add(this.lblTotal);
            this.Name = "CartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        public CartForm(List<int> cart)
        {

            InitializeComponent();

            // Eğer cart listesi boşsa, sorguyu döndürmeden çık
            if (cart.Count == 0)
            {
                MessageBox.Show("Sepetinizde ürün yok.");
                return;
            }

            DbHelper dbHelper = new DbHelper();
            StringBuilder query = new StringBuilder("SELECT UrunAdi, Fiyat, Aciklama FROM Menü WHERE UrunID IN(");

            foreach (var item in cart)
            {
                query.Append(item + ",");
            }

            query.Length--; // Son virgülü kaldırıyoruz
            query.Append(")");

            DataTable cartProducts = dbHelper.ExecuteReader(query.ToString(), null);

            // Ürünleri ekliyoruz ve toplam fiyatı hesaplıyoruz
            foreach (DataRow row in cartProducts.Rows)
            {
                string productName = row["UrunAdi"].ToString();
                decimal price = Convert.ToDecimal(row["Fiyat"]);
                string description = row["Aciklama"].ToString();

                // Yeni bir ürün oluşturuyoruz
                var cartItem = new CartItem
                {
                    ProductName = productName,
                    Price = price,
                    Quantity = 1 // Başlangıçta miktar 1
                };

                cartItems.Add(cartItem);
                lbCart.Items.Add($"{productName} - {price} ₺ - Açıklama: {description} - Miktar: {cartItem.Quantity}");
            }

            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            totalAmount = cartItems.Sum(item => item.Price * item.Quantity);
            lblTotal.Text = $"Toplam: {totalAmount} ₺";
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Sepetiniz boş, ödeme işlemi yapılamaz.");
                return;
            }

            // Ödeme Formu açılıyor
            PaymentForm paymentForm = new PaymentForm(totalAmount);
            paymentForm.ShowDialog();
        }

        // Her ürün için artırma, azaltma ve silme butonları
       
          
        private void lbCart_DrawItem_1(object sender, DrawItemEventArgs e)
        {
        }

        private void increaseButton_Click(object sender, EventArgs e)
        {
            // Seçili öğeyi bul
            int selectedIndex = lbCart.SelectedIndex;
            if (selectedIndex != -1)
            {
                cartItems[selectedIndex].Quantity++;
                UpdateCartList();
                UpdateTotalAmount();
            }
        }

        private void decreaseButton_Click(object sender, EventArgs e)
        {
            // Seçili öğeyi bul
            int selectedIndex = lbCart.SelectedIndex;
            if (selectedIndex != -1)
            {
                if (cartItems[selectedIndex].Quantity > 1)
                {
                    cartItems[selectedIndex].Quantity--;
                    UpdateCartList();
                    UpdateTotalAmount();
                }
                else
                {
                    MessageBox.Show("Miktar 1'in altına düşemez.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz.");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // Seçili öğeyi sil
            int selectedIndex = lbCart.SelectedIndex;
            if (selectedIndex != -1)
            {
                cartItems.RemoveAt(selectedIndex);
                UpdateCartList();
                UpdateTotalAmount();
            }
        }
        private void UpdateCartList()
        {
            lbCart.Items.Clear(); // Mevcut öğeleri temizle
            foreach (var item in cartItems)
            {
                lbCart.Items.Add($"{item.ProductName} - {item.Price} ₺ - Miktar: {item.Quantity}");
            }
        }

    }
}

