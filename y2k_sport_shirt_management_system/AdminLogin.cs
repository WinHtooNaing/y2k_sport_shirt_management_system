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
    public partial class AdminLogin : Form
    {
        private DatabaseConnection dbConnection;

        public AdminLogin()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SellerLogin seller = new SellerLogin();
            seller.Show();
            this.Hide();
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

                    reader.Close();
                    dbConnection.CloseConnection();

                    // Navigate based on role
                    if (role == 1) // Admin
                    {
                        MessageBox.Show($"Welcome, Admin {name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Admin.Dashboard adminDashboard = new Admin.Dashboard(name); // Replace with your actual Admin Dashboard form
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
            catch (Exception ex) {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

        }
    }
}
