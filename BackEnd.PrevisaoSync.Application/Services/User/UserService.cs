using BackEnd.PrevisaoSync.Application.Dtos.User;
using BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
using BackEnd.PrevisaoSync.Application.ModelView.User;
using BackEnd.PrevisaoSync.Application.Shared;
using BackEnd.PrevisaoSync.Core.Entities;

namespace BackEnd.PrevisaoSync.Application.Services.User;
public class UserService(IUserRepository userService) : IUserService
{
    private readonly IUserService _userService = userService;

    public Task<ServiceResponse<UserViewModel>> CreateUserAsync(UserDto userDto)
    {
        try
        {
            var exists = await _repository.Exists(favoriteCity.Code);
            if (exists)
                return ServiceResponseHelper.Error<FavoriteCityView>("Cidade já existe como favorito!");

            var entity = new Core.Entities.FavoriteCity(favoriteCity.Name, favoriteCity.Code,
                favoriteCity.Long, favoriteCity.Lat, favoriteCity.UserId);
            var saved = await _repository.Add(entity);
            if (saved is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Erro ao salvar a cidade favorita!");
            return ServiceResponseHelper.Success(new FavoriteCityView
            {
                Id = saved.Id,
                Name = saved.Name,
                Code = saved.Code,
                Long = saved.Long,
                Lat = saved.Lat,
                UserId = saved.UserId
            }, "Cidade salva aos favoritos com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }

    public Task DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<UserViewModel>> GetUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<UserViewModel>> UpdateUserAsync(string userId, UserDto userDto)
    {
        throw new NotImplementedException();
    }
}
