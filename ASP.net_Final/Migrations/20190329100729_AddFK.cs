using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.net_Final.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_AspNetUsers_UserId",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Todo",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_UserId",
                table: "Todo",
                newName: "IX_Todo_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_AspNetUsers_UserID",
                table: "Todo",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_AspNetUsers_UserID",
                table: "Todo");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Todo",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_UserID",
                table: "Todo",
                newName: "IX_Todo_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_AspNetUsers_UserId",
                table: "Todo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
