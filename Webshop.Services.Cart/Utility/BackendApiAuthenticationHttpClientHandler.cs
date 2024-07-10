using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace Webshop.Services.CartAPI.Utility
{
    public class BackendApiAuthenticationHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<BackendApiAuthenticationHttpClientHandler> _logger;

        public BackendApiAuthenticationHttpClientHandler(IHttpContextAccessor context, ILogger<BackendApiAuthenticationHttpClientHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpContext = _context.HttpContext;

            if (httpContext == null)
            {
                _logger.LogError("---> HttpContext is null.");
                return await base.SendAsync(request, cancellationToken);
            }

            var token = await httpContext.GetTokenAsync("access_token");

            if (token == null)
            {
                _logger.LogWarning("---> Access token is null. Attempting to retrieve from cookies.");

                token = httpContext.Request.Cookies["JWTToken"];

                if (token == null)
                {
                    _logger.LogError("---> Token not found in cookies either.");
                }
                else
                {
                    _logger.LogInformation("---> Token found in cookies.");
                }
            }
            else
            {
                _logger.LogInformation("---> Token retrieved successfully from context.");
            }

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
