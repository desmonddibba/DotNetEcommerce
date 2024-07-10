using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Webshop.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMockProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras vehicula lacinia ligula vel dictum.", 8.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Suspendisse potenti. Proin mollis, urna vitae auctor fermentum. Integer quis risus ut nibh ullamcorper vestibulum.", 7.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae. Nulla facilisi.", 20.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Fusce aliquam libero vel leo tristique, ac bibendum orci placerat. Maecenas consectetur justo ac nunc volutpat, nec ultricies sapien aliquet.", 6.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Mauris sit amet magna ac lorem posuere gravida. Duis suscipit velit in turpis vestibulum, in tincidunt massa venenatis.", 5.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Donec nec justo eu nunc bibendum pellentesque. Aenean fringilla justo et velit pharetra, nec vestibulum eros tempor.", 4.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 7, "Main Course", "A delicious beef burger with lettuce, tomato, and cheese. Served with a side of fries.", "https://placehold.co/610x410", "Beef Burger", 12.99m },
                    { 8, "Main Course", "A delicious vegetarian pizza topped with a variety of fresh vegetables and cheese.", "https://placehold.co/611x411", "Vegetarian Pizza", 15.99m },
                    { 9, "Dessert", "A rich and moist chocolate cake topped with chocolate ganache.", "https://placehold.co/612x412", "Chocolate Cake", 5.99m },
                    { 10, "Salad", "A refreshing fruit salad made with a mix of seasonal fruits.", "https://placehold.co/613x413", "Fruit Salad", 6.50m },
                    { 11, "Beverage", "A refreshing iced tea served with lemon and mint.", "https://placehold.co/614x414", "Iced Tea", 2.99m },
                    { 12, "Dessert", "A creamy cheesecake with a graham cracker crust and a raspberry topping.", "https://placehold.co/615x415", "Cheesecake", 7.50m },
                    { 13, "Main Course", "A light pasta dish with fresh vegetables and a garlic olive oil sauce.", "https://placehold.co/616x416", "Pasta Primavera", 14.99m },
                    { 14, "Beverage", "A refreshing lemonade made with fresh lemons.", "https://placehold.co/617x417", "Lemonade", 2.50m },
                    { 15, "Side", "Crispy French fries served with a side of ketchup.", "https://placehold.co/618x418", "French Fries", 3.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit.<br/> Cras vehicula lacinia ligula vel dictum.", 8.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Suspendisse potenti. Proin mollis, urna vitae auctor fermentum.<br/> Integer quis risus ut nibh ullamcorper vestibulum.", 7.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae.<br/> Nulla facilisi.", 20.989999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Fusce aliquam libero vel leo tristique, ac bibendum orci placerat.<br/> Maecenas consectetur justo ac nunc volutpat, nec ultricies sapien aliquet.", 6.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Mauris sit amet magna ac lorem posuere gravida.<br/> Duis suscipit velit in turpis vestibulum, in tincidunt massa venenatis.", 5.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Donec nec justo eu nunc bibendum pellentesque.<br/> Aenean fringilla justo et velit pharetra, nec vestibulum eros tempor.", 4.0 });
        }
    }
}
