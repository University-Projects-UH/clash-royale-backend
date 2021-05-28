using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace CR_Backend.Controllers
{
    /// <summary>
    /// customer controller class for testing security token
    /// </summary>
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetId(int id)
        {
            var customerFake = "customer-fake";
            return Ok(customerFake);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customersFake = new string[] { "customer-1", "customer-2", "customer-3" };
            return Ok(customersFake);
        }
    }
}