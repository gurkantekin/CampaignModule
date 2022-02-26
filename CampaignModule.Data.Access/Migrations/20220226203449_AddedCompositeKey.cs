using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignModule.Data.Access.Migrations
{
    public partial class AddedCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                schema: "dbo",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "Campaigns");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                schema: "dbo",
                table: "Campaigns",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Campaigns",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                schema: "dbo",
                table: "Campaigns",
                columns: new[] { "Name", "ProductCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Campaigns",
                schema: "dbo",
                table: "Campaigns");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                schema: "dbo",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campaigns",
                schema: "dbo",
                table: "Campaigns",
                column: "Id");
        }
    }
}
