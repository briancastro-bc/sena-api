using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customers> Get() {
            return new List<Customers>() {
                new Customers {
                    Uid = "ASDASDASD",
                    Name = "Brian",
                    Last_Name = "Castro",
                    Identity = "2222"
                }
            };
        }

        [HttpPost(Name = "CreateCustomers")]
        public void Create() {

        }
    }
}