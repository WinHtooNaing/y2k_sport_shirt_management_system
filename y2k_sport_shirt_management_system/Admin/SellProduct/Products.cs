﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }
        private void LoadSellProductsIntoGrid(string searchItem = "")
        {
            try
            {
                // Fetch all products from the repository
                var products = sellProductRepository.GetAllProducts();

                if (!string.IsNullOrEmpty(searchItem))
                {
                    products = products.Where(
                        product => product.ProductName.Contains(searchItem, StringComparison.OrdinalIgnoreCase)
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

    }
}