using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using y2k_sport_shirt_management_system.Model;

namespace y2k_sport_shirt_management_system.Repository
{
    public class SellerRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public SellerRepository()
        {
            _dbConnection = new DatabaseConnection();
        }
        public bool AddSeller(User user)
        {
            string query = "INSERT users (name,account_id,password)" +
                "VALUES (@Name,@Account_id,@Password)";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Account_id", user.AccountId);
                cmd.Parameters.AddWithValue("@password", user.Password);
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding seller" + ex.Message);
                return false;
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
            return true;

        }
        public List<User> GetAllSellers()
        {
            List<User> sellers = new List<User>();
            string query = "SELECT * FROM users WHERE role=0";

            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sellers.Add(new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        AccountId = reader["account_id"].ToString(),
                        Password = reader["password"].ToString()
                    }
                    );
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching seller" + ex.Message);
            }
            finally
            {
                _dbConnection.CloseConnection();
            }
            return sellers;

        }
        public bool UpdateSeller(User user)
        {

            string query = "UPDATE users SET name=@Name,account_id=@Account_id,password=@Password" +
                " WHERE id=@Id";
            try
            {
                _dbConnection.OpenConnection();
                MySqlConnection connection = _dbConnection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Account_id", user.AccountId);
                cmd.Parameters.AddWithValue("@Password", user.Password);

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
        public bool DeleteSeller(int id)
        {
            string query = "DELETE FROM users WHERE id=@Id";
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
        // Get seller by id
        public User GetSellerById(int id)
        {
            {
                string query = "SELECT * FROM users WHERE id=@Id;";
                try
                {
                    _dbConnection.OpenConnection();
                    MySqlConnection connection = _dbConnection.GetConnection();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["name"].ToString(),
                            AccountId = reader["account_id"].ToString(),
                            Password = reader["password"].ToString()
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
}
