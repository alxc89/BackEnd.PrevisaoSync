using BackEnd.PrevisaoSync.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BackEnd.PrevisaoSync.Infra.Context;
public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao configurar o DbContext: " + e.Message);
            throw;
        }
    }

    public DbSet<FavoriteCity> FavoriteCities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<City> Cities { get; set; }
}