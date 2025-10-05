using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeforms
{
    internal class AccountManagementForm:Form
    {
        private Button btnOrderTracking;
        private Button btnUpdateAddress;
        private Button btnEditPersonalInfo;

        public AccountManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnOrderTracking = new System.Windows.Forms.Button();
            this.btnUpdateAddress = new System.Windows.Forms.Button();
            this.btnEditPersonalInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrderTracking
            // 
            this.btnOrderTracking.Location = new System.Drawing.Point(219, 125);
            this.btnOrderTracking.Name = "btnOrderTracking";
            this.btnOrderTracking.Size = new System.Drawing.Size(99, 23);
            this.btnOrderTracking.TabIndex = 0;
            this.btnOrderTracking.Text = "Sipariş Takibi";
            this.btnOrderTracking.UseVisualStyleBackColor = true;
            this.btnOrderTracking.Click += new System.EventHandler(this.btnOrderTracking_Click);
            // 
            // btnUpdateAddress
            // 
            this.btnUpdateAddress.Location = new System.Drawing.Point(219, 225);
            this.btnUpdateAddress.Name = "btnUpdateAddress";
            this.btnUpdateAddress.Size = new System.Drawing.Size(99, 23);
            this.btnUpdateAddress.TabIndex = 2;
            this.btnUpdateAddress.Text = "Adres";
            this.btnUpdateAddress.UseVisualStyleBackColor = true;
            this.btnUpdateAddress.Click += new System.EventHandler(this.btnUpdateAddress_Click);
            // 
            // btnEditPersonalInfo
            // 
            this.btnEditPersonalInfo.Location = new System.Drawing.Point(219, 172);
            this.btnEditPersonalInfo.Name = "btnEditPersonalInfo";
            this.btnEditPersonalInfo.Size = new System.Drawing.Size(99, 23);
            this.btnEditPersonalInfo.TabIndex = 1;
            this.btnEditPersonalInfo.Text = "Personel Bilgi";
            this.btnEditPersonalInfo.UseVisualStyleBackColor = true;
            this.btnEditPersonalInfo.Click += new System.EventHandler(this.btnEditPersonalInfo_Click);
            // 
            // AccountManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(829, 585);
            this.Controls.Add(this.btnUpdateAddress);
            this.Controls.Add(this.btnOrderTracking);
            this.Controls.Add(this.btnEditPersonalInfo);
            this.Name = "AccountManagementForm";
            this.ResumeLayout(false);

        }

        private void btnEditPersonalInfo_Click(object sender, EventArgs e)
        {
            // Kişisel bilgiler formunu aç
            PersonalInfoForm personalInfoForm = new PersonalInfoForm();
            personalInfoForm.Show();
        }

        private void btnOrderTracking_Click(object sender, EventArgs e)
        {
            // Sipariş takibi formunu aç
            OrderTrackingForm orderTrackingForm = new OrderTrackingForm(new List<int>()); // Sepet verisini gönderebilirsiniz
            orderTrackingForm.Show();
        }

        private void btnUpdateAddress_Click(object sender, EventArgs e)
        {
            // Adres bilgileri formunu aç
            AddressInfoForm addressInfoForm = new AddressInfoForm();
            addressInfoForm.Show();
        }
    }

}
