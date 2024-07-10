using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Webshop.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTableAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Salad", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.<br/> Cras vehicula lacinia ligula vel dictum.", "https://placehold.co/604x404", "Caesar Salad", 8.9900000000000002 },
                    { 2, "Soup", "Suspendisse potenti. Proin mollis, urna vitae auctor fermentum.<br/> Integer quis risus ut nibh ullamcorper vestibulum.", "https://placehold.co/605x405", "Chicken Soup", 7.5 },
                    { 3, "Main Course", "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae.<br/> Nulla facilisi.", "https://placehold.co/606x406", "Grilled Salmon", 20.989999999999998 },
                    { 4, "Dessert", "Fusce aliquam libero vel leo tristique, ac bibendum orci placerat.<br/> Maecenas consectetur justo ac nunc volutpat, nec ultricies sapien aliquet.", "https://placehold.co/607x407", "Tiramisu", 6.9900000000000002 },
                    { 5, "Beverage", "Mauris sit amet magna ac lorem posuere gravida.<br/> Duis suscipit velit in turpis vestibulum, in tincidunt massa venenatis.", "https://placehold.co/608x408", "Mango Smoothie", 5.5 },
                    { 6, "Side", "Donec nec justo eu nunc bibendum pellentesque.<br/> Aenean fringilla justo et velit pharetra, nec vestibulum eros tempor.", "https://placehold.co/609x409", "Garlic Bread", 4.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
