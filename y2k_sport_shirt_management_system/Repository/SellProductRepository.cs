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
            string query = "INSERT sell_products (product_name,product_category, product_price, product_quantity, product_total_price,size,seller_name) " +
                           "VALUES (@ProductName,@ProductCategory, @ProductPrice, @ProductQuantity, @ProductTotalPrice,@Size,@SellerName)";

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
                cmd.Parameters.AddWithValue("@Size",product.Size);
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
                query += " WHERE seller_name LIKE @SearchItem";
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
                        Size = reader["size"].ToString()
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
        public List<SellProduct> GetDailySoldProducts(string searchItem = "")
        {
            List<SellProduct> products = new List<SellProduct>();

            string query = "SELECT * FROM sell_products WHERE DATE(created_at) = CURDATE()";
            if (!string.IsNullOrEmpty(searchItem))
            {
                query += " WHERE seller_name LIKE @SearchItem";
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
                        Size = reader["size"].ToString(),
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
        public List<string> GetAllSellerNames()
        {
            List<string> sellerName = new List<string>();
            string query = "SELECT name FROM users WHERE role=0;";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sellerName.Add(reader["name"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching usernames: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return sellerName;
        }
        public decimal TotalSellPrice()
        {
            decimal totalSellPrice = 0;
            string query = "SELECT SUM(product_total_price) FROM sell_products";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    totalSellPrice = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while calculating total sell price: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return totalSellPrice;

        }

        public decimal DailyTotalSellPrice()
        {
            decimal dailyTotalSellPrice = 0;
            string query = "SELECT SUM(product_total_price) FROM sell_products WHERE DATE(created_at) = CURDATE()";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    dailyTotalSellPrice = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while calculating daily total sell price: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return dailyTotalSellPrice;
        }


    }
}
