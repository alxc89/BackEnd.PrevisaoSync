namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class MainDto
{
    public double Temp { get; set; }
    public double Feels_Like { get; set; }
    public double Temp_Min { get; set; }
    public double Temp_Max { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public int Sea_Level { get; set; }
    public int Grnd_Level { get; set; }
    public decimal Temp_kf { get; set; }
}
