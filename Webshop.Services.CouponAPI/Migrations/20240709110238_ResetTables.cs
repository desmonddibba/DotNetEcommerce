using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coupons",
                newName: "CouponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponId",
                table: "Coupons",
                newName: "Id");
        }
    }
}
