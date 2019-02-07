using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiTinder.Migrations
{
    public partial class MatchModelKeyPropChangedToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Username_2",
                table: "Matches",
                newName: "Username2");

            migrationBuilder.RenameColumn(
                name: "Username_1",
                table: "Matches",
                newName: "Username1");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Swipe",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username2",
                table: "Matches",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Username1",
                table: "Matches",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Matches",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Swipe");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Username2",
                table: "Matches",
                newName: "Username_2");

            migrationBuilder.RenameColumn(
                name: "Username1",
                table: "Matches",
                newName: "Username_1");

            migrationBuilder.AlterColumn<string>(
                name: "Username_2",
                table: "Matches",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Username_1",
                table: "Matches",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                columns: new[] { "Username_1", "Username_2" });
        }
    }
}
