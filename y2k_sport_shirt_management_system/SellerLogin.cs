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
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system
{
    public partial class SellerLogin : Form
    {
        private DatabaseConnection dbConnection;
        public SellerLogin()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLogin admin = new AdminLogin();
            admin.Show();
            this.Hide();
        }

        private void SellerLogin_Load(object sender, EventArgs e)
        {

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

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string id = idTxt.Text;
            string password = passwordTxt.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Account ID and Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                dbConnection.OpenConnection();
                MySqlConnection connection = dbConnection.GetConnection();

                string query = "SELECT * FROM users WHERE account_id = @id AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int role = Convert.ToInt32(reader["role"]);
                    string name = reader["name"].ToString();
                    string accountId = reader["account_id"].ToString();
                    SessionStorage.Session.userName = name;
                    SessionStorage.Session.accountId = accountId;

                    reader.Close();
                    dbConnection.CloseConnection();

                    // Navigate based on role
                    if (role == 0) // Seller
                    {
                        MessageBox.Show($"Welcome, Seller {name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Seller.Dashboard adminDashboard = new Seller.Dashboard(); // Replace with your actual Admin Dashboard form
                        this.Hide();
                        adminDashboard.Show();
                    }

                    else
                    {
                        MessageBox.Show("Invalid role. Please contact support.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Account ID or Password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }
    }
}
