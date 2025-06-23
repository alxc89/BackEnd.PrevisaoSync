namespace BackEnd.PrevisaoSync.Core.Entities;
public class FavoriteCity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Code { get; private set; } = string.Empty;
    public double Lon { get; private set; } = 0;
    public double Lat { get; private set; } = 0;
    public string Icon { get; private set; }
    public double Temp { get; private set; }
    public double Feels_like { get; private set; }
    public string Description { get; private set; }
    public double Humidity { get; private set; }
    public double Speed { get; private set; }
    public int UserId { get; private set; }

    public User? User { get; set; }

    protected FavoriteCity()
    {

    }

    public FavoriteCity(string name, string code, double lon, double lat, string icon, double temp, 
        double feels_like, string description, double humidity, double speed, int userId)
    {
        Name = name;
        Code = code;
        Lon = lon;
        Lat = lat;
        Icon = icon;
        Temp = temp;
        Feels_like = feels_like;
        Description = description;
        Humidity = humidity;
        Speed = speed;
        UserId = userId;
    }

    public void Update(string name, string code, double lon, double lat)
    {
        Code = name;
        Name = code;
        Lon = lon;
        Lat = lat;
    }

    public void SetUserId(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
        UserId = userId;
    }
}
