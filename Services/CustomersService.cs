using System;
using Dapper;
using api_sena.Models;

namespace api_sena.Services
{
    public static class CustomersService
    {
        private static readonly Database database;

        static CustomersService() {
            database = new Database();
        }

        public static IEnumerable<Customers> GetAll() {
            IEnumerable<Customers>? customers = null;
            string query = "SELECT * FROM customers";
            customers = database.connection.Query<Customers>(query);
            return customers;
        }

        public static Customers GetOne(string uid) {
            Customers? customer = new Customers();
            string query = $"SELECT * FROM customers WHERE uid = '{uid}'";
            customer = database.connection.QueryFirst<Customers>(query);
            return customer;
        }

        public static void Add(Customers customer) {
            string query = $"INSERT INTO customers(uid, name, last_name, identity) VALUES('{customer.Uid}', '{customer.Name}', '{customer.Last_Name}', '{customer.Identity}')";
            database.connection.Execute(query, customer);
        }
    }
}