using EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StockLogger2DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockLoggerDbConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient
builder.Services.AddHttpClient(); // This adds the HttpClient service

builder.Services.AddHostedService<StockPriceFetcherService>();

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
