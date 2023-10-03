using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCompartilhamento.Infrastructure.Migrations
{
    public partial class added_library_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "tb_books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Librarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_books_LibraryId",
                table: "tb_books",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_books_Librarys_LibraryId",
                table: "tb_books",
                column: "LibraryId",
                principalTable: "Librarys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_books_Librarys_LibraryId",
                table: "tb_books");

            migrationBuilder.DropTable(
                name: "Librarys");

            migrationBuilder.DropIndex(
                name: "IX_tb_books_LibraryId",
                table: "tb_books");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "tb_books");
        }
    }
}
