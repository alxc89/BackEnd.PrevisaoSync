using BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Services.User;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;
using BackEnd.PrevisaoSync.Infra.Context;
using BackEnd.PrevisaoSync.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IFavoriteCityRepository, FavoriteCityRepository>();
builder.Services.AddScoped<IFavoriteCityService, FavoriteCityService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("BackEnd.PrevisaoSync.Infra")));
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrevisaoSync API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x =>
{
    //x.AllowAnyOrigin();
    //x.AllowAnyMethod();
    //x.AllowAnyHeader();
    //x.AllowCredentials();
});

app.Run();
