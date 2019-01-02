using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EXT_API.Middlewares
{
    public class RouteToApiOutMiddleware
    {
        private readonly RequestDelegate _next;
        private string _domain = "http://localhost:5002";

        public RouteToApiOutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse;

            client.DefaultRequestHeaders.Add("REQ", "OUT");
            client.DefaultRequestHeaders.Add("SIG", "TEST");

            httpResponse = client.GetAsync($"{_domain}{httpContext.Request.Path}").Result;
            string body = httpResponse.Content.ReadAsStringAsync().Result;
            await  httpContext.Response.WriteAsync(body);
        }
    }
}
