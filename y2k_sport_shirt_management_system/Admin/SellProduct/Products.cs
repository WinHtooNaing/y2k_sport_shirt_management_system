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

namespace y2k_sport_shirt_management_system.Admin.SellProduct
{
    public partial class Products : Form
    {
        private readonly SellProductRepository sellProductRepository;
        public Products()
        {
            InitializeComponent();
            sellProductRepository = new SellProductRepository();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            SellerManagement.Seller seller = new SellerManagement.Seller();
            seller.Show();
            this.Hide();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
            this.Hide();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadSellProductsIntoGrid();
            LoadSellerNameIntoComboBox();
        }
        private void LoadSellProductsIntoGrid(string searchItem = "")
        {
            try
            {
                // Fetch all products from the repository
                var products = sellProductRepository.GetDailySoldProducts();

                if (!string.IsNullOrEmpty(searchItem))
                {
                    products = products.Where(
                        product => product.sellerName.Contains(searchItem, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                }

                // Bind the products list to the DataGridView
                sellProductsGridView.DataSource = products;


                // Add a "No" column for numbering
                if (!sellProductsGridView.Columns.Contains("No"))
                {
                    DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "No",
                        HeaderText = "No",
                        ReadOnly = true
                    };
                    sellProductsGridView.Columns.Insert(0, noColumn);
                }




                // Populate "No" column with sequential numbers
                for (int i = 0; i < sellProductsGridView.Rows.Count; i++)
                {
                    sellProductsGridView.Rows[i].Cells["No"].Value = i + 1;
                }

                // Customize the DataGridView
                sellProductsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Hide the "Id" column
                if (sellProductsGridView.Columns.Contains("Id"))
                {
                    sellProductsGridView.Columns["Id"].Visible = false; // Hide the ID column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadSellerNameIntoComboBox()
        {

            List<string> sellerName = sellProductRepository.GetAllSellerNames();

            if (sellerName.Count > 0)
            {
                sellerComboBox.DataSource = sellerName; // Bind the list to the ComboBox
                sellerComboBox.SelectedIndex = -1;    // Optional: Keep no selection initially
            }
            else
            {
                MessageBox.Show("No users found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void serachBtn_Click(object sender, EventArgs e)
        {

            if (sellerComboBox.SelectedIndex != -1)
            {
                string selectedSellerName = sellerComboBox.SelectedItem.ToString();
                LoadSellProductsIntoGrid(selectedSellerName);
            }
            else
            {
                MessageBox.Show("Please select a seller name from the dropdown.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            LoadSellerNameIntoComboBox();
            LoadSellProductsIntoGrid();
        }
    }
}
