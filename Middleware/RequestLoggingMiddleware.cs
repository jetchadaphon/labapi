using System.Diagnostics;

namespace LABAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming {method} {path}", context.Request.Method, context.Request.Path);
            var sw = Stopwatch.StartNew();
            await _next(context);
            sw.Stop();
            _logger.LogInformation("Finished {statusCode} in {ms}ms", context.Response.StatusCode, sw.ElapsedMilliseconds);
        }
    }
}
