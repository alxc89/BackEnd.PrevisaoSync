namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class SysDto
{
    public int Type { get; set; }
    public int Id { get; set; }
    public string Country { get; set; } = null!;
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
    public string Pod { get; set; } = string.Empty;
}