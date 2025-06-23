namespace BackEnd.PrevisaoSync.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = null!;
    public ICollection<FavoriteCity> FavoriteCities { get; set; } = [];

    public User(string fullName, string email, string password)
    {
        FullName = fullName;
        Email = email;
        HashPassword(password);
    }

    protected User() { }

    public void Update(string fullName, string email)
    {
        if (string.IsNullOrEmpty(fullName))
            throw new ArgumentException("Nome completo não informado!", nameof(fullName));
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email não informado!", nameof(email));
        FullName = fullName;
        Email = email;
    }

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

    private void HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Senha não informada!.", nameof(password));

        // Here you would implement your hashing logic, e.g., using BCrypt or another hashing library
        PasswordHash = password; // Placeholder for actual hashing logic
    }
}