namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class CityForecastDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CoordDto Coord { get; set; } = null!;
    public string Country { get; set; } = string.Empty;
    public int Population { get; set; }
    public int Timezone { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
}