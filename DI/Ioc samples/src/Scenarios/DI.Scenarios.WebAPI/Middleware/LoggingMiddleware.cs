using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DI.Scenarios.WebAPI.Middleware;

public class LoggingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine($"Request start {context.TraceIdentifier}");
        var sw = new Stopwatch();
        sw.Start();

        try
        {
            await next(context);
        }
        catch (Exception e)
        {
        }
        
        sw.Stop();
        Console.WriteLine($"Request {context.TraceIdentifier} took {sw.ElapsedMilliseconds}ms");
    }
}