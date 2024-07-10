using Webshop.Web.Models;
using Webshop.Web.Service.IService;
using Webshop.Web.Utility;
using Microsoft.Extensions.Logging;
using Webshop.Web.Dtos;



namespace Webshop.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
		private readonly ILogger<ProductService> _logger;

		public ProductService(IBaseService baseService, ILogger<ProductService> logger)
        {
            _baseService = baseService;
            _logger = logger;
        }

        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            var response = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + "/api/product/"
            });

            if (response == null || !response.IsSuccess)
            {
                _logger.LogError("Failed to create product: {Message}", response?.Message);
            }
            else
            {
                _logger.LogInformation($"Product created successfully: {productDto.Name}");
            }

            return response;
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
			_logger.LogInformation("Fetching all products");

		    return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product"
            });
 

		}


        //public async Task<ResponseDto?> GetProduct(string productCode)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.GET,
        //        Url = SD.ProductAPIBase + "/api/product/GetByCode/" + productCode
        //    });
        //}

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = $"{SD.ProductAPIBase}/api/product/{productDto.ProductId}" // Include the ID here
            });
        }
    }
}
