using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class BookcaseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bookcases_BookcaseId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookcaseId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bookcases_BookcaseId",
                table: "Books",
                column: "BookcaseId",
                principalTable: "Bookcases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bookcases_BookcaseId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookcaseId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bookcases_BookcaseId",
                table: "Books",
                column: "BookcaseId",
                principalTable: "Bookcases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
