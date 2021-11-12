using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoicesController : ControllerBase
    {
        public IEnumerable<Invoices> Get() {
            return new List<Invoices>() {
                new Invoices {
                    Code = "F-01",
                    CustomerUid = "ASDASDA",
                    Datetime = new DateTime()
                }
            };
        }
    }
}