using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Webshop.Web.Service.IService;
using Webshop.Web.Utility;
using static Webshop.Web.Utility.SD;
using Webshop.Web.Dtos;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace Webshop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BaseService> _logger;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ILogger<BaseService> logger, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                _logger.LogInformation("Sending request to {Url} with method {Method}", requestDto.Url, requestDto.ApiType);

                HttpClient client = _httpClientFactory.CreateClient("WebshopAPI");
                HttpRequestMessage message = new()
                {
                    RequestUri = new Uri(requestDto.Url)
                };

                // Token handling
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    if (!string.IsNullOrEmpty(token))
                    {
                        message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                }



                // Set HTTP method
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

                HttpResponseMessage apiResponse = await client.SendAsync(message);

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
