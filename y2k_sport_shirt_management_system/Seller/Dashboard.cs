
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using y2k_sport_shirt_management_system.Admin;
using y2k_sport_shirt_management_system.Model;
using y2k_sport_shirt_management_system.Repository;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
namespace y2k_sport_shirt_management_system.Seller
{
    public partial class Dashboard : Form
    {

        private readonly ProductRepository productRepository;
        private readonly FakeSellProductRepository fakeSellProductRepository;
        
      
        public Dashboard()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            fakeSellProductRepository = new FakeSellProductRepository();
            
           
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            seller_name.Text = SessionStorage.Session.userName;
            LoadProductsIntoGrid();
            LoadFakeProductsIntoGrid();






            fakeProductsGridView.CellEndEdit += fakeProductsGridView_CellEndEdit;
            fakeProductsGridView.CellValueChanged += fakeProductsGridView_CellValueChanged;

           


        }
        private void fakeProductsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && fakeProductsGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                // Commit changes to ensure CellValueChanged is triggered
                fakeProductsGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //UpdateTotalPrice();
            }
        }
        private void fakeProductsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && fakeProductsGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                try
                {
                    // Get the updated quantity value
                    var quantityCell = fakeProductsGridView.Rows[e.RowIndex].Cells["Quantity"];
                    int quantity = int.TryParse(quantityCell.Value?.ToString(), out int parsedQuantity) ? parsedQuantity : 1;

                    if (quantity < 1) // Validate quantity
                    {
                        MessageBox.Show("Quantity must be 1 or greater.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        quantityCell.Value = 1; // Reset invalid quantity to default (1)
                        quantity = 1;
                    }

                    // Get the product price
                    decimal price = Convert.ToDecimal(fakeProductsGridView.Rows[e.RowIndex].Cells["ProductPrice"].Value);

                    // Calculate and update the Total Price
                    fakeProductsGridView.Rows[e.RowIndex].Cells["TotalPrice"].Value = quantity * price;

                    UpdateTotalPrice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating total price: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
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
                if (!productsGridView.Columns.Contains("SellToList"))
                {
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                    {
                        Name = "SellToList",
                        HeaderText = "",
                        Text = "Sell to list",
                        UseColumnTextForButtonValue = true
                    };
                    productsGridView.Columns.Add(editColumn);
                    editColumn.DefaultCellStyle.BackColor = Color.Orange;
                    editColumn.DefaultCellStyle.ForeColor = Color.White;
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

        private void LoadFakeProductsIntoGrid()
        {
            try
            {


                var products = fakeSellProductRepository.GetAllProducts();



                // Bind the products list to the DataGridView
                fakeProductsGridView.DataSource = products;


                // Add a "No" column for numbering
                if (!fakeProductsGridView.Columns.Contains("No"))
                {
                    DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "No",
                        HeaderText = "No",
                        ReadOnly = true
                    };
                    fakeProductsGridView.Columns.Insert(0, noColumn);
                }
                // Add a "Quantity" column if not exists
                if (!fakeProductsGridView.Columns.Contains("Quantity"))
                {
                    DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "Quantity",
                        HeaderText = "Quantity",
                        DefaultCellStyle = new DataGridViewCellStyle { NullValue = "1" } // Default value
                    };
                    fakeProductsGridView.Columns.Insert(6, qtyColumn);
                }
                // Add a "Total Price" column if not exists
                if (!fakeProductsGridView.Columns.Contains("TotalPrice"))
                {
                    DataGridViewTextBoxColumn totalPriceColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "TotalPrice",
                        HeaderText = "Total Price",
                        ReadOnly = true // Total price is calculated, not editable
                    };
                    fakeProductsGridView.Columns.Insert(7, totalPriceColumn);
                }
                // Add Delete button
                if (!fakeProductsGridView.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteCoulmn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    fakeProductsGridView.Columns.Add(deleteCoulmn);
                    deleteCoulmn.DefaultCellStyle.BackColor = Color.Orange;
                    deleteCoulmn.DefaultCellStyle.ForeColor = Color.White;
                }



                // Populate "No" column with sequential numbers
                for (int i = 0; i < fakeProductsGridView.Rows.Count; i++)
                {
                    fakeProductsGridView.Rows[i].Cells["No"].Value = i + 1;

                    // Set initial total price (quantity * price)
                    int quantity = Convert.ToInt32(fakeProductsGridView.Rows[i].Cells["Quantity"].Value ?? 1);
                    decimal price = Convert.ToDecimal(fakeProductsGridView.Rows[i].Cells["ProductPrice"].Value);
                    fakeProductsGridView.Rows[i].Cells["TotalPrice"].Value = quantity * price;
                    

                }
                fakeProductsGridView.RowsAdded += (s, e) =>
                {
                    for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
                    {
                        fakeProductsGridView.Rows[i].Cells["Quantity"].Value = 1;
                    }
                };

                // Customize the DataGridView
                fakeProductsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Hide the "Id" column
                if (fakeProductsGridView.Columns.Contains("Id"))
                {
                    fakeProductsGridView.Columns["Id"].Visible = false; // Hide the ID column
                }
                // Hide the "Id" column
                if (fakeProductsGridView.Columns.Contains("ProductId"))
                {
                    fakeProductsGridView.Columns["ProductId"].Visible = false; // Hide the ID column
                }
                // Hide the "Product Price" column
                if (fakeProductsGridView.Columns.Contains("ProductPrice"))
                {
                    fakeProductsGridView.Columns["ProductPrice"].Visible = false;
                }

                UpdateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void productsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is a button
            if (e.RowIndex >= 0 && (e.ColumnIndex == productsGridView.Columns["SellToList"].Index))
            {
                // Get the selected product's ID
                int productId = Convert.ToInt32(productsGridView.Rows[e.RowIndex].Cells["Id"].Value);

                if (e.ColumnIndex == productsGridView.Columns["SellToList"].Index)
                {
                    SellToList(productId);
                }

            }
        }
        private void SellToList(int productId)
        {
            try
            {
                // Create a ProductRepository instance to fetch product details
                var productRepository = new ProductRepository();

                // Fetch product by ID
                var product = productRepository.GetProductById(productId);

                if (product != null)
                {
                    FakeSellProduct newProduct = new FakeSellProduct
                    {
                        ProductId = productId,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductCategory = product.ProductCategory
                    };
                    if (fakeSellProductRepository.AddProduct(newProduct))
                    {
                        LoadFakeProductsIntoGrid();
                    }
                    else
                    {
                        MessageBox.Show("Product  already exists.", "create prduct", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                   
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

        private void serachBtn_Click(object sender, EventArgs e)
        {
            string search = searchTxt.Text.Trim();
            LoadProductsIntoGrid(search);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            searchTxt.Text = "";
            LoadProductsIntoGrid();
        }

        private void fakeProductsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is a button
            if (e.RowIndex >= 0 && (e.ColumnIndex == fakeProductsGridView.Columns["Delete"].Index))
            {
                // Get the selected product's ID
                int productId = Convert.ToInt32(fakeProductsGridView.Rows[e.RowIndex].Cells["Id"].Value);

                if (e.ColumnIndex == fakeProductsGridView.Columns["Delete"].Index)
                {
                    DeleteById(productId);
                }

            }
        }
        private void DeleteById(int id)
        {
            if (fakeSellProductRepository.DeleteProduct(id))
            {
                LoadFakeProductsIntoGrid();
            }
            else
            {
                MessageBox.Show("product deleted fail", "Seller Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancleBtn_Click(object sender, EventArgs e)
        {
            if (fakeSellProductRepository.DeleteAllProducts())
            {
                LoadFakeProductsIntoGrid();
            }
            else
            {
                MessageBox.Show("product deleted fail", "Seller Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GeneratePDF(List<Model.SellProduct> soldItems)
        {
            try
            {
                // Define the PDF file path
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SalesReceipt.pdf");

                // Load the Myanmar font
                // string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts", "Padauk-Regular.ttf"); // Path to the font file
                //string fontPath = @"C:\\Users\\user\\Desktop\\csharp\\inventory_management_system\\inventory_management_system\\Fonts\\Padauk-Regular.ttf";
               // BaseFont myanmarFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
               // iTextSharp.text.Font myanmarTextFont = new iTextSharp.text.Font(myanmarFont, 12);



                // Check if the directory exists
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Create a new PDF document
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                doc.Open();

                // Add a title
                iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Paragraph title = new Paragraph("EA Sport Bill\n\n", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                // Add date and seller info
                doc.Add(new Paragraph($"Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n"));
                doc.Add(new Paragraph($"Seller: {SessionStorage.Session.userName}\n\n"));

                // Create a table with 5 columns
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 30, 100,  50, 80 });

                // Add table headers
                table.AddCell("No");
                table.AddCell("Item");
                table.AddCell("Quantity");
                table.AddCell("Total Price (Kyats)");

                // Add items to the table
                int index = 1;
                decimal grandTotal = 0;

                foreach (var item in soldItems)
                {
                    table.AddCell(index.ToString());
                    table.AddCell(new Phrase(item.ProductName));
                    table.AddCell(item.ProductQuantity.ToString());
                    table.AddCell(item.PtoductTotalPrice.ToString("N2"));

                    grandTotal += item.PtoductTotalPrice;
                    index++;
                }

                // Add total row
                PdfPCell totalCell = new PdfPCell(new Phrase("Total Price", FontFactory.GetFont(FontFactory.HELVETICA_BOLD)));
                totalCell.Colspan = 3;
                totalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(totalCell);
                table.AddCell(grandTotal.ToString("N2") + " Kyats");

                // Add the table to the document
                doc.Add(table);

                // Close the document
                doc.Close();

                MessageBox.Show($"Bill saved to {filePath}", "PDF Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the PDF automatically
                try
                {
                    // Use ProcessStartInfo to open the PDF with the default application
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true // This ensures the default application is used
                    };
                    Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sellBtn_Click(object sender, EventArgs e)
        {
            List<SellProduct> soldProducts = new List<SellProduct>();
            foreach (DataGridViewRow row in fakeProductsGridView.Rows)
            {
                if (row.Cells["ProductId"].Value != null && row.Cells["Quantity"].Value != null)
                {
                    int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                    string productName = row.Cells["ProductName"].Value.ToString();
                    decimal productPrice = Convert.ToDecimal(row.Cells["ProductPrice"].Value);
                    int soldQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    string productCategory = row.Cells["ProductCategory"].Value.ToString();
                    string sellerName = SessionStorage.Session.userName; // Seller name stored in session.


                    // Fetch the product to update the quantity
                    var product = productRepository.GetProductById(productId);

                    if (product != null)
                    {
                        if (product.ProductQuantity >= soldQuantity)
                        {
                            product.ProductQuantity -= soldQuantity; // Deduct the sold quantity
                                                                     // Add sold product to the `sell_products` table
                            SellProduct sellProduct = new SellProduct
                            {
                                ProductName = productName,
                                ProductPrice = productPrice,
                                ProductQuantity = soldQuantity,
                                PtoductTotalPrice = productPrice * soldQuantity,
                                ProductCategory = productCategory,
                                sellerName = sellerName
                            };

                            SellProductRepository sellProductRepository = new SellProductRepository();
                            sellProductRepository.AddProduct(sellProduct);
                            productRepository.UpdateProduct(product); // Update the product in the database

                            soldProducts.Add(sellProduct);
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Not enough stock for {product.ProductName}. Available: {product.ProductQuantity}, Sold: {soldQuantity}",
                                "Stock Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }
                    }
                }
            }
            GeneratePDF(soldProducts); // Call PDF generation function
            if (fakeSellProductRepository.DeleteAllProducts())
            {
                MessageBox.Show("Product Sell successfullly", "selling products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFakeProductsIntoGrid();
                LoadProductsIntoGrid();


                // Generate PDF report after selling

                //pdfUpload.GeneratePDF(soldProducts);

                // Generate and display the bill
               // ShowSoldProductsReport(soldProducts);
            }
            else
            {
                MessageBox.Show("product deleted fail", "Seller Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowSoldProductsReport(List<SellProduct> soldProducts)
        {
            if (soldProducts.Count == 0)
            {
                MessageBox.Show("No products sold.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder report = new StringBuilder();
            report.AppendLine($"Sold Products Report\n");
            report.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd}\n");
            report.AppendLine("-------------------------------------------------------");
            report.AppendLine("No.   | Product Name  | Price  | Quantity | Total Price | Seller");
            report.AppendLine("-------------------------------------------------------");

            int index = 1;
            decimal grandTotal = 0;
            foreach (var product in soldProducts)
            {
                report.AppendLine($"{index,-5} | {product.ProductName,-13} | {product.ProductPrice,5:0.00}  | {product.ProductQuantity,3}        | {product.PtoductTotalPrice,6:0.00}       | {product.sellerName}");
                grandTotal += product.PtoductTotalPrice;
                index++;
            }

            report.AppendLine("-------------------------------------------------------");
            report.AppendLine($"Total Price is : {grandTotal:0.00} Kyats");

            MessageBox.Show(report.ToString(), "Sold Products Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void UpdateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in fakeProductsGridView.Rows)
            {
                if (row.Cells["Quantity"].Value != null && row.Cells["ProductPrice"].Value != null )
                {
                    int quantity = int.TryParse(row.Cells["Quantity"].Value.ToString(), out int parsedQuantity) ? parsedQuantity : 1;

                    decimal sellingPrice = Convert.ToDecimal(row.Cells["ProductPrice"].Value);
                    totalPrice += quantity * sellingPrice;
                }
            }

            totalPriceTxt.Text = totalPrice.ToString("N2") + " (Kyats)";
        }



        private void totalPriceTxt_Click(object sender, EventArgs e)
        {

        }
       

    }
}
