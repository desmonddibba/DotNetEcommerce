﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webshop.Services.ProductAPI.Data;

#nullable disable

namespace Webshop.Services.ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240710001248_dbreset")]
    partial class dbreset
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webshop.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Salad",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras vehicula lacinia ligula vel dictum.",
                            ImageUrl = "https://placehold.co/604x404",
                            Name = "Caesar Salad",
                            Price = 8.99m
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Soup",
                            Description = "Suspendisse potenti. Proin mollis, urna vitae auctor fermentum. Integer quis risus ut nibh ullamcorper vestibulum.",
                            ImageUrl = "https://placehold.co/605x405",
                            Name = "Chicken Soup",
                            Price = 7.50m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Main Course",
                            Description = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae. Nulla facilisi.",
                            ImageUrl = "https://placehold.co/606x406",
                            Name = "Grilled Salmon",
                            Price = 20.99m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "Dessert",
                            Description = "Fusce aliquam libero vel leo tristique, ac bibendum orci placerat. Maecenas consectetur justo ac nunc volutpat, nec ultricies sapien aliquet.",
                            ImageUrl = "https://placehold.co/607x407",
                            Name = "Tiramisu",
                            Price = 6.99m
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryName = "Beverage",
                            Description = "Mauris sit amet magna ac lorem posuere gravida. Duis suscipit velit in turpis vestibulum, in tincidunt massa venenatis.",
                            ImageUrl = "https://placehold.co/608x408",
                            Name = "Mango Smoothie",
                            Price = 5.50m
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryName = "Side",
                            Description = "Donec nec justo eu nunc bibendum pellentesque. Aenean fringilla justo et velit pharetra, nec vestibulum eros tempor.",
                            ImageUrl = "https://placehold.co/609x409",
                            Name = "Garlic Bread",
                            Price = 4.00m
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryName = "Main Course",
                            Description = "A delicious beef burger with lettuce, tomato, and cheese. Served with a side of fries.",
                            ImageUrl = "https://placehold.co/610x410",
                            Name = "Beef Burger",
                            Price = 12.99m
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryName = "Main Course",
                            Description = "A delicious vegetarian pizza topped with a variety of fresh vegetables and cheese.",
                            ImageUrl = "https://placehold.co/611x411",
                            Name = "Vegetarian Pizza",
                            Price = 15.99m
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryName = "Dessert",
                            Description = "A rich and moist chocolate cake topped with chocolate ganache.",
                            ImageUrl = "https://placehold.co/612x412",
                            Name = "Chocolate Cake",
                            Price = 5.99m
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryName = "Salad",
                            Description = "A refreshing fruit salad made with a mix of seasonal fruits.",
                            ImageUrl = "https://placehold.co/613x413",
                            Name = "Fruit Salad",
                            Price = 6.50m
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryName = "Beverage",
                            Description = "A refreshing iced tea served with lemon and mint.",
                            ImageUrl = "https://placehold.co/614x414",
                            Name = "Iced Tea",
                            Price = 2.99m
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryName = "Dessert",
                            Description = "A creamy cheesecake with a graham cracker crust and a raspberry topping.",
                            ImageUrl = "https://placehold.co/615x415",
                            Name = "Cheesecake",
                            Price = 7.50m
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryName = "Main Course",
                            Description = "A light pasta dish with fresh vegetables and a garlic olive oil sauce.",
                            ImageUrl = "https://placehold.co/616x416",
                            Name = "Pasta Primavera",
                            Price = 14.99m
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryName = "Beverage",
                            Description = "A refreshing lemonade made with fresh lemons.",
                            ImageUrl = "https://placehold.co/617x417",
                            Name = "Lemonade",
                            Price = 2.50m
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryName = "Side",
                            Description = "Crispy French fries served with a side of ketchup.",
                            ImageUrl = "https://placehold.co/618x418",
                            Name = "French Fries",
                            Price = 3.50m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
