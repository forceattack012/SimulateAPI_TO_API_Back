using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_To_Out.Middlewares
{
    public class VerifyRequestToOut
    {
        private readonly RequestDelegate _next;
        private string _domain = "http://localhost:5000";

        public VerifyRequestToOut(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string req = httpContext.Request.Headers["REQ"];
            string sig = httpContext.Request.Headers["SIG"];

            if(string.IsNullOrEmpty(req) || string.IsNullOrEmpty(sig))
            {
                httpContext.Response.WriteAsync("Headder is null");
            }
            if(req.Equals("OUT") && sig.Equals("TEST"))
            {
                await _next(httpContext);
            }
        }
    }
}
