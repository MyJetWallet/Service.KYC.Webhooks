using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Service.KYC.Webhooks.Services
{
    public class WebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<WebhookMiddleware> _logger;
        
        public WebhookMiddleware(
            RequestDelegate next,
            ILogger<WebhookMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/kycaid", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogInformation("Receive call to {path}, method: {method}", context.Request.Path,
                    context.Request.Method);
            }

            if (!context.Request.Path.StartsWithSegments("/kycaid/webhook", StringComparison.OrdinalIgnoreCase))
            {
                await _next.Invoke(context);
                return;
            }

            var path = context.Request.Path;
            var method = context.Request.Method;

            var body = "--none--";

            if (method == "POST")
            {
                await using var buffer = new MemoryStream();

                await context.Request.Body.CopyToAsync(buffer);

                buffer.Position = 0L;

                using var reader = new StreamReader(buffer);

                body = await reader.ReadToEndAsync();
            }

            var query = context.Request.QueryString;

            _logger.LogInformation($"'{path}' | {query} | {method}\n{body}");

            context.Response.StatusCode = 200;
        }
        
    }
}