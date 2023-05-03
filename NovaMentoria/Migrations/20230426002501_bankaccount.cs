using Microsoft.EntityFrameworkCore.Migrations;

namespace NovaMentoria.Migrations
{
    public partial class bankaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "InitialBalance",
                table: "BankAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "BankAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InitialBalance",
                table: "BankAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "Balance",
                table: "BankAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float));
        }
    }
}
