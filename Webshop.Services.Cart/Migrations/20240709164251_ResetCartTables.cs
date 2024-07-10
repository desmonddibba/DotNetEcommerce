using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Services.CartAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResetCartTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarDetailsId",
                table: "CartDetails",
                newName: "CartDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartDetailsId",
                table: "CartDetails",
                newName: "CarDetailsId");
        }
    }
}
