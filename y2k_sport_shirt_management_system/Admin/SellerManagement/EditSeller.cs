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
    public partial class EditSeller : Form
    {
        private readonly int seller_id;
        private readonly SellerRepository sellerRepository;
        public EditSeller(int id)
        {
            InitializeComponent();
            seller_id = id;
            sellerRepository = new SellerRepository();

        }

        private void EditSeller_Load(object sender, EventArgs e)
        {
            LoadSellerDetail();
        }
        private void LoadSellerDetail()
        {
            try
            {
                var sellerRepository = new SellerRepository();

                var seller = sellerRepository.GetSellerById(seller_id);
                if (seller != null)
                {
                    nameTxt.Text = seller.Name;
                    accountIdTxt.Text = seller.AccountId;
                    passwordTxt.Text = seller.Password;
                }
                else
                {
                    MessageBox.Show("Seller not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seller details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            User seller = new User
            {
                Id = seller_id,
                Name = seller_name,
                AccountId = seller_account_id,
                Password = seller_password
            };
            if (sellerRepository.UpdateSeller(seller)) {
                MessageBox.Show("Updated seller successfully", "seller product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Seller sellers= new Seller();
                sellers.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Updated seller fail", "update seller", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
