using System;
using MySql.Data.MySqlClient;

namespace api_sena.Models
{
    public class Database
    {

        public MySqlConnection connection;
        private MySqlDataReader reader;

        public Database() {
            this.connection = new MySqlConnection("datasource=localhost;port=3306;username=bcode;password=12345;database=db_api_sena;");
            this.reader = null!;
        }

        public bool OpenConnection() {
            try {
                this.connection.Open();
                return true;
            } catch(MySqlException ex) {
                switch(ex.Number) {
                    case 0:
                        Console.WriteLine($"Cannot connect to server. Error: {ex.Message}");
                        break;
                    case 1045:
                        Console.WriteLine($"Invalid username or password, please try again. Error: {ex.Message}");
                        break;
                    default:
                        Console.WriteLine($"Error to connect");
                        break;
                }
            } catch(Exception e) {
                Console.WriteLine($"Error: {e}");
            }
            return false;
        }

        public void FetchAll(string sql) {
            try {
                using(MySqlCommand cursor = new MySqlCommand(sql, this.connection)) {
                    this.OpenConnection();
                    using(MySqlDataReader reader = cursor.ExecuteReader()) {
                    }
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                this.CloseConnection();
            }
        }

        public MySqlDataReader FetchOne(string sql) {
            try {
                using(MySqlCommand cursor = new MySqlCommand(sql, this.connection)) {
                    this.OpenConnection();
                    using(MySqlDataReader reader = cursor.ExecuteReader()) {
                        return this.reader;
                    }
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                return null!;
            } finally {
                this.CloseConnection();
            }
        }

        public void ExecuteQuery(string sql) {
            try {
                using(MySqlCommand cursor = new MySqlCommand(sql, this.connection)) {
                    this.OpenConnection();
                    this.reader = cursor.ExecuteReader();
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                this.CloseConnection();
            }
        }

        public bool CloseConnection() {
            try {
                this.connection.Close();
                return true;
            } catch(MySqlException ex) {
                Console.WriteLine($"Error: {ex}");
            } catch(Exception e) {
                Console.WriteLine($"Error: {e}");
            }
            return false;
        }
    }
}