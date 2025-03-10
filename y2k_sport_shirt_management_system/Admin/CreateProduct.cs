using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Barcode;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;

namespace y2k_sport_shirt_management_system.Admin
{
    public partial class CreateProduct : Form
    {
        private readonly ProductRepository productRepository;
        private readonly GenerateBarcode generateBarcode;
        public CreateProduct()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            generateBarcode = new GenerateBarcode();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string product_name = nameTxt.Text;
            string product_category = categoryTxt.SelectedItem.ToString();
            decimal product_price = decimal.Parse(priceTxt.Text);
            int product_qty = int.Parse(qtyTxt.Text);
            string size = sizeTxt.SelectedItem.ToString();
            if (string.IsNullOrEmpty(nameTxt.Text) || string.IsNullOrEmpty(product_category) || string.IsNullOrEmpty(priceTxt.Text) || string.IsNullOrEmpty(qtyTxt.Text) || string.IsNullOrEmpty(sizeTxt.SelectedItem.ToString()))
            {
                MessageBox.Show("empty", "errr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string barcode = DateTime.Now.ToString("yyyyMMddHHmmss");

            Product newProduct = new Product
            {
                ProductName = product_name,
                ProductPrice = product_price,
                ProductQuantity = product_qty,
                ProductCategory = product_category,
                Size = size,
                Barcode = barcode
            };
            if (productRepository.AddProduct(newProduct))
            {

                MessageBox.Show("Product added successfully!", "create prduct", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Products product = new Products();
                product.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to add product!", "create prduct", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
