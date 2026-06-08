using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StudentManagement.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();

            Console.WriteLine($"[{time}] Method: {method} - Path: {path}");

            if (string.Equals(path, "/Book/Detail/0", System.StringComparison.OrdinalIgnoreCase) ||
                string.Equals(path, "/Book/Detail/-1", System.StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Book id khong hop le");
                return;
            }

            await _next(context);

            Console.WriteLine($"Status Code: {context.Response.StatusCode}");
        }
    }
}
