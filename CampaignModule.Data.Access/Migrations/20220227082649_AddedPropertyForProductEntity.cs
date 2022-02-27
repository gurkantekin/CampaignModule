using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignModule.Data.Access.Migrations
{
    public partial class AddedPropertyForProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentPrice",
                schema: "dbo",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                schema: "dbo",
                table: "Products");
        }
    }
}
