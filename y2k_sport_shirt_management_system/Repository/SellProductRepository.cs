using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system.Repository
{
    public class SellProductRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public SellProductRepository() { 
            _dbConnection = new DatabaseConnection();    
        }
        public bool AddProduct(SellProduct product) {
            string query = "INSERT sell_products (product_name, product_price, product_quantity, product_total_price,product_category,seller_name) " +
                           "VALUES (@ProductName, @ProductPrice, @ProductQuantity, @ProductTotalPrice,@ProductCategory,@SellerName)";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductQuantity", product.ProductQuantity);
                cmd.Parameters.AddWithValue("@ProductTotalPrice",product.PtoductTotalPrice);
                cmd.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                cmd.Parameters.AddWithValue("@SellerName", product.sellerName);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding product: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }
        public List<SellProduct> GetAllProducts(string searchItem="") {
            List<SellProduct> products = new List<SellProduct>();

            string query = "SELECT * FROM sell_products";
            if (!string.IsNullOrEmpty(searchItem))
            {
                query += " WHERE product_name LIKE @SearchItem";
            }
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(searchItem))
                {
                    cmd.Parameters.AddWithValue("@SearchItem", "%" + searchItem + "%");
                }

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new SellProduct
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductName = reader["product_name"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["product_price"]),
                        ProductQuantity = Convert.ToInt32(reader["product_quantity"]),
                        PtoductTotalPrice = Convert.ToDecimal(reader["product_total_price"]),
                        ProductCategory = reader["product_category"].ToString(),
                        sellerName = reader["seller_name"].ToString(),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching products: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return products;

        }
    }
}
