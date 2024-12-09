using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace y2k_sport_shirt_management_system.Model
{
    internal class DatabaseConnection
    {
        private MySqlConnection _connection;
          
        public DatabaseConnection()
        {
            string connectionString = "server=127.0.0.1; user=root; database=y2k_sport; password=";
            _connection = new MySqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while opening the database connection: " + ex.Message);
                throw;
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while closing the database connection: " + ex.Message);
                throw;
            }
        }
        public MySqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
