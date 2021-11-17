using Dapper;
using api_sena.Models;

namespace api_sena.Services
{
    public static class InvoicesService
    {
        private static readonly Database database;

        static InvoicesService() {
            database = new Database();
        }

        public static Invoices GetOne(string code) {
            Invoices invoice = new Invoices();
            string query = $"SELECT * FROM invoices WHERE code = '{code}'";
            invoice = database.connection.QueryFirst<Invoices>(query);
            return invoice;
        }

        public static void Add(Invoices invoice) {
            string query = $"INSERT INTO invoices(code, customer_uid) VALUES('{invoice.Code}', '{invoice.Customer}')";
            database.connection.Execute(query);
            string otherQuery = "";
            foreach(InvoicesDetails invoicesDetails in invoice.InvoicesDetails!) {
                otherQuery = $"INSERT INTO invoices_details(invoice_code, description, value) VALUES('{invoicesDetails.Invoice}', '{invoicesDetails.Description}', '{invoicesDetails.Value}')";
                database.connection.Execute(otherQuery);
            }
        }
    }
}