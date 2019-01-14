using Microsoft.EntityFrameworkCore.Migrations;

namespace GiTinder.Migrations
{
    public partial class UserNamePropertyRefactoredToUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_UserName",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_UserName",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Settings",
                newName: "Username");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_Username",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_Username",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Settings",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Settings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserName",
                table: "Settings",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_UserName",
                table: "Settings",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
