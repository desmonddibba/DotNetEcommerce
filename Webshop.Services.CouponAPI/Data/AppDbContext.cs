using Microsoft.EntityFrameworkCore;
using Webshop.Services.CouponAPI.Models;

namespace Webshop.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Coupon> Coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.DiscountAmount).HasPrecision(18, 2);
                entity.Property(e => e.MinAmount).HasPrecision(18, 2);
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 50
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 100
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "50OFF",
                DiscountAmount = 50,
                MinAmount = 200
            });
        }

    }
}
