using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api_sena.Models;
using api_sena.Services;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet("{uid}")]
        public ActionResult<Customers> GetOne(string uid) {
            var customer = CustomersService.GetOne(uid);
            if(customer == null) NotFound();
            return Ok(customer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customers>> GetAll() => Ok(CustomersService.GetAll());

        [HttpPost]
        public IActionResult Create(Customers customer) {
            CustomersService.Add(customer);
            return Accepted();
        }
    }
}