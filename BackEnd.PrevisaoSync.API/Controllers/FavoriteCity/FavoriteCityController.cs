using BackEnd.PrevisaoSync.Application.Dtos.FavoriteCity;
using BackEnd.PrevisaoSync.Application.Services.FavoriteCity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.PrevisaoSync.API.Controllers.FavoriteCity;

[Route("api/[controller]")]
[ApiController]
public class FavoriteCityController(IFavoriteCityService favoriteCityService) : ControllerBase
{
    private readonly IFavoriteCityService _favoriteCityService = favoriteCityService;

    [HttpGet("GetFavoriteCity/{id}/userId/{userId}")]
    public IActionResult GetFavoriteCity(int id, int userId)
    {
        try
        {
            var favoriteCity = _favoriteCityService.GetByIdAsync(id, userId).Result;
            if (!favoriteCity.Success)
                return NotFound("Não foi localizado a cidade nos favoritos para o usuário!");
            if (!favoriteCity.Success)
                return BadRequest(favoriteCity.Message);

            return Ok(favoriteCity.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar a cidade favorita: {e.Message}");
        }
    }

    [HttpGet("GetFavoriteCities/{userId}")]
    public IActionResult GetFavoriteCities(int userId)
    {
        try
        {
            var favoriteCities = _favoriteCityService.FavoriteCitiesAsync(userId).Result;
            if (!favoriteCities.Success)
                return NotFound("Não foi localizado cidades nos favoritos para o usuários!");
            if (!favoriteCities.Success)
                return BadRequest(favoriteCities.Message);

            return Ok(favoriteCities.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar as cidades favoritas: {e.Message}");
        }
    }

    [HttpPost("AddFavoriteCity")]
    public IActionResult AddFavoriteCity(FavoriteCityDto favoriteCityDto)
    {
        try
        {
            var favoriteCityAdded = _favoriteCityService.AddAsync(favoriteCityDto).Result;

            if (!favoriteCityAdded.Success)
                return BadRequest(favoriteCityAdded.Message);

            return Ok(favoriteCityAdded.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao adicionar a cidade aos favoritos: {e.Message}");
        }
    }

    [HttpDelete("RemoveFavoriteCity/{id}/userId/{userId}")]
    public IActionResult RemoveFavoriteCity(int id, int userId)
    {
        try
        {
            var favoriteCityRemoved = _favoriteCityService.DeleteAsync(id, userId).Result;
            if (!favoriteCityRemoved.Success)
                return BadRequest(favoriteCityRemoved.Message);
            return Ok($"Cidade com o ID {id} removida dos favoritos!");
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao buscar cidades favoritas: {e.Message}");
        }
    }

    [HttpPatch("UpdateFavoriteCity/{id}/userId/{userId}")]
    public IActionResult UpdateFavoriteCity(FavoriteCityDto favoriteCityDto, int id, int userId)
    {
        try
        {
            var favoriteCityUpdated = _favoriteCityService.UpdateAsync(favoriteCityDto, id, userId).Result;
            if (!favoriteCityUpdated.Success)
                return BadRequest(favoriteCityUpdated.Message);
            return Ok(favoriteCityUpdated.Data);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Erro ao atualizar a cidade favorita: {e.Message}");
        }
    }
}
