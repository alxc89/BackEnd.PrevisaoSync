using BackEnd.PrevisaoSync.Application.Dtos.City;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BackEnd.PrevisaoSync.Application.Services.City;
public class CityService(ICityRepository cityRepository) : ICityService
{
    private readonly ICityRepository _repository = cityRepository;

    public async Task<IEnumerable<CityDto>> GetCitySuggestionsAsync(string name)
    {
        try
        {
            if (name is null || string.IsNullOrWhiteSpace(name) || name.Length < 2)
                return [];

            var results = await _repository.GetCityByName(name);
            return results.Select(c => new CityDto
            {
                Id = c.Id,
                Name = c.Name,
                State = c.State,
                Country = c.Country,
                Coord = new Coord { Lat = c.Lat, Lon = c.Lon }
            });
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao buscar cidade: {e.Message}");
        }
    }

    public async Task ImportAsync(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Arquivo JSON não encontrado", filePath);

            var json = await File.ReadAllTextAsync(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new IntToStringConverter());
            var cityDtos = JsonSerializer.Deserialize<List<CityDto>>(json, options)!;

            var cities = cityDtos.Select(c => new Core.Entities.City
            {
                Id = c.Id,
                Name = c.Name,
                State = c.State,
                Country = c.Country,
                Lat = c.Coord.Lat,
                Lon = c.Coord.Lon
            });

            await _repository.AddRangeAsync(cities);
        }
        catch (Exception e)
        {

            throw;
        }
    }
}

public class IntToStringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Se o token for número, converte para string
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number => reader.TryGetInt64(out var l) ? l.ToString() : reader.GetDouble().ToString(),
                JsonTokenType.String => reader.GetString()!,
                _ => throw new JsonException("Unexpected token type for string value."),
            };
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }
        throw new JsonException($"Unexpected token parsing string. Token: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        // Escreve como string
        writer.WriteStringValue(value);
    }
}