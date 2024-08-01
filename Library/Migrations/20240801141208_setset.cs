using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class setset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookcaseId",
                table: "SetOfBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SetOfBooks_BookcaseId",
                table: "SetOfBooks",
                column: "BookcaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetOfBooks_Bookcases_BookcaseId",
                table: "SetOfBooks",
                column: "BookcaseId",
                principalTable: "Bookcases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetOfBooks_Bookcases_BookcaseId",
                table: "SetOfBooks");

            migrationBuilder.DropIndex(
                name: "IX_SetOfBooks_BookcaseId",
                table: "SetOfBooks");

            migrationBuilder.DropColumn(
                name: "BookcaseId",
                table: "SetOfBooks");
        }
    }
}
