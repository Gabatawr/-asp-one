using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Data.Migrations
{
    public partial class UpdateBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublishersId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublishersId",
                table: "Books",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublishersId",
                table: "Books",
                newName: "IX_Books_PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publisher_PublisherId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Books",
                newName: "PublishersId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                newName: "IX_Books_PublishersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publisher_PublishersId",
                table: "Books",
                column: "PublishersId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
