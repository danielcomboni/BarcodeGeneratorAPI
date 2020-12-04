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
