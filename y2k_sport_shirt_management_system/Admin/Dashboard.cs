using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Admin.SellerManagement;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class Dashboard : Form
    {
        private readonly DatabaseConnection _dbConnection;
        private readonly SellerRepository sellerRepository;
        public Dashboard()
        {
            InitializeComponent();
            _dbConnection = new DatabaseConnection();
            sellerRepository = new SellerRepository();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            admin_name.Text = SessionStorage.Session.userName;
            LoadAdminDetails();

            int seller_count = SellerCount();
            sellerCountTxt.Text = seller_count.ToString();

            int product_count = ProductCount();
            ProductCountTxt.Text = product_count.ToString();
        }
        private void LoadAdminDetails()
        {
            try
            {
                var sellerRepository = new SellerRepository();

                var admin = sellerRepository.GetSellerById(1);
                if (admin != null)
                {
                    nameTxt.Text = admin.Name;
                    accountIdTxt.Text = admin.AccountId;
                    passwordTxt.Text = admin.Password;
                }
                else
                {
                    MessageBox.Show("admin not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading seller details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int SellerCount()
        {
            string query = "SELECT COUNT(*) FROM users WHERE role=0;";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                return Convert.ToInt32(cmd.ExecuteScalar());



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                _dbConnection.CloseConnection();

            }
        }
        private int ProductCount()
        {
            string query = "SELECT COUNT(*) FROM products;";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                _dbConnection.CloseConnection();

            }
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Products product = new Products();
            product.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            SellerManagement.Seller seller = new SellerManagement.Seller();
            seller.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            string account_id = accountIdTxt.Text;
            string password = passwordTxt.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(account_id) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("empty", "errr", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            User admin = new User
            {
                Id = 1,
                Name = name,
                AccountId = account_id,
                Password = password
            };
            if (sellerRepository.UpdateSeller(admin))
            {
                MessageBox.Show("Updated admin successfully", "admin detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAdminDetails();
            }
            else
            {
                MessageBox.Show("Updated admin fail", "admin detail", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '*';
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SellProduct.Products products = new SellProduct.Products();
            products.Show();
            this.Hide();
        }
    }
}
