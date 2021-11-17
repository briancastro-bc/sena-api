using Microsoft.AspNetCore.Mvc;
using api_sena.Services;

namespace api_sena.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoicesController : ControllerBase
    {
        [HttpGet("{code}")]
        public ActionResult<Invoices> GetOne(string code) {
            Invoices invoice = InvoicesService.GetOne(code);
            if(invoice == null) NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult Create(Invoices invoice) {
            InvoicesService.Add(invoice);
            return Accepted();
        }
    }
}