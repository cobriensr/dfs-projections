using FantasySports.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register each context separately with its own schema
builder.Services.AddDbContext<NFLDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsHistoryTable("__EFMigrationsHistory", "nfl")));

builder.Services.AddDbContext<MLBDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsHistoryTable("__EFMigrationsHistory", "mlb")));

builder.Services.AddDbContext<CFBDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsHistoryTable("__EFMigrationsHistory", "cfb")));

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

await app.RunAsync();

// dotnet ef migrations add InitialNFL -c NFLDbContext
// dotnet ef migrations add InitialMLB -c MLBDbContext
// dotnet ef migrations add InitialCFB -c CFBDbContext