using System.Collections.Generic;

namespace api_sena
{
    public class Invoices 
    {
        public string? Code { get; set; }
        public string? Customer { get; set; }
        public DateTime Datetime { get; set; }
        public List<InvoicesDetails>? InvoicesDetails { get; }
    }
}