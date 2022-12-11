using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommandApiRepo, SqlCommandApiRepo>();

var npgsqlbuilder = new NpgsqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"),
    Username = builder.Configuration["User ID"],
    Password = builder.Configuration["Password"]
};
var connStr = npgsqlbuilder.ToString().Replace("Username", "User Id");
builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(connStr));
// builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new
    CamelCasePropertyNamesContractResolver();
});
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
