using BackEnd.PrevisaoSync.Core.Entities;

namespace BackEnd.PrevisaoSync.Core.Interface.Repositories;
public interface ICityRepository
{
    Task AddRangeAsync(IEnumerable<City> cities);
    Task<IEnumerable<City>> GetCityByName(string name);
}
