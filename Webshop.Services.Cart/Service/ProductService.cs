using Newtonsoft.Json;
using Webshop.Services.CartAPI.Models.Dtos;
using Webshop.Services.CartAPI.Service.IService;

namespace Webshop.Services.CartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _http;

        public ProductService(IHttpClientFactory http)
        {
            _http = http;            
        }


        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _http.CreateClient("Product");
            var httpResponse = await client.GetAsync($"/api/product");
            var apiContent = await httpResponse.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            
            if(res.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(res.Result));
            }
            return new List<ProductDto>();

        }
    }
}
