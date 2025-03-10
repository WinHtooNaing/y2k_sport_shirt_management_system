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
using y2k_sport_shirt_management_system.Barcode;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;
using ZXing;

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class Products : Form
    {
        private readonly ProductRepository productRepository;
        private readonly DatabaseConnection dbConnection;
        private GenerateBarcode generateBarcode;
        public string productName;
        public Products()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            dbConnection = new DatabaseConnection();
            generateBarcode = new GenerateBarcode();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }



        private void Products_Load(object sender, EventArgs e)
        {
            LoadProductsIntoGrid();
            admin_name.Text = SessionStorage.Session.userName;
        }
        private void LoadProductsIntoGrid(string searchItem = "")
        {
            try
            {
                // Fetch all products from the repository
                var products = productRepository.GetAllProducts();

                if (!string.IsNullOrEmpty(searchItem))
                {
                    products = products.Where(
                        product => product.ProductName.Contains(searchItem, StringComparison.OrdinalIgnoreCase)
                        ).ToList();
                }

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
                // Add Barcode  button
                // Add Barcode button
                if (!productsGridView.Columns.Contains("GenerateBarcode"))
                {
                    DataGridViewButtonColumn barcodeColumn = new DataGridViewButtonColumn
                    {
                        Name = "GenerateBarcode",
                        HeaderText = "",
                        Text = "GenerateBarcode",
                        UseColumnTextForButtonValue = true
                    };
                    productsGridView.Columns.Add(barcodeColumn);
                    barcodeColumn.DefaultCellStyle.BackColor = Color.BurlyWood;
                    barcodeColumn.DefaultCellStyle.ForeColor = Color.White;
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
                if (productsGridView.Columns.Contains("BarCode"))
                {
                    productsGridView.Columns["Barcode"].Visible = false; // Hide the ID column
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
            if (e.RowIndex >= 0 && (e.ColumnIndex == productsGridView.Columns["Edit"].Index || e.ColumnIndex == productsGridView.Columns["Delete"].Index || e.ColumnIndex == productsGridView.Columns["GenerateBarcode"].Index))
            {
                // Get the selected product's ID
                int productId = Convert.ToInt32(productsGridView.Rows[e.RowIndex].Cells["Id"].Value);
                string barcode = productsGridView.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();
               

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
                else if (e.ColumnIndex == productsGridView.Columns["GenerateBarcode"].Index)
                {
                    generateBarcode.BarCodeGenerator(BarcodeFormat.CODE_128, iconPictureBox1, barcode);
                    productName = productsGridView.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                }
            }
        }

        private void EditProduct(int productId)
        {
            EditProduct editProduct = new EditProduct(productId);
            editProduct.Show();
            this.Hide();

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

        private void button2_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            LoadProductsIntoGrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void serachBtn_Click(object sender, EventArgs e)
        {
            string search = searchTxt.Text.Trim();
            LoadProductsIntoGrid(search);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            SellerManagement.Seller seller = new SellerManagement.Seller();
            seller.Show();
            this.Hide();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SellProduct.Products product = new SellProduct.Products();
            product.Show();
            this.Hide();
        }
        public void SaveImageFromPictureBox(PictureBox pic, string barcodeText)
        {
            try
            {
                if (pic.Image == null)
                {
                    MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Define the folder path on the desktop
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string barcodeFolderPath = Path.Combine(desktopPath, "barcode");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(barcodeFolderPath))
                {
                    Directory.CreateDirectory(barcodeFolderPath);
                }

                // Generate the file path for the barcode image
                string filePath = Path.Combine(barcodeFolderPath, $"{barcodeText}_barcode.png");

                // Save the image from the PictureBox to the file
                pic.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show($"Barcode saved to {filePath}", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (iconPictureBox1.Image == null)
            {
                MessageBox.Show("No barcode image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the barcode text (e.g., from the selected row in the DataGridView)
            string barcodeText = productName;
            // Save the image to the Desktop/barcode folder
            SaveImageFromPictureBox(iconPictureBox1, barcodeText);
        }
    }
}
