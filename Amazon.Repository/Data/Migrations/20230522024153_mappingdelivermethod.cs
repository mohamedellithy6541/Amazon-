using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon.Repository.Data.Migrations
{
    public partial class mappingdelivermethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortNmae",
                table: "deliveryMethods",
                newName: "ShortName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "deliveryMethods",
                newName: "ShortNmae");
        }
    }
}
