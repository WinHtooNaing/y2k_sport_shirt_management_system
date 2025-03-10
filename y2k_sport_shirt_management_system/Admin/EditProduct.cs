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

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class EditProduct : Form
    {
        private readonly int product_id;
        private readonly ProductRepository productRepository;
        public EditProduct(int id)
        {
            InitializeComponent();
            product_id = id;
            productRepository = new ProductRepository();    
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            LoadProductDetails();
        }
        private void LoadProductDetails()
        {
            try
            {
                // Create a ProductRepository instance to fetch product details
                var productRepository = new ProductRepository();

                // Fetch product by ID
                var product = productRepository.GetProductById(product_id);

                if (product != null)
                {
                    // Populate form fields with product details
                    nameTxt.Text = product.ProductName;
                    priceTxt.Text = product.ProductPrice.ToString();
                    qtyTxt.Text = product.ProductQuantity.ToString();
                    sizeTxt.SelectedItem = product.Size; // Assuming you have a ComboBox for categories
                    categoryTxt.SelectedItem = product.ProductCategory;
                }
                else
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string product_name = nameTxt.Text;
            string product_category = categoryTxt.SelectedItem.ToString();

            decimal product_price = decimal.Parse(priceTxt.Text);
            int product_qty = int.Parse(qtyTxt.Text);
            string size = sizeTxt.SelectedItem.ToString();
            if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(priceTxt.Text) || string.IsNullOrEmpty(qtyTxt.Text) || string.IsNullOrEmpty(sizeTxt.SelectedItem.ToString()))
            {
                MessageBox.Show("empty", "errr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Product product = new Product
            {
                Id = product_id,
                ProductName = product_name,
                ProductCategory = product_category,
                ProductPrice = product_price,
                ProductQuantity = product_qty,
                Size = size
            };
            if (productRepository.UpdateProduct(product)) {
                MessageBox.Show("Updated product successfully","update product",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Products products = new Products();
                products.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Updated product fail", "update product", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
