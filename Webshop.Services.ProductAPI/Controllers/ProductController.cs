using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webshop.Services.ProductAPI.Interface;
using Webshop.Services.ProductAPI.Models;
using Webshop.Services.ProductAPI.Models.Dtos;

namespace Webshop.Services.ProductAPI.Controllers
{
	[Route("api/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepo;
		private readonly IMapper _mapper;
		private readonly ResponseDto _response;

		public ProductController(IProductRepository productRepo, IMapper mapper)
		{
			_productRepo = productRepo;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> GetAll()
		{
			try
			{
				var products = await _productRepo.GetAllAsync();
				if (products == null || !products.Any())
				{
					_response.IsSuccess = false;
					_response.Message = "No products found.";
					return _response;
				}
				_response.Result = _mapper.Map<List<ProductDto>>(products);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpGet("{id:int}")]
		public async Task<ResponseDto> GetById(int id)
		{
			try
			{
				var product = await _productRepo.GetByIdAsync(id);
				if (product == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Product with id {id} not found.";
					return _response;
				}
				_response.Result = _mapper.Map<ProductDto>(product);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPost]
		public async Task<ResponseDto> CreateProduct([FromBody] ProductCreateDto productCreateDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_response.IsSuccess = false;
					_response.Message = "Invalid model state.";
					return _response;
				}

				var product = _mapper.Map<Product>(productCreateDto);
				await _productRepo.CreateAsync(product);
				_response.Result = _mapper.Map<ProductDto>(product);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpDelete("{id:int}")]
		public async Task<ResponseDto> DeleteProduct(int id)
		{
			try
			{
				var product = await _productRepo.DeleteAsync(id);
				if (product == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Product with id {id} not found.";
					return _response;
				}
				_response.IsSuccess = true;
				_response.Message = "Product deleted successfully.";
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut("{id:int}")]
		public async Task<ResponseDto> UpdateProduct(int id, [FromBody] ProductDto updateDto)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_response.IsSuccess = false;
					_response.Message = "Invalid model state.";
					return _response;
				}

				var product = _mapper.Map<Product>(updateDto);
				product.ProductId = id;

				var updatedProduct = await _productRepo.UpdateAsync(product);

				if (updatedProduct == null)
				{
					_response.IsSuccess = false;
					_response.Message = $"Product with id {id} not found.";
					return _response;
				}

				_response.Result = _mapper.Map<ProductDto>(updatedProduct);
				_response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
