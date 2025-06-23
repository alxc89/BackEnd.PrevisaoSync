namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class ForecastDto
{
    public int Cod { get; set; }
    public int Message { get; set; }
    public int Cnt { get; set; }

    public List<ForecastItemDto> List { get; set; } = new();
    public CityForecastDto City { get; set; } = null!;
}
