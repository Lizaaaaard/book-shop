
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookShop;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;    
    
    public ExceptionHandlerMiddleware(RequestDelegate next)    
    {    
        _next = next;    
    }
    
    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)  
    {  
        context.Response.ContentType = "application/json";  
        int statusCode = (int)HttpStatusCode.InternalServerError;  
        var result = JsonConvert.SerializeObject(new  
        {  
            StatusCode = statusCode,  
            ErrorMessage = exception.Message  
        });  
        context.Response.ContentType = "application/json";  
        context.Response.StatusCode = statusCode;  
        return context.Response.WriteAsync(result);  
    } 
    
    public async Task Invoke(HttpContext context)    
    {    
        try  
        {  
            await _next.Invoke(context);  
        }  
        catch (Exception ex)  
        {  
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);  
        }     
    }    
}