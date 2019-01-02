using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Data.Middlewares
{
    public class VerifyMiddleware
    {
        private readonly RequestDelegate _next;

        public VerifyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke (HttpContext httpContext)
        {
            string req = httpContext.Request.Headers["REQ"];
            string sig = httpContext.Request.Headers["SIG"];
            
            Console.Write("\nReq : "+req);
            Console.Write("Sig : \n"+ sig);

            if(string.IsNullOrEmpty(req) || string.IsNullOrEmpty(sig))
            {
                httpContext.Response.StatusCode = 400;
            }
            if(req.ToLower().Equals("name") && sig.ToLower().Equals("kim"))
            {
                await _next(httpContext);
            }
        }
    }
}
