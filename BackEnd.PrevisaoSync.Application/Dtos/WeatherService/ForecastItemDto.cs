namespace BackEnd.PrevisaoSync.Application.Dtos.WeatherService;
public class ForecastItemDto
{
    public long Dt { get; set; }
    public MainDto Main { get; set; } = null!;
    public List<WeatherDto> Weather { get; set; } = new();
    public CloudsDto Clouds { get; set; } = null!;
    public WindDto Wind { get; set; } = null!;
    public int Visibility { get; set; }
    public int Pop { get; set; } // Probabilidade de precipitação
    public SysDto Sys { get; set; } = null!;
    private string _dtTxt = string.Empty;

    public string Dt_Txt
    {
        get
        {
            if (DateTime.TryParse(_dtTxt, out var data))
            {
                return data.ToString("yyyy-MM-dd");
            }
            return _dtTxt;
        }
        set
        {
            _dtTxt = value;
        }
    }
}