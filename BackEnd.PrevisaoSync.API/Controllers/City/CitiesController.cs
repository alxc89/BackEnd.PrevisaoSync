using BackEnd.PrevisaoSync.Application.Dtos.City;
using BackEnd.PrevisaoSync.Application.Services.City;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.PrevisaoSync.API.Controllers.City;

[ApiController]
[Route("api/[controller]")]
public class CitiesController(ICityService cityService) : ControllerBase
{
    private readonly ICityService _cityService = cityService;

    [HttpPost]
    public async Task<IActionResult> Import([FromBody] ImportCitiesDto importCitiesDto)
    {
        try
        {
            await _cityService.ImportAsync(importCitiesDto.FilePath);
            return Ok("Importação concluída com sucesso.");
        }
        catch (Exception e)
        {
            return BadRequest($"Erro ao importar cidades: {e.Message}");
        }
    }

    [HttpGet("GetCitySuggestions")]
    public async Task<IActionResult> GetCitySuggestions([FromQuery] string name)
    {
        try
        {
            var results = await _cityService.GetCitySuggestionsAsync(name);
            return Ok(results);
        }
        catch (Exception e)
        {
            return BadRequest($"Erro ao buscar cidades: {e.Message}");
        }
    }
}
