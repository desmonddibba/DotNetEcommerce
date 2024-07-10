using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class ResetCoupons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MinAMount",
                table: "Coupons",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 10m, 50m });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 20m, 100m });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 50m, 200m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinAMount",
                table: "Coupons",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "DiscountAmount",
                table: "Coupons",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 10.0, 20 });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 20.0, 40 });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3,
                columns: new[] { "DiscountAmount", "MinAMount" },
                values: new object[] { 50.0, 100 });
        }
    }
}
