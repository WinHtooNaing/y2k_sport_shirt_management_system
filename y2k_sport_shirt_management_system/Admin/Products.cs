using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class Products : Form
    {
        private readonly ProductRepository productRepository;
        private readonly DatabaseConnection dbConnection;
        public Products()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            dbConnection = new DatabaseConnection();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }



        private void Products_Load(object sender, EventArgs e)
        {
            LoadProductsIntoGrid();
            admin_name.Text = SessionStorage.Session.userName;
        }
        private void LoadProductsIntoGrid()
        {
            try
            {
                // Fetch all products from the repository
                var products = productRepository.GetAllProducts();

                // Bind the products list to the DataGridView
                productsGridView.DataSource = products;


                // Add a "No" column for numbering
                if (!productsGridView.Columns.Contains("No"))
                {
                    DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "No",
                        HeaderText = "No",
                        ReadOnly = true
                    };
                    productsGridView.Columns.Insert(0, noColumn);
                }

                // Add Edit button
                if (!productsGridView.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        HeaderText = "",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    productsGridView.Columns.Add(editColumn);
                    editColumn.DefaultCellStyle.BackColor = Color.Orange;
                    editColumn.DefaultCellStyle.ForeColor = Color.White;
                }

                // Add Delete button
                if (!productsGridView.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    productsGridView.Columns.Add(deleteColumn);
                    deleteColumn.DefaultCellStyle.BackColor = Color.Red;
                    deleteColumn.DefaultCellStyle.ForeColor = Color.White;
                }

                // Populate "No" column with sequential numbers
                for (int i = 0; i < productsGridView.Rows.Count; i++)
                {
                    productsGridView.Rows[i].Cells["No"].Value = i + 1;
                }

                // Customize the DataGridView
                productsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Hide the "Id" column
                if (productsGridView.Columns.Contains("Id"))
                {
                    productsGridView.Columns["Id"].Visible = false; // Hide the ID column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is a button
            if (e.RowIndex >= 0 && (e.ColumnIndex == productsGridView.Columns["Edit"].Index || e.ColumnIndex == productsGridView.Columns["Delete"].Index))
            {
                // Get the selected product's ID
                int productId = Convert.ToInt32(productsGridView.Rows[e.RowIndex].Cells["Id"].Value);

                if (e.ColumnIndex == productsGridView.Columns["Edit"].Index)
                {
                    // Edit button clicked
                    EditProduct(productId);
                }
                else if (e.ColumnIndex == productsGridView.Columns["Delete"].Index)
                {
                    // Delete button clicked
                    DeleteProduct(productId);
                }
            }
        }

        private void EditProduct(int productId)
        {
            // TODO: Open a form for editing the product details, passing the productId
            MessageBox.Show($"Edit product with ID: {productId}");
        }

        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM products WHERE Id = @ProductId";

            try
            {
                dbConnection.OpenConnection();
                MySqlConnection connection = dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                int rowsAffected = cmd.ExecuteNonQuery(); // Executes the DELETE query
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Product Deleted successfully", "product delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductsIntoGrid();
                }
                else
                {
                    MessageBox.Show("Product not found or already deleted.", "product delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting product: " + ex.Message);
                throw;
            }
            finally
            {
                dbConnection.CloseConnection();
            }


        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void admin_name_Click(object sender, EventArgs e)
        {

        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.Show();
            this.Hide();
        }
    }
}
