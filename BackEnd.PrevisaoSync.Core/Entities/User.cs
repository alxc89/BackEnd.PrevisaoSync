namespace BackEnd.PrevisaoSync.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = null!;
    public ICollection<FavoriteCity> FavoriteCities { get; set; } = [];

    public User(string fullName, string email, string passwordHash)
    {
        FullName = fullName;
        Email = email;
        PasswordHash = passwordHash;
    }

    protected User() { }

    public void AddFavoriteCity(FavoriteCity favoriteCity)
    {
        if (favoriteCity == null)
            throw new ArgumentNullException(nameof(favoriteCity));
        favoriteCity.SetUserId(Id);
        FavoriteCities.Add(favoriteCity);
    }

    public void RemoveFavoriteCity(FavoriteCity favoriteCity)
    {
        if (favoriteCity == null)
            throw new ArgumentNullException(nameof(favoriteCity));
        FavoriteCities.Remove(favoriteCity);
    }
}