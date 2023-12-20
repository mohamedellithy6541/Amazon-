using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon.Repository.Data.Migrations
{
    public partial class mappingdelivermethodS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "deliveryMethods",
                type: "Decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "deliveryMethods",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(18,2)");
        }
    }
}
