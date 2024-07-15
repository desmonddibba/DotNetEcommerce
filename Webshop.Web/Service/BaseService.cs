using Newtonsoft.Json;
using System.Net;
using System.Text;
using Webshop.Web.Models.Dtos;
using Webshop.Web.Service.IService;
using static Webshop.Web.Utility.SD;

namespace Webshop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BaseService> _logger;

        public BaseService(IHttpClientFactory httpClientFactory,
            ILogger<BaseService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                _logger.LogInformation("Sending request to {Url} with method {Method}", requestDto.Url, requestDto.ApiType);

                HttpClient client = _httpClientFactory.CreateClient("WebshopAPI");
                HttpRequestMessage message = new()
                {
                    Headers = { { "Accept", "application/json" } },
                    RequestUri = new Uri(requestDto.Url)
                };

                // Add token to headers if withBearer is true
                if (withBearer)
                {
                    var token = ""; // Replace this with the actual token retrieval logic
                    if (!string.IsNullOrEmpty(token))
                    {
                        message.Headers.Add("Authorization", $"Bearer {token}");
                    }
                    else
                    {
                        _logger.LogWarning("Token is null or empty");
                    }
                }

                if (requestDto.ApiType != ApiType.GET && requestDto.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(requestDto.Data),
                        Encoding.UTF8,
                        "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                if (apiResponse == null)
                {
                    _logger.LogError("API response is null");
                    return new ResponseDto { IsSuccess = false, Message = "No response from server" };
                }

                _logger.LogInformation("Received response with status code {StatusCode}", apiResponse.StatusCode);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:

                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        _logger.LogInformation("API response content: {Content}", apiContent);

                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while sending request");
                return new ResponseDto { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
