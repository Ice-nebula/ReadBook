using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoryModelBookModel");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookCategory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookId",
                table: "BookCategory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Book_BookId",
                table: "BookCategory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Book_BookId",
                table: "BookCategory");

            migrationBuilder.DropIndex(
                name: "IX_BookCategory_BookId",
                table: "BookCategory");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookCategory");

            migrationBuilder.CreateTable(
                name: "BookCategoryModelBookModel",
                columns: table => new
                {
                    BookCategorysId = table.Column<int>(type: "integer", nullable: false),
                    booksBookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoryModelBookModel", x => new { x.BookCategorysId, x.booksBookId });
                    table.ForeignKey(
                        name: "FK_BookCategoryModelBookModel_Book_booksBookId",
                        column: x => x.booksBookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoryModelBookModel_BookCategory_BookCategorysId",
                        column: x => x.BookCategorysId,
                        principalTable: "BookCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoryModelBookModel_booksBookId",
                table: "BookCategoryModelBookModel",
                column: "booksBookId");
        }
    }
}
