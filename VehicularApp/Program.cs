using Microsoft.EntityFrameworkCore;
using Vahicular.Services;
using Vehicular.Data;
using Vehicular.IRepositories;
using Vehicular.IServices;
using Vehicular.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");




// Add services to the container.

builder.Services.AddDbContext<VehicularAppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddControllers();


// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseCors("EnableCORS");

app.Run();
