using BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
using BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Shared;

namespace BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
public interface IFavoriteCityService
{
    Task<ServiceResponse<IEnumerable<FavoriteCityView>>> FavoriteCities(int userId);
    Task<ServiceResponse<FavoriteCityView>> GetById(int id, int userId);
    Task<ServiceResponse<bool>> Delete(int id, int userId);
    Task<ServiceResponse<FavoriteCityView>> Add(FavoriteCityDto favoriteCity);
    Task<ServiceResponse<FavoriteCityView>> Update(FavoriteCityDto favoriteCity, int id, int userId);
}
