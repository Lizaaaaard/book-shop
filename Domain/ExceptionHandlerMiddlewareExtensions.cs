using BookShop;
using Microsoft.AspNetCore.Builder;

namespace Domain;

public static class ExceptionHandlerMiddlewareExtensions
{
    public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)  
    {  
        app.UseMiddleware<ExceptionHandlerMiddleware>();  
    } 
}