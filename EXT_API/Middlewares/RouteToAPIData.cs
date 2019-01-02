using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace EXT_API.Middlewares
{
    public class RouteToAPIData
    {
        private readonly RequestDelegate _next;
        private string _domain = "http://localhost:5001";
        public RouteToAPIData(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequest request = httpContext.Request;

            HttpResponseMessage Response;
            string body = "";

            httpClient.DefaultRequestHeaders.Add("REQ", "name");
            httpClient.DefaultRequestHeaders.Add("SIG", "kim");

            switch(request.Method)
            {
                case "GET":
                    Response = httpClient.GetAsync($"{_domain}{request.Path.Value}").Result;
                    body = Response.Content.ReadAsStringAsync().Result;
                    await httpContext.Response.WriteAsync(body);
                    break;
            }

        }
    }
}
