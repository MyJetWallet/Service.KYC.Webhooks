using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.ServiceBus;
using Service.KYC.Domain.Models.Messages;
using Service.KYC.Webhooks.Domain.Models;

namespace Service.KYC.Webhooks.Services
{
    public class WebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<WebhookMiddleware> _logger;
        private readonly IServiceBusPublisher<KycVerificationResultMessage> _publisher;

        public WebhookMiddleware(
            RequestDelegate next,
            ILogger<WebhookMiddleware> logger, IServiceBusPublisher<KycVerificationResultMessage> publisher)
        {
            _next = next;
            _logger = logger;
            _publisher = publisher;
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

                var query = context.Request.QueryString;

                _logger.LogInformation($"'{path}' | {query} | {method}\n{body}");
                
                try
                {
                    var response = JsonSerializer.Deserialize<KycAidResponse>(body);
                    if (response != null)
                    {
                        await _publisher.PublishAsync(new KycVerificationResultMessage
                        {
                            ApplicantId = response.ApplicantId,
                            Verified = response.Verified,
                            VerificationId = response.VerificationId,
                            ExternalApplicantId = response.Applicant.ExternalApplicantId
                        });
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "When handling callback for KycAid");
                    throw;
                }
            }
            
            context.Response.StatusCode = 200;
        }
        
    }
}