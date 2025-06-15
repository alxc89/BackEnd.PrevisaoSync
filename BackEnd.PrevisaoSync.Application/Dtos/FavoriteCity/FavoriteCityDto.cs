namespace BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
public class FavoriteCityDto
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public int Long { get; set; } = 0;
    public int Lat { get; set; } = 0;
    public int UserId { get; set; }
}