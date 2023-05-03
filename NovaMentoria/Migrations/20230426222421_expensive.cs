using Microsoft.EntityFrameworkCore.Migrations;

namespace NovaMentoria.Migrations
{
    public partial class expensive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "EnterpriseBalance",
                table: "Expensive",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterpriseBalance",
                table: "Expensive");
        }
    }
}
