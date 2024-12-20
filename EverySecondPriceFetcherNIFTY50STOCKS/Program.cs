using EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StockLogger2DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockLoggerDbConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddHostedService<StockPriceFetcherService>();
//builder.Services.AddHostedService<StockPriceFetcherService2>();
//builder.Services.AddHostedService<StockPriceFetcherService3>();
//builder.Services.AddHostedService<StockPriceFetcherService4>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
