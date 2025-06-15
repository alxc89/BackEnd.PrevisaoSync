namespace BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
public class FavoriteCityView
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = string.Empty;
    public int Long { get; set; } = 0;
    public int Lat { get; set; } = 0;
    public int UserId { get; set; }
}