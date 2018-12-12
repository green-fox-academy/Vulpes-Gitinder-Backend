using Microsoft.EntityFrameworkCore.Migrations;

namespace GiTinder.Migrations
{
    public partial class PropertyInSettingsModelCalledSettingsAreValidWasRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingsAreValid",
                table: "Settings");

            migrationBuilder.AddColumn<int>(
                name: "UserSettingsId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSettingsId",
                table: "Users",
                column: "UserSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_UserSettingsId",
                table: "Users",
                column: "UserSettingsId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Settings_UserSettingsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSettingsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSettingsId",
                table: "Users");

            migrationBuilder.AddColumn<short>(
                name: "SettingsAreValid",
                table: "Settings",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
