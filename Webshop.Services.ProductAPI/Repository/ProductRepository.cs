using Microsoft.EntityFrameworkCore;
using Webshop.Services.ProductAPI.Data;
using Webshop.Services.ProductAPI.Interface;
using Webshop.Services.ProductAPI.Models;

namespace Webshop.Services.ProductAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Product> CreateAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<Product?> DeleteAsync(int id)
		{
			var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
			if (product == null) return null;

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return product;
		}

		public async Task<List<Product>> GetAllAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product?> GetByIdAsync(int id)
		{
			return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
		}

		public async Task<Product?> UpdateAsync(Product product)
		{
			var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
			if (existingProduct == null) return null;

			
			existingProduct.Name = product.Name;
			existingProduct.Price = product.Price;
			existingProduct.Description = product.Description;
			existingProduct.CategoryName = product.CategoryName;
			existingProduct.ImageUrl = product.ImageUrl;

			await _context.SaveChangesAsync();
			return existingProduct;
		}
	}
}
