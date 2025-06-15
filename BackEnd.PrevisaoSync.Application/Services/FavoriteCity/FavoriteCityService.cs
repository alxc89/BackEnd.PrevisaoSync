using BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
using BackEnd.PrevisaoSync.Application.ModelView.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Shared;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;

namespace BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
public class FavoriteCityService(IFavoriteCityRepository repository) : IFavoriteCityService
{
    private readonly IFavoriteCityRepository _repository = repository;

    public async Task<ServiceResponse<FavoriteCityView>> Add(FavoriteCityDto favoriteCity)
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

    public async Task<ServiceResponse<IEnumerable<FavoriteCityView>>> FavoriteCities(int userId)
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
                Long = c.Long,
                Lat = c.Lat,
                UserId = c.UserId
            }), "Cidades favoritas encontradas com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<IEnumerable<FavoriteCityView>>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<FavoriteCityView>> GetById(int id, int userId)
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
                Long = favoriteCity.Long,
                Lat = favoriteCity.Lat,
                UserId = favoriteCity.UserId
            }, "Cidades favoritas encontradas com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<bool>> Delete(int id, int userId)
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

    public async Task<ServiceResponse<FavoriteCityView>> Update(FavoriteCityDto favoriteCityDto, int id, int userId)
    {
        try
        {
            var favoriteCity = await _repository.GetById(id, userId);
            if (favoriteCity is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Nenhuma cidade favorita encontrada!");
            var updatedCity = new Core.Entities.FavoriteCity(favoriteCityDto.Name, favoriteCityDto.Code,
                favoriteCityDto.Long, favoriteCityDto.Lat, userId);
            var updated = await _repository.Update(updatedCity, userId);
            if (updated is null)
                return ServiceResponseHelper.Error<FavoriteCityView>("Erro ao salvar a cidade dos favoritos!");
            return ServiceResponseHelper.Success(new FavoriteCityView
            {
                Id = updated.Id,
                Name = updated.Name,
                Code = updated.Code,
                Long = updated.Long,
                Lat = updated.Lat,
                UserId = updated.UserId
            }, "Cidade alterada dos favoritos com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<FavoriteCityView>($"Erro: {e.Message}");
        }
    }
}