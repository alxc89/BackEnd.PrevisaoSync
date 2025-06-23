namespace BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
public class FavoriteCityDto
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public double Lon { get; set; } = 0;
    public double Lat { get; set; } = 0;
    public int UserId { get; set; }
    public string Icon { get; set; } = string.Empty;
    public double Temp { get; set; }
    public double Feels_like { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Humidity { get; set; }
    public double Speed { get; set; }
}