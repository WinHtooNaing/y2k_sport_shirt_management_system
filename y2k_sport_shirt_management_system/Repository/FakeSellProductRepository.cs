using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system.Repository
{
    public class FakeSellProductRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public FakeSellProductRepository() { 
            _dbConnection = new DatabaseConnection();   
        }
        public bool IsProductExists(int productId)
        {
            string query = "SELECT COUNT(*) FROM fake_sell_products WHERE product_id = @ProductId";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while checking product existence: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }

        public bool AddProduct(FakeSellProduct product)
        {
            if (IsProductExists(product.ProductId))
            {
                Console.WriteLine("Product with the same ID already exists.");
                return false;
            }
            string query = "INSERT fake_sell_products (product_id,product_name,product_category,product_price,size)" +
                " VALUES (@ProductId,@ProductName,@ProductCategory,@ProductPrice,@Size);";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);
                cmd.Parameters.AddWithValue("@Size", product.Size);

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
        public List<FakeSellProduct> GetAllProducts()
        {
            List<FakeSellProduct> products = new List<FakeSellProduct>();
            string query = "SELECT * FROM fake_sell_products;";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    products.Add(new FakeSellProduct
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductId = Convert.ToInt32(reader["product_id"]),
                        ProductName = reader["product_name"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["product_price"]),
                        ProductCategory = reader["product_category"].ToString(),
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

        // Delete all 
        public bool DeleteAllProducts()
        {
            string query = "DELETE FROM fake_sell_products";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query,connection);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting product: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }
        // Delete
        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM fake_sell_products WHERE id = @Id";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting product: " + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
        }
    }
}
