using EXT_API.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXT_API
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder useRouteToAPI (this IApplicationBuilder application)
        {
            return application.UseMiddleware<RouteToAPIData>();
        }
        public static IApplicationBuilder useRouteToApiOut(this IApplicationBuilder application)
        {
            return application.UseMiddleware<RouteToApiOutMiddleware>();
        }
    }
}
