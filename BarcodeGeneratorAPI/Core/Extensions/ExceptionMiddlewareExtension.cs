using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcodeGeneratorAPI.Middleware ;
using Microsoft.AspNetCore.Builder ;

namespace BarcodeGeneratorAPI.Core.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
