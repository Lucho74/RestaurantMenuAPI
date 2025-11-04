using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantMenuAPI.Data;
using RestaurantMenuAPI.Repositories.Implementations;
using RestaurantMenuAPI.Repositories.Interfaces;
using RestaurantMenuAPI.Services.Implementations;
using RestaurantMenuAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext < RestaurantMenuContext > (
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:RestaurantMenuDBConnectionString"]
    ));

#region inject dependencies
builder.Services.AddScoped<IUserRepository, RestaurantRepository>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

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
