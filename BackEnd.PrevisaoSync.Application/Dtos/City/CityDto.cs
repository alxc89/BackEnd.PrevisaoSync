namespace BackEnd.PrevisaoSync.Application.Dtos.City;
public class CityDto
{
    public CityDto()
    {

    }

    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public string? State { get; set; }
    public string Country { get; set; } = null!;
    public Coord Coord { get; set; } = null!;
}