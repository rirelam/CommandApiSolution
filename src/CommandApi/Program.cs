using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();

var pgsqlBuilder = new NpgsqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"),
    Username = builder.Configuration["UserID"],
    Password = builder.Configuration["Password"]
};
builder.Services.AddDbContext<CommandContext>
(opt => opt.UseNpgsql(pgsqlBuilder.ConnectionString));

builder.Services.AddDbContext<CommandContext>(
    opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
