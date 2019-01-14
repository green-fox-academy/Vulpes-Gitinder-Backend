using Microsoft.EntityFrameworkCore.Migrations;

namespace GiTinder.Migrations
{
    public partial class MigrationTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_Username",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_Username",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Settings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Username",
                table: "Settings",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_Username",
                table: "Settings",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_Username",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_Username",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Settings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Username",
                table: "Settings",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_Username",
                table: "Settings",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
