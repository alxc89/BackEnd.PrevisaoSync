using BackEnd.PrevisaoSync.Application.Dtos.City;

namespace BackEnd.PrevisaoSync.Application.Services.City;
public interface ICityService
{
    Task ImportAsync(string filePath);
    Task<IEnumerable<CityDto>> GetCitySuggestionsAsync(string name);
}
