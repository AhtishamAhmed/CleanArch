using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistanceLayer.Migrations
{
    /// <inheritdoc />
    public partial class addFavouriteBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "book_tbl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book_tbl",
                table: "book_tbl",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "favouriteBook_tbl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favouriteBook_tbl", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favouriteBook_tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book_tbl",
                table: "book_tbl");

            migrationBuilder.RenameTable(
                name: "book_tbl",
                newName: "Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");
        }
    }
}
