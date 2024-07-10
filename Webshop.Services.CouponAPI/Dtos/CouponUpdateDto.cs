namespace Webshop.Services.CouponAPI.Dtos
{
    public class CouponUpdateDto
    {
        public string CouponCode { get; set; } = string.Empty;
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
