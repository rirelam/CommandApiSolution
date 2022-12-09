using CommandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandApi.Data;

public class CommandContext : DbContext
{
    public CommandContext(DbContextOptions<CommandContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Command>().HasData(
                    new Command
                    {
                        Id = 1,
                        HowTo = "How to generate a migration",
                        CommandLine = "dotnet ef migrations add <Name of Migration>",
                        Platform = ".Net Core EF Command line"
                    },
                    new Command
                    {
                        Id = 2,
                        HowTo = "Run Migrations",
                        CommandLine = "dotnet ef database update",
                        Platform = ".Net Core EF Command line"
                    },
                    new Command
                    {
                        Id = 3,
                        HowTo = "How to generate a migration",
                        CommandLine = "add-migration <Name of Migration>",
                        Platform = "EF Package Manager Console"
                    },
                    new Command
                    {
                        Id = 4,
                        HowTo = "Run Migrations",
                        CommandLine = "database update",
                        Platform = "EF Package Manager Console"
                    }
        );
    }
    public DbSet<Command>? CommandItems { get; set; }
}