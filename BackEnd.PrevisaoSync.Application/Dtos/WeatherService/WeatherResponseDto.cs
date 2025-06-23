namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class WeatherResponseDto
{
    public CoordDto Coord { get; set; } = null!;
    public List<WeatherDto> Weather { get; set; } = new();
    public string Base { get; set; } = null!;
    public MainDto Main { get; set; } = null!;
    public int Visibility { get; set; }
    public WindDto Wind { get; set; } = null!;
    public CloudsDto Clouds { get; set; } = null!;
    public long Dt { get; set; }
    public SysDto Sys { get; set; } = null!;
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Cod { get; set; }
}
