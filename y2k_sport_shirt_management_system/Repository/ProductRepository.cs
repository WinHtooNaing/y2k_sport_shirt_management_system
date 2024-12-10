using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system.Repository
{
    public class ProductRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public ProductRepository()
        {
            _dbConnection = new DatabaseConnection();
        }
        // create
        public bool AddProduct(Product product)
        {
            string query = "INSERT products (product_name, product_price, product_quantity, product_category) " +
                           "VALUES (@ProductName, @ProductPrice, @ProductQuantity, @ProductCategory)";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductQuantity", product.ProductQuantity);
                cmd.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);

                int rowsAffected =cmd.ExecuteNonQuery();
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

        // get all products
        public List<Product> GetAllProducts(string searchItem="")
        {
            List<Product> products = new List<Product>();

            string query = "SELECT * FROM products";
            if(!string.IsNullOrEmpty(searchItem))
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
                    cmd.Parameters.AddWithValue("@SearchItem","%" + searchItem + "%");
                }

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductName = reader["product_name"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["product_price"]),
                        ProductQuantity = Convert.ToInt32(reader["product_quantity"]),
                        ProductCategory = reader["product_category"].ToString()
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
        // Update
        public bool UpdateProduct(Product product)
        {
            string query = "UPDATE products SET product_name = @ProductName, product_price = @ProductPrice, " +
                           "product_quantity = @ProductQuantity, product_category = @ProductCategory " +
                           "WHERE id = @Id";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", product.Id);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductQuantity", product.ProductQuantity);
                cmd.Parameters.AddWithValue("@ProductCategory", product.ProductCategory);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating product: " + ex.Message);
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
            string query = "DELETE FROM products WHERE id = @Id";

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
        // Read by ID
        public Product GetProductById(int id)
        {
            string query = "SELECT * FROM products WHERE id = @Id";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Product
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        ProductName = reader["product_name"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["product_price"]),
                        ProductQuantity = Convert.ToInt32(reader["product_quantity"]),
                        ProductCategory = reader["product_category"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching product: " + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }

            return null;
        }

    }
}
