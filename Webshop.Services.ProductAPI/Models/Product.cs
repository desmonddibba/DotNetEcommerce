using System.ComponentModel.DataAnnotations;

namespace Webshop.Services.ProductAPI.Models
{
	public class Product
	{
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
