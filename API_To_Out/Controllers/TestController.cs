using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_To_Out.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("out/{*url}")]
        public IActionResult GetTest(string url)
        {
            Req req = new Req()
            {
                Name = "API OUT",
                Request_url = url
            };

            return Ok(req);
        }
    }
}
public class Req
{
    public string Name { set; get; }
    public string Request_url { set; get; }
}