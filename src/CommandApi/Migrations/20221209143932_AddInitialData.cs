using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommandApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CommandItems",
                columns: new[] { "Id", "CommandLine", "HowTo", "Platform" },
                values: new object[,]
                {
                    { 1, "dotnet ef migrations add <Name of Migration>", "How to generate a migration", ".Net Core EF Command line" },
                    { 2, "dotnet ef database update", "Run Migrations", ".Net Core EF Command line" },
                    { 3, "add-migration <Name of Migration>", "How to generate a migration", "EF Package Manager Console" },
                    { 4, "database update", "Run Migrations", "EF Package Manager Console" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommandItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommandItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommandItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CommandItems",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
