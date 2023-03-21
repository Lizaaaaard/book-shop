using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "S. King", new DateTime(1999, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Green Mile" },
                    { 2, "A. C. Doyle", new DateTime(1901, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hound of Baskervilles" },
                    { 3, "J. London", new DateTime(1909, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martin Eden" },
                    { 4, "R. L. Stevenson", new DateTime(1883, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Treasure island" },
                    { 5, "M. Mitchell", new DateTime(1936, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gone with the Wind" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BookId", "OrderDate", "OrderId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 3, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 4, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 3, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 1, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 4, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 5, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, 2, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, 5, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
