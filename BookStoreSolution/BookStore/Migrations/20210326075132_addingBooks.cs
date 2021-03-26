using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class addingBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_BookGallery_tbl_Books_BooksId",
                table: "tbl_BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_tbl_BookGallery_BooksId",
                table: "tbl_BookGallery");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "tbl_BookGallery");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BookGallery_BookId",
                table: "tbl_BookGallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_BookGallery_tbl_Books_BookId",
                table: "tbl_BookGallery",
                column: "BookId",
                principalTable: "tbl_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_BookGallery_tbl_Books_BookId",
                table: "tbl_BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_tbl_BookGallery_BookId",
                table: "tbl_BookGallery");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "tbl_BookGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BookGallery_BooksId",
                table: "tbl_BookGallery",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_BookGallery_tbl_Books_BooksId",
                table: "tbl_BookGallery",
                column: "BooksId",
                principalTable: "tbl_Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
