using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rare_BE.Migrations
{
    public partial class SubUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_AuthorId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_AuthorId",
                table: "Subscriptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AuthorId",
                table: "Subscriptions",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_AuthorId",
                table: "Subscriptions",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
