using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "Name", "created_at", "stock", "warranty", "weight" },
                values: new object[] { 1, "ASUS51287", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 10f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
