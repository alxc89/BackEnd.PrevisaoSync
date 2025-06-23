namespace BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
public class FavoriteCityView
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public double Lon { get; set; } = 0;
    public double Lat { get; set; } = 0;
    public int UserId { get; set; }
    public string Icon { get; set; } = string.Empty;
    public double Temp { get; set; } = 0;
    public double Feels_like { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public double Humidity { get; set; } = 0;
    public double Speed { get; set; } = 0;
}