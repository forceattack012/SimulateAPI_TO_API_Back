using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace API_To_Out.Middlewares
{
    public class RouteToApiDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _domain;
        public RouteToApiDataMiddleware(RequestDelegate next)
        {
            _next = next;
            _domain = "http://localhost:5001";
        }

        public async Task Invoke (HttpContext httpContent)
        {
            HttpRequest request = httpContent.Request;
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response;
            string body = "";

            httpClient.DefaultRequestHeaders.Add("REQ", "name");
            httpClient.DefaultRequestHeaders.Add("SIG", "kim");

            switch (request.Method)
            {
                case "GET":
                    response = httpClient.GetAsync($"{_domain}{request.Path.Value}").Result;
                    body = response.Content.ReadAsStringAsync().Result;
                    await httpContent.Response.WriteAsync(body);
                    break;
            }
        }
    }
}
