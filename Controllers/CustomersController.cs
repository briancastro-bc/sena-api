using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_sena.Models;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult<Customers> GetOne(string id) {
            continue;
        }

        [HttpGet]
        public IActionResult<IEnumerable<Customers>> GetAll() {
            return new List<Customers>() {
                new Customers {
                    Uid = "ASDASDASD",
                    Name = "Brian",
                    Last_Name = "Castro",
                    Identity = "2222"
                }
            };
        }

        [HttpPost]
        public IActionResult Create(Customers customer) {
            continue;
        }
    }
}