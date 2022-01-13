using Microsoft.EntityFrameworkCore.Migrations;

namespace DirtRivalsswag.Migrations
{
    public partial class RivalIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Rivals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rivals_DriverName",
                table: "Rivals",
                column: "DriverName",
                unique: true,
                filter: "[DriverName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rivals_DriverName",
                table: "Rivals");

            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Rivals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
