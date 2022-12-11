using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommandApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCommandsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HowTo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Platform = table.Column<string>(type: "text", nullable: false),
                    CommandLine = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandItems", x => x.Id);
                });

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
            migrationBuilder.DropTable(
                name: "CommandItems");
        }
    }
}
