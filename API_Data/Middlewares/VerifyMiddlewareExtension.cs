using API_Data.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Data
{
    public static class VerifyMiddlewareExtension
    {
        public static IApplicationBuilder useVerifyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VerifyMiddleware>();
        }
    }
}
