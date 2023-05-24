using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCrossing.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBookWriters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookWriter_Books_BookId",
                table: "BookWriter");

            migrationBuilder.DropForeignKey(
                name: "FK_BookWriter_Writers_WriterId",
                table: "BookWriter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookWriter",
                table: "BookWriter");

            migrationBuilder.DropIndex(
                name: "IX_BookWriter_BookId",
                table: "BookWriter");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookWriter");

            migrationBuilder.RenameColumn(
                name: "Shelfname",
                table: "Shelves",
                newName: "ShelfName");

            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "BookWriter",
                newName: "WritersId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookWriter",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_BookWriter_WriterId",
                table: "BookWriter",
                newName: "IX_BookWriter_WritersId");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "BookShelves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookWriter",
                table: "BookWriter",
                columns: new[] { "BooksId", "WritersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookWriter_Books_BooksId",
                table: "BookWriter",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookWriter_Writers_WritersId",
                table: "BookWriter",
                column: "WritersId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookWriter_Books_BooksId",
                table: "BookWriter");

            migrationBuilder.DropForeignKey(
                name: "FK_BookWriter_Writers_WritersId",
                table: "BookWriter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookWriter",
                table: "BookWriter");

            migrationBuilder.RenameColumn(
                name: "ShelfName",
                table: "Shelves",
                newName: "Shelfname");

            migrationBuilder.RenameColumn(
                name: "WritersId",
                table: "BookWriter",
                newName: "WriterId");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookWriter",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookWriter_WritersId",
                table: "BookWriter",
                newName: "IX_BookWriter_WriterId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookWriter",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                table: "BookShelves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookWriter",
                table: "BookWriter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriter_BookId",
                table: "BookWriter",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookWriter_Books_BookId",
                table: "BookWriter",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookWriter_Writers_WriterId",
                table: "BookWriter",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
