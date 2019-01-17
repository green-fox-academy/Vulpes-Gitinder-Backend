using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiTinder.Migrations
{
    public partial class swipeModelChangedAfterReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Swipe",
                table: "Swipe");

            migrationBuilder.DropColumn(
                name: "SwipeId",
                table: "Swipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Swipe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Timestamp",
                table: "Swipe",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SwipedUserId",
                table: "Swipe",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SwipingUserId",
                table: "Swipe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swipe",
                table: "Swipe",
                columns: new[] { "SwipingUserId", "SwipedUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Swipe",
                table: "Swipe");

            migrationBuilder.DropColumn(
                name: "SwipingUserId",
                table: "Swipe");

            migrationBuilder.AlterColumn<string>(
                name: "Timestamp",
                table: "Swipe",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "SwipedUserId",
                table: "Swipe",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "SwipeId",
                table: "Swipe",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Swipe",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swipe",
                table: "Swipe",
                column: "SwipeId");
        }
    }
}
