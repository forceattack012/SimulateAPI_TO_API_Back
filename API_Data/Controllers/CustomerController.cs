using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer()
                {
                    Name = "a2",
                    Money = "3000"
                },
                new Customer()
                {
                    Name = "a1",
                    Money = "4000"
                }
            };

            return Ok(customers);

        }
    }
}
public class Customer
{
    public string Name { get; set; }
    public string Money { get; set; }
}