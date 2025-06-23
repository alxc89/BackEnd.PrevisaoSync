using BackEnd.PrevisaoSync.Core.Entities;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;
using BackEnd.PrevisaoSync.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.PrevisaoSync.Infra.Repository;
public class CityRepository(DataContext context) : ICityRepository
{
    private readonly DataContext _context = context;

    public async Task AddRangeAsync(IEnumerable<City> cities)
    {
        await _context.Cities.AddRangeAsync(cities);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<City>> GetCityByName(string name)
    {
        try
        {
            var cities = await _context.Cities
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%"))
                .OrderBy(c => c.Name)
                .Take(20)
                .ToListAsync();
            return cities;
        }
        catch (Exception e)
        {
            throw new Exception($"Erro {e.Message}");
        }
    }
}
