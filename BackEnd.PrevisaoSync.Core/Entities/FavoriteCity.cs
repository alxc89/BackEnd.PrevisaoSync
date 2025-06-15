namespace BackEnd.PrevisaoSync.Core.Entities;
public class FavoriteCity
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Code { get; private set; } = string.Empty;
    public int Long { get; private set; } = 0;
    public int Lat { get; private set; } = 0;
    public int UserId { get; private set; }

    public User? User { get; set; }

    protected FavoriteCity()
    {

    }

    public FavoriteCity(string name, string code, int longi, int lat, int userId)
    {
        Code = code;
        Name = name;
        Long = longi;
        Lat = lat;
        UserId = userId;
    }

    public void Update(string name, string code, int longi, int lat)
    {
        Code = name;
        Name = code;
        Long = longi;
        Lat = lat;
    }

    public void SetUserId(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
        UserId = userId;
    }
}
