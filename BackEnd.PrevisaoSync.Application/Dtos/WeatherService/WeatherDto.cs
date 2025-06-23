namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class WeatherDto
{
    public int Id { get; set; }
    public string Main { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Icon { get; set; } = null!;
}
