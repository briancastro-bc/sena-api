using System;
using MySql.Data.MySqlClient;

namespace api_sena.Models
{
    public class Database
    {

        public MySqlConnection connection;

        public Database() {
            this.connection = new MySqlConnection("datasource=localhost;port=3306;username=bcode;password=12345;database=db_api_sena;");
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