using BackEnd.PrevisaoSync.Application.Services.WeatherService;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.PrevisaoSync.API.Controllers.WeatherService;

[Route("api/[controller]")]
[ApiController]
public class WeatherServiceController(IWeatherService weatherService) : ControllerBase
{
    private readonly IWeatherService _weatherService = weatherService;

    [HttpGet("weather/{code}")]
    public async Task<IActionResult> GetWeatherAsync(string code)
    {
        try
        {
            var weatherData = await _weatherService.GetCurrentWeatherAsync(code);
            if (weatherData == null)
                return NotFound($"Previsão não localizada!");
            return Ok(weatherData);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar dados de previsão: {e.Message}");
        }
    }

    [HttpGet("details/lat/{lat}/lon/{lon}")]
    public async Task<IActionResult> GetForecastDetailsAsync(decimal lat, decimal lon)
    {
        try
        {
            var forecastDetails = await _weatherService.GetForecastDetailsAsync(lat, lon);
            if (forecastDetails == null)
                return NotFound($"Detalhes da previsão não encontrados!");
            return Ok(forecastDetails);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar detalhes da previsão: {e.Message}");
        }
    }
}
