namespace Hotel.Api
{
    public partial class WeatherForecast
    {
        public DateOnly Dates { get; set; }

        public int TemperatureCs { get; set; }

        public int TemperatureFs => 32 + (int)(TemperatureC / 0.5556);

        public string? Summarys { get; set; }
    }
}
