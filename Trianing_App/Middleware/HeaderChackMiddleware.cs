using Microsoft.Extensions.Options;

namespace Trianing_App.Middleware
{
    public class HeaderChackMiddleware
    {
       
            private readonly RequestDelegate _next;
        private readonly HeaderCheckSrtingModel _settings;

            public HeaderChackMiddleware(RequestDelegate next, IOptions<HeaderCheckSrtingModel> options)
            {
                _next = next;
            _settings = options.Value;
            }

            public async Task InvokeAsync(HttpContext context)
            {
            var HedaerName = _settings.RequiredHeaderName;
                // Example: Require a specific header
                if (!context.Request.Headers.TryGetValue(HedaerName, out var headerNameValue) ||
                string.IsNullOrWhiteSpace(headerNameValue) || ( !string.IsNullOrEmpty(_settings.ExpectedValue)&& headerNameValue != _settings.ExpectedValue))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Missing or invalid X-Custom-Header.");
                    return;
                }

                // You can log or use the header value here as needed

                await _next(context); // Continue to the next middleware
            }
        }
    }

