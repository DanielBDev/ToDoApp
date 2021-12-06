using Microsoft.AspNetCore.Builder;
using ToDo.Api.Middlewares;

namespace ToDo.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}