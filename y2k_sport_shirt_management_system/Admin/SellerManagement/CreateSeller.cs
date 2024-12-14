using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;

namespace y2k_sport_shirt_management_system.Admin.SellerManagement
{
    public partial class CreateSeller : Form
    {
        private readonly SellerRepository sellerRepository;

        public CreateSeller()
        {
            InitializeComponent();
            sellerRepository = new SellerRepository();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
             string seller_name = nameTxt.Text;
            string seller_account_id = accountIdTxt.Text;
            string seller_password = passwordTxt.Text;
            if(string.IsNullOrEmpty(seller_name) || string.IsNullOrEmpty(seller_account_id) || string.IsNullOrEmpty(seller_password))
            {
                MessageBox.Show("empty", "errr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            User newUser = new User
            {
                Name = seller_name,
                AccountId = seller_account_id,
                Password = seller_password,
            };
            
            if (sellerRepository.AddSeller(newUser)) {
                MessageBox.Show("Seller added successfully!", "create Seller", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Seller seller = new Seller();
                seller.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add Seller!", "create Seller", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
