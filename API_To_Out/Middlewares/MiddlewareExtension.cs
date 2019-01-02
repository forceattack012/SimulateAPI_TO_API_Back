using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_To_Out.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace API_To_Out
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder useRouteToApi(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteToApiDataMiddleware>();
        }
        public static IApplicationBuilder useVerify(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VerifyRequestToOut>();
        }
    }
}
