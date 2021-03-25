using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class addLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "tbl_Books");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "tbl_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_Lang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Lang", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Books_LanguageId",
                table: "tbl_Books",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Books_tbl_Lang_LanguageId",
                table: "tbl_Books",
                column: "LanguageId",
                principalTable: "tbl_Lang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Books_tbl_Lang_LanguageId",
                table: "tbl_Books");

            migrationBuilder.DropTable(
                name: "tbl_Lang");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Books_LanguageId",
                table: "tbl_Books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "tbl_Books");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "tbl_Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
