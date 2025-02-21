using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system.pdf
{
    public class PDFUpload
    {
        public void GeneratePDF(List<SellProduct> soldProducts)
        {
            try
            {
                if (soldProducts == null || soldProducts.Count == 0)
                {
                    MessageBox.Show("No products to generate PDF.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Define the file path for the PDF
                string folderPath = "C:\\Temp"; // Change this path if needed
                string filePath = Path.Combine(folderPath, $"SoldProducts_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Ensure the directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Ensure no existing file locks the process
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Generate the PDF
                using (PdfWriter writer = new PdfWriter(filePath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    // Title
                    document.Add(new Paragraph("Sold Products Report")
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph($"Date: {DateTime.Now}\n\n"));

                    // Table Headers
                    Table table = new Table(new float[] { 1, 3, 2, 2, 2, 2 });
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    table.AddHeaderCell("No.");
                    table.AddHeaderCell("Product Name");
                    table.AddHeaderCell("Price");
                    table.AddHeaderCell("Quantity");
                    table.AddHeaderCell("Total Price");
                    table.AddHeaderCell("Seller");

                    // Table Data
                    int count = 1;
                    foreach (var product in soldProducts)
                    {
                        table.AddCell(count.ToString());
                        table.AddCell(product.ProductName);
                        table.AddCell(product.ProductPrice.ToString("N2"));
                        table.AddCell(product.ProductQuantity.ToString());
                        table.AddCell(product.PtoductTotalPrice.ToString("N2")); // Fixed typo
                        table.AddCell(product.sellerName);
                        count++;
                    }

                    document.Add(table);
                }

                // Show success message with the file path
                MessageBox.Show($"PDF saved successfully at {filePath}", "PDF Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating PDF: {ex.Message}\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}