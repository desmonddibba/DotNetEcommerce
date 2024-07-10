namespace Webshop.Services.ProductAPI.Models.Dtos
{
	public class ProductCreateDto
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public string CategoryName { get; set; }
		public string ImageUrl { get; set; }
	}
}
