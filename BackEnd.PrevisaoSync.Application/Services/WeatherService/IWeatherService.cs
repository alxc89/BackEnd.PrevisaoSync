using BackEnd.PrevisaoSync.Application.Dtos.WeatherService;

namespace BackEnd.PrevisaoSync.Application.Services.WeatherService;
public interface IWeatherService
{
    Task<WeatherResponseDto> GetCurrentWeatherAsync(string code);
    Task<ForecastDto> GetForecastDetailsAsync(decimal lat, decimal lon);
}