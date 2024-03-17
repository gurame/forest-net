using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EagleBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Books");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("7253e151-34f8-4a04-8fbf-632094d7c4df"), "J.R.R Tolkien", 11.99m, "The Two Towers" },
                    { new Guid("8835ac79-354d-407c-b503-0f9fb757c9e2"), "J.R.R Tolkien", 12.99m, "The Return of the Ring" },
                    { new Guid("e80fb007-f546-4142-82c0-b22334592da1"), "J.R.R Tolkien", 10.99m, "The Fellowship of the Ring" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Books");
        }
    }
}
