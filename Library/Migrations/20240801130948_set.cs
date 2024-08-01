using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class set : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SetBooksId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SetOfBooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetOfBooks", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_SetBooksId",
                table: "Books",
                column: "SetBooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SetOfBooks_SetBooksId",
                table: "Books",
                column: "SetBooksId",
                principalTable: "SetOfBooks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SetOfBooks_SetBooksId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "SetOfBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_SetBooksId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SetBooksId",
                table: "Books");
        }
    }
}
