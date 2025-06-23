namespace BackEnd.PrevisaoSync.Core.Entities;
public class City
{
    public string Id { get; set; } // id fornecido pela OpenWeather
    public string Name { get; set; } = null!;
    public string? State { get; set; }
    public string Country { get; set; } = null!;
    public double Lat { get; set; }
    public double Lon { get; set; }
}
