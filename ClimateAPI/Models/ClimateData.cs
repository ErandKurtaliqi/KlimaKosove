namespace ClimateAPI.Models
{
    public class ClimateData
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public double? AverageTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MinTemperature { get; set; }
        public double Precipitation { get; set; } // mm
        public double? Humidity { get; set; } // %
        public double? CO2Level { get; set; } // rainfall intensity
        public int SunnyDays { get; set; }
        public int RainyDays { get; set; }
        public double? WindSpeed { get; set; } // km/h
        public string Season { get; set; } = string.Empty;
    }

    public class YearlyClimateData
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public int Year { get; set; }
        public double? AverageTemperature { get; set; }
        public double TotalPrecipitation { get; set; }
        public double? AverageHumidity { get; set; }
        public double? CO2Level { get; set; }
        public int TotalSunnyDays { get; set; }
        public int TotalRainyDays { get; set; }
        public double? AverageWindSpeed { get; set; }
    }

    public class TemperatureTrend
    {
        public int Year { get; set; }
        public double? Temperature { get; set; }
        public double? TemperatureChange { get; set; }
    }

    public class SeasonalData
    {
        public string Season { get; set; } = string.Empty;
        public double? AverageTemperature { get; set; }
        public double Precipitation { get; set; }
        public double? Humidity { get; set; }
    }

    public class ClimateComparison
    {
        public string CityName { get; set; } = string.Empty;
        public double? AverageTemperature { get; set; }
        public double TotalPrecipitation { get; set; }
        public double? CO2Level { get; set; }
    }

    public class ExtremeWeatherEvent
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
    }
}

