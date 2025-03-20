using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersistanceLayer.Migrations
{
    /// <inheritdoc />
    public partial class changesInBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "students_tbl");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "students_tbl",
                newName: "ModifiedOn");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "students_tbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "students_tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "students_tbl",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "students_tbl");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "students_tbl");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "students_tbl");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "students_tbl",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "students_tbl",
                type: "datetime2",
                nullable: true);
        }
    }
}
