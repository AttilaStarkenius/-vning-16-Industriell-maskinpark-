namespace Övning_16___Industriell_maskinpark__.Shared
{
    public class WeatherForecast
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool currentStatus { get; set; }

        public string latestDataSentFromMachine { get; set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}