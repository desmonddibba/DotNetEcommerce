using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Webshop.Services.CartAPI.Utility
{
    public class BackendApiAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ILogger<BackendApiAuthenticationHttpClientHandler> _logger;

        public BackendApiAuthenticationHttpClientHandler(IHttpContextAccessor accessor, ILogger<BackendApiAuthenticationHttpClientHandler> logger)
        {
            _accessor = accessor;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var context = _accessor.HttpContext;
            if (context == null)
            {
                _logger.LogError("---> HttpContext is null");
                return await base.SendAsync(request, cancellationToken);
            }

            var token = await context.GetTokenAsync("access_token");
            if (token == null)
            {
                _logger.LogError("---> Token is null");
            }
            else
            {
                _logger.LogInformation("---> Token retrieved successfully");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
