using BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
using BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Shared;

namespace BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
public interface IFavoriteCityService
{
    Task<ServiceResponse<IEnumerable<FavoriteCityView>>> FavoriteCitiesAsync(int userId);
    Task<ServiceResponse<FavoriteCityView>> GetByIdAsync(int id, int userId);
    Task<ServiceResponse<bool>> DeleteAsync(int id, int userId);
    Task<ServiceResponse<FavoriteCityView>> AddAsync(FavoriteCityDto favoriteCity);
    Task<ServiceResponse<FavoriteCityView>> UpdateAsync(FavoriteCityDto favoriteCity, int id, int userId);
}
