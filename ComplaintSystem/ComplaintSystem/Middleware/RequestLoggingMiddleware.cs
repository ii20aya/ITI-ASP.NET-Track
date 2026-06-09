using System.Diagnostics;

namespace ComplaintSystem.Middleware
{
    /// <summary>
    /// Custom middleware that logs every HTTP request:
    /// – HTTP method  (GET, POST, PUT, DELETE …)
    /// – Request path
    /// – Response status code
    /// – Duration in milliseconds
    /// </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next,
                                        ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();          // start timer
            var method = context.Request.Method;        // GET | POST | …
            var path = context.Request.Path;

            try
            {
                await _next(context);                   // pass to next middleware
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedMilliseconds;
                var statusCode = context.Response.StatusCode;

                // Log at Information level; visible in console & log sinks
                _logger.LogInformation(
                    "[REQUEST] {Method,-6} {Path,-40} => {StatusCode}  ({Ms} ms)",
                    method, path, statusCode, ms);
            }
        }
    }

    // ── Extension method so Program.cs stays clean ─────────────────────────────
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLoggingMiddleware>();
    }
}