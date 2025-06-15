using BackEnd.PrevisaoSync.Core.Entities;

namespace BackEnd.PrevisaoSync.Core.Interface.Repositories;
public interface IFavoriteCityRepository
{
    Task<IEnumerable<FavoriteCity>> FavoriteCities(int userId);
    Task<FavoriteCity?> GetById(int id, int userId);
    Task<bool> Delete(int id, int userId);
    Task<FavoriteCity> Add(FavoriteCity favoriteCity);
    Task<FavoriteCity> Update(FavoriteCity favoriteCity, int userId);
    Task<bool> Exists(string code);
}
