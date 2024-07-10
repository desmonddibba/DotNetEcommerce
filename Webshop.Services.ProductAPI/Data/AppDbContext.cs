using Microsoft.EntityFrameworkCore;
using Webshop.Services.ProductAPI.Models;

namespace Webshop.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Caesar Salad",
                Price = 8.99m,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras vehicula lacinia ligula vel dictum.",
                ImageUrl = "https://placehold.co/604x404",
                CategoryName = "Salad"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Chicken Soup",
                Price = 7.50m,
                Description = "Suspendisse potenti. Proin mollis, urna vitae auctor fermentum. Integer quis risus ut nibh ullamcorper vestibulum.",
                ImageUrl = "https://placehold.co/605x405",
                CategoryName = "Soup"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Grilled Salmon",
                Price = 20.99m,
                Description = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae. Nulla facilisi.",
                ImageUrl = "https://placehold.co/606x406",
                CategoryName = "Main Course"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Tiramisu",
                Price = 6.99m,
                Description = "Fusce aliquam libero vel leo tristique, ac bibendum orci placerat. Maecenas consectetur justo ac nunc volutpat, nec ultricies sapien aliquet.",
                ImageUrl = "https://placehold.co/607x407",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Mango Smoothie",
                Price = 5.50m,
                Description = "Mauris sit amet magna ac lorem posuere gravida. Duis suscipit velit in turpis vestibulum, in tincidunt massa venenatis.",
                ImageUrl = "https://placehold.co/608x408",
                CategoryName = "Beverage"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Garlic Bread",
                Price = 4.00m,
                Description = "Donec nec justo eu nunc bibendum pellentesque. Aenean fringilla justo et velit pharetra, nec vestibulum eros tempor.",
                ImageUrl = "https://placehold.co/609x409",
                CategoryName = "Side"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Beef Burger",
                Price = 12.99m,
                Description = "A delicious beef burger with lettuce, tomato, and cheese. Served with a side of fries.",
                ImageUrl = "https://placehold.co/610x410",
                CategoryName = "Main Course"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Vegetarian Pizza",
                Price = 15.99m,
                Description = "A delicious vegetarian pizza topped with a variety of fresh vegetables and cheese.",
                ImageUrl = "https://placehold.co/611x411",
                CategoryName = "Main Course"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Chocolate Cake",
                Price = 5.99m,
                Description = "A rich and moist chocolate cake topped with chocolate ganache.",
                ImageUrl = "https://placehold.co/612x412",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Name = "Fruit Salad",
                Price = 6.50m,
                Description = "A refreshing fruit salad made with a mix of seasonal fruits.",
                ImageUrl = "https://placehold.co/613x413",
                CategoryName = "Salad"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 11,
                Name = "Iced Tea",
                Price = 2.99m,
                Description = "A refreshing iced tea served with lemon and mint.",
                ImageUrl = "https://placehold.co/614x414",
                CategoryName = "Beverage"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 12,
                Name = "Cheesecake",
                Price = 7.50m,
                Description = "A creamy cheesecake with a graham cracker crust and a raspberry topping.",
                ImageUrl = "https://placehold.co/615x415",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 13,
                Name = "Pasta Primavera",
                Price = 14.99m,
                Description = "A light pasta dish with fresh vegetables and a garlic olive oil sauce.",
                ImageUrl = "https://placehold.co/616x416",
                CategoryName = "Main Course"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 14,
                Name = "Lemonade",
                Price = 2.50m,
                Description = "A refreshing lemonade made with fresh lemons.",
                ImageUrl = "https://placehold.co/617x417",
                CategoryName = "Beverage"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 15,
                Name = "French Fries",
                Price = 3.50m,
                Description = "Crispy French fries served with a side of ketchup.",
                ImageUrl = "https://placehold.co/618x418",
                CategoryName = "Side"
            });


        }

    }
}
