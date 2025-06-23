using BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
using BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Shared;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;

namespace BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
public class FavoriteCityService(IFavoriteCityRepository repository) : IFavoriteCityService
{
    private readonly IFavoriteCityRepository _repository = repository;

    public async Task<ServiceResponse<FavoriteCityView>> AddAsync(FavoriteCityDto favoriteCity)
    {
        try
        {
            var exists = await _repository.Exists(favoriteCity.Code);
            if (exists)
                return ServiceResponseHelper.Error<FavoriteCityView>("Cidade já existe como favorito!");

            var entity = new Core.Entities.FavoriteCity(favoriteCity.Name, favoriteCity.Code, favoriteCity.Lon, favoriteCity.Lat,
                favoriteCity.Icon, favoriteCity.Temp, favoriteCity.Feels_like, favoriteCity.Description, favoriteCity.Humidity, favoriteCity.Speed, favoriteCity.UserId);
            var saved = await _repository.Add(entity);
            if (saved is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Erro ao salvar a cidade favorita!");
            return ServiceResponseHelper.Success(new FavoriteCityView
            {
                Id = saved.Id,
                Name = saved.Name,
                Code = saved.Code,
                Lon = saved.Lon,
                Lat = saved.Lat,
                Icon = saved.Icon,
                Temp = saved.Temp,
                Feels_like = saved.Feels_like,
                Description = saved.Description,
                Humidity = saved.Humidity,
                Speed = saved.Speed,
                UserId = saved.UserId
            }, "Cidade salva aos favoritos com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<IEnumerable<FavoriteCityView>>> FavoriteCitiesAsync(int userId)
    {
        try
        {
            var favoriteCities = await _repository.FavoriteCities(userId);
            if (favoriteCities is null || !favoriteCities.Any())
                return ServiceResponseHelper.Error<IEnumerable<FavoriteCityView>>("Nenhuma cidade favorita encontrada!");
            return ServiceResponseHelper.Success(favoriteCities.Select(c => new FavoriteCityView
            {
                Id = c.Id,
                Name = c.Name,
                Code = c.Code,
                Lon = c.Lon,
                Lat = c.Lat,
                Icon = c.Icon,
                Description = c.Description,
                Temp = c.Temp,
                Feels_like = c.Feels_like,
                Humidity = c.Humidity,
                Speed = c.Speed,
                UserId = c.UserId
            }), "Cidades favoritas encontradas com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<IEnumerable<FavoriteCityView>>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<FavoriteCityView>> GetByIdAsync(int id, int userId)
    {
        try
        {
            var favoriteCity = await _repository.GetById(id, userId);
            if (favoriteCity is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Nenhuma cidade favorita encontrada!");
            return ServiceResponseHelper.Success(new FavoriteCityView
            {
                Id = favoriteCity.Id,
                Name = favoriteCity.Name,
                Code = favoriteCity.Code,
                Lon = favoriteCity.Lon,
                Lat = favoriteCity.Lat,
                Icon = favoriteCity.Icon,
                Description = favoriteCity.Description,
                Temp = favoriteCity.Temp,
                Feels_like = favoriteCity.Feels_like,
                Humidity = favoriteCity.Humidity,
                Speed = favoriteCity.Speed,
                UserId = favoriteCity.UserId
            }, "Cidades favoritas encontradas com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<bool>> DeleteAsync(int id, int userId)
    {
        try
        {
            var favoriteCity = await _repository.GetById(id, userId);
            if (favoriteCity is null)
                return ServiceResponseHelper.Error<bool>("Nenhuma cidade favorita encontrada!");
            var deleted = await _repository.Delete(id, userId);
            if (!deleted)
                return ServiceResponseHelper.Error<bool>("Erro ao deletar a cidade dos favoritos!");
            return ServiceResponseHelper.Success(true, "Cidade deletada dos favoritos com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<bool>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<FavoriteCityView>> UpdateAsync(FavoriteCityDto favoriteCityDto, int id, int userId)
    {
        try
        {
            var favoriteCity = await _repository.GetById(id, userId);
            if (favoriteCity is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Nenhuma cidade favorita encontrada!");
            favoriteCity.Update(favoriteCityDto.Name, favoriteCityDto.Code, favoriteCityDto.Lon, favoriteCityDto.Lat);
            var updated = await _repository.Update(favoriteCity, userId);
            if (updated is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Erro ao salvar a cidade dos favoritos!");
            return ServiceResponseHelper.Success(new FavoriteCityView
            {
                Id = updated.Id,
                Name = updated.Name,
                Code = updated.Code,
                Lon = updated.Lon,
                Lat = updated.Lat,
                Icon = updated.Icon,
                Description = updated.Description,
                Temp = updated.Temp,
                Feels_like = updated.Feels_like,
                Humidity = updated.Humidity,
                Speed = updated.Speed,
                UserId = updated.UserId
            }, "Cidade alterada dos favoritos com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }
}