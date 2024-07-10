using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResetCouponsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAMount",
                table: "Coupons",
                newName: "MinAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAmount",
                table: "Coupons",
                newName: "MinAMount");
        }
    }
}
