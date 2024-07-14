namespace Webshop.Services.CouponAPI.Dtos
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = string.Empty;
        public decimal DiscountAmount { get; set; }
        public decimal MinAmount { get; set; }
    }
}
