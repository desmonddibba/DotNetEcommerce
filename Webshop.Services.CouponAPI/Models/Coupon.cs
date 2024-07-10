using System.ComponentModel.DataAnnotations;

namespace Webshop.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; } = string.Empty;

        [Required]
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }

    }
}
