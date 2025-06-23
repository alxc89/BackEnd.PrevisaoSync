using BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace BackEnd.PrevisaoSync.Application.Services.WeatherService;
public class WeatherService(HttpClient httpClient, IConfiguration config) : IWeatherService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _config = config;

    public async Task<WeatherResponseDto> GetCurrentWeatherAsync(string code)
    {
        var apiKey = _config["Weather:ApiKey"];
        var url = $"http://api.openweathermap.org/data/2.5/weather?id={code}&appid={apiKey}&lang=pt_br&units=metric";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<WeatherResponseDto>()
               ?? throw new InvalidOperationException("Erro ao deserializar resposta da API");
    }

    public async Task<ForecastDto> GetForecastDetailsAsync(decimal lat, decimal lon)
    {
        try
        {
            var apiKey = _config["Weather:ApiKey"];
            var url = $"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={apiKey}&units=metric&lang=pt_br";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var forecastDto = await response.Content.ReadFromJsonAsync<ForecastDto>();
            if (forecastDto is null)
                throw new InvalidOperationException("Erro ao deserializar resposta da API");

            var list = new List<ForecastItemDto>();
            int count = 0;
            foreach (var item in forecastDto!.List.OrderBy(f => f.Dt))
            {
                if (list.Count > 0 && list.Any(d => d.Dt_Txt.Equals(item.Dt_Txt)))
                    continue;
                list.Add(item);
                count++;
                if (count >= 5) // Limita a 5 itens
                    break;
            }
            forecastDto.List = list;
            return forecastDto;
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao buscar detalhes da cidade:{e.Message}");
        }
    }
}
