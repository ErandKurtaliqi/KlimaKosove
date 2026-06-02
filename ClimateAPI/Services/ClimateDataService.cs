using ClimateAPI.Models;

namespace ClimateAPI.Services
{
    public class ClimateDataService
    {
        private readonly List<City> _cities;
        private readonly List<ClimateData> _climateData;
        private readonly List<ExtremeWeatherEvent> _extremeEvents;
        public ClimateDataService()
        {
            _cities = InitializeCities();
            _climateData = GenerateClimateData();
            _extremeEvents = GenerateExtremeEvents();
        }



        private List<City> InitializeCities()
        {
            return new List<City>
            {
                new City { Id = 0, Name = "Kosovo", NameAlbanian = "Kosova", Latitude = 42.6026, Longitude = 20.9030, Population = 1873000, Region = "All" },
                new City { Id = 1, Name = "Prishtina", NameAlbanian = "Prishtinë", Latitude = 42.6629, Longitude = 21.1655, Population = 215000, Region = "Central" },
                new City { Id = 2, Name = "Prizren", NameAlbanian = "Prizren", Latitude = 42.2153, Longitude = 20.7415, Population = 178000, Region = "South" },
                new City { Id = 3, Name = "Peja", NameAlbanian = "Pejë", Latitude = 42.6592, Longitude = 20.2889, Population = 97000, Region = "West" },
                new City { Id = 4, Name = "Gjakova", NameAlbanian = "Gjakovë", Latitude = 42.3803, Longitude = 20.4308, Population = 95000, Region = "West" },
                new City { Id = 5, Name = "Ferizaj", NameAlbanian = "Ferizaj", Latitude = 42.3702, Longitude = 21.1553, Population = 108000, Region = "South" },
                new City { Id = 6, Name = "Mitrovica", NameAlbanian = "Mitrovicë", Latitude = 42.8833, Longitude = 20.8667, Population = 72000, Region = "North" },
                new City { Id = 7, Name = "Gjilan", NameAlbanian = "Gjilan", Latitude = 42.4636, Longitude = 21.4694, Population = 90000, Region = "East" },
                new City { Id = 8, Name = "Podujeva", NameAlbanian = "Podujevë", Latitude = 42.9111, Longitude = 21.1925, Population = 88000, Region = "North" },
                new City { Id = 9, Name = "Vushtrri", NameAlbanian = "Vushtrri", Latitude = 42.8231, Longitude = 20.9675, Population = 70000, Region = "North" },
                new City { Id = 10, Name = "Suhareka", NameAlbanian = "Suharekë", Latitude = 42.3592, Longitude = 20.8256, Population = 60000, Region = "South" },
                new City { Id = 11, Name = "Rahovec", NameAlbanian = "Rahovec", Latitude = 42.3997, Longitude = 20.6547, Population = 57000, Region = "West" },
                new City { Id = 12, Name = "Drenas", NameAlbanian = "Drenas", Latitude = 42.6258, Longitude = 20.8889, Population = 58000, Region = "Central" },
                new City { Id = 13, Name = "Lipjan", NameAlbanian = "Lipjan", Latitude = 42.5211, Longitude = 21.1239, Population = 58000, Region = "Central" },
                new City { Id = 14, Name = "Malisheva", NameAlbanian = "Malishevë", Latitude = 42.4833, Longitude = 20.7500, Population = 55000, Region = "West" },
                new City { Id = 15, Name = "Kamenica", NameAlbanian = "Kamenicë", Latitude = 42.5800, Longitude = 21.5800, Population = 36000, Region = "East" },
                new City { Id = 16, Name = "Viti", NameAlbanian = "Viti", Latitude = 42.3219, Longitude = 21.3583, Population = 47000, Region = "East" },
                new City { Id = 17, Name = "Decan", NameAlbanian = "Deçan", Latitude = 42.5397, Longitude = 20.2892, Population = 40000, Region = "West" },
                new City { Id = 18, Name = "Istog", NameAlbanian = "Istog", Latitude = 42.7833, Longitude = 20.4833, Population = 40000, Region = "West" },
                new City { Id = 19, Name = "Kline", NameAlbanian = "Klinë", Latitude = 42.6217, Longitude = 20.5778, Population = 38000, Region = "West" },
                new City { Id = 20, Name = "Skenderaj", NameAlbanian = "Skënderaj", Latitude = 42.7467, Longitude = 20.7886, Population = 51000, Region = "Central" },
                new City { Id = 21, Name = "Dragash", NameAlbanian = "Dragash", Latitude = 42.0606, Longitude = 20.6528, Population = 34000, Region = "South" },
                new City { Id = 22, Name = "Fushe Kosove", NameAlbanian = "Fushë Kosovë", Latitude = 42.6347, Longitude = 21.0972, Population = 35000, Region = "Central" },
                new City { Id = 23, Name = "Kacanik", NameAlbanian = "Kaçanik", Latitude = 42.2319, Longitude = 21.2589, Population = 33000, Region = "South" },
                new City { Id = 24, Name = "Shtime", NameAlbanian = "Shtime", Latitude = 42.4333, Longitude = 21.0333, Population = 28000, Region = "Central" },
                new City { Id = 25, Name = "Obiliq", NameAlbanian = "Obiliq", Latitude = 42.6869, Longitude = 21.0697, Population = 22000, Region = "Central" }
            };
        }

        private List<ClimateData> GenerateClimateData()
        {
            var data = new List<ClimateData>();
            var random = new Random(42); // Fixed seed for consistency
            int id = 1;

            // Base temperatures for Kosovo (continental climate)
            var monthlyBaseTemps = new double[] { -1, 1, 6, 11, 16, 20, 22, 22, 17, 11, 5, 0 };
            var monthlyPrecipitation = new double[] { 40, 35, 45, 55, 70, 60, 45, 40, 50, 60, 70, 55 };
            var seasons = new string[] { "Winter", "Winter", "Spring", "Spring", "Spring", "Summer", "Summer", "Summer", "Autumn", "Autumn", "Autumn", "Winter" };

            foreach (var city in _cities)
            {
                // Altitude and location adjustments
                double altitudeAdjustment = city.Region switch
                {
                    "North" => -1.5,
                    "South" => 1.0,
                    "West" => -0.5,
                    "East" => 0.0,
                    _ => 0.0
                };

                for (int year = 2000; year <= 2025; year++)
                {
                    // Climate change warming trend: approximately 0.03°C per year
                    double warmingTrend = (year - 2000) * 0.035;
                    
                    // CO2 increase trend
                    double baseCO2 = 370 + (year - 2000) * 2.5;

                    for (int month = 1; month <= 12; month++)
                    {
                        double baseTemp = monthlyBaseTemps[month - 1] + altitudeAdjustment + warmingTrend;
                        double tempVariation = (random.NextDouble() - 0.5) * 3;

                        var climateEntry = new ClimateData
                        {
                            Id = id++,
                            CityId = city.Id,
                            CityName = city.Name,
                            Year = year,
                            Month = month,
                            AverageTemperature = Math.Round(baseTemp + tempVariation, 1),
                            MaxTemperature = Math.Round(baseTemp + 8 + random.NextDouble() * 4, 1),
                            MinTemperature = Math.Round(baseTemp - 6 - random.NextDouble() * 3, 1),
                            Precipitation = Math.Round(monthlyPrecipitation[month - 1] * (0.7 + random.NextDouble() * 0.6), 1),
                            Humidity = Math.Round(55 + random.NextDouble() * 30, 1),
                            CO2Level = Math.Round(baseCO2 + random.NextDouble() * 10, 1),
                            SunnyDays = random.Next(8, 22),
                            RainyDays = random.Next(3, 12),
                            WindSpeed = Math.Round(8 + random.NextDouble() * 15, 1),
                            Season = seasons[month - 1]
                        };

                        data.Add(climateEntry);
                    }
                }
            }

            return data;
        }

        private List<ExtremeWeatherEvent> GenerateExtremeEvents()
        {
            var events = new List<ExtremeWeatherEvent>
            {
                new ExtremeWeatherEvent { Id = 1, CityId = 1, CityName = "Prishtina", Date = new DateTime(2021, 7, 15), EventType = "Heatwave", Description = "Valë e nxehtësisë me temperatura deri në 40°C", Severity = "High" },
                new ExtremeWeatherEvent { Id = 2, CityId = 2, CityName = "Prizren", Date = new DateTime(2020, 8, 20), EventType = "Drought", Description = "Thatësirë e zgjatur për 45 ditë", Severity = "Medium" },
                new ExtremeWeatherEvent { Id = 3, CityId = 3, CityName = "Peja", Date = new DateTime(2019, 11, 5), EventType = "Flood", Description = "Përmbytje nga lumi Drini i Bardhë", Severity = "High" },
                new ExtremeWeatherEvent { Id = 4, CityId = 6, CityName = "Mitrovica", Date = new DateTime(2022, 1, 10), EventType = "Snowstorm", Description = "Stuhi bore me 80cm borë", Severity = "High" },
                new ExtremeWeatherEvent { Id = 5, CityId = 5, CityName = "Ferizaj", Date = new DateTime(2023, 6, 25), EventType = "Heatwave", Description = "Temperatura rekord 42°C", Severity = "Critical" },
                new ExtremeWeatherEvent { Id = 6, CityId = 4, CityName = "Gjakova", Date = new DateTime(2018, 9, 12), EventType = "Storm", Description = "Stuhi me erëra deri 100 km/h", Severity = "Medium" },
                new ExtremeWeatherEvent { Id = 7, CityId = 7, CityName = "Gjilan", Date = new DateTime(2024, 3, 8), EventType = "Flood", Description = "Përmbytje nga reshjet e dendura", Severity = "Medium" },
                new ExtremeWeatherEvent { Id = 8, CityId = 1, CityName = "Prishtina", Date = new DateTime(2025, 7, 1), EventType = "Heatwave", Description = "Valë e nxehtësisë verore", Severity = "High" },
                new ExtremeWeatherEvent { Id = 9, CityId = 21, CityName = "Dragash", Date = new DateTime(2022, 12, 20), EventType = "Snowstorm", Description = "Borë e madhe në zona malore", Severity = "High" },
                new ExtremeWeatherEvent { Id = 10, CityId = 2, CityName = "Prizren", Date = new DateTime(2024, 8, 5), EventType = "Heatwave", Description = "Ditë të nxehta ekstreme", Severity = "High" }
            };

            return events;
        }

        public List<City> GetAllCities() => _cities;

        public City? GetCityById(int id) => _cities.FirstOrDefault(c => c.Id == id);

        public List<ClimateData> GetClimateData(int? cityId = null, int? year = null, int? month = null)
        {
            var query = _climateData.AsQueryable();

            if (cityId.HasValue)
                query = query.Where(c => c.CityId == cityId.Value);
            if (year.HasValue)
                query = query.Where(c => c.Year == year.Value);
            if (month.HasValue)
                query = query.Where(c => c.Month == month.Value);

            return query.ToList();
        }

        public List<YearlyClimateData> GetYearlyData(int? cityId = null)
        {
            var query = _climateData.AsQueryable();

            if (cityId.HasValue)
                query = query.Where(c => c.CityId == cityId.Value);

            return query
                .GroupBy(c => new { c.CityId, c.CityName, c.Year })
                .Select(g => new YearlyClimateData
                {
                    CityId = g.Key.CityId,
                    CityName = g.Key.CityName,
                    Year = g.Key.Year,
                    AverageTemperature = Math.Round(g.Average(x => x.AverageTemperature), 1),
                    TotalPrecipitation = Math.Round(g.Sum(x => x.Precipitation), 1),
                    AverageHumidity = Math.Round(g.Average(x => x.Humidity), 1),
                    CO2Level = Math.Round(g.Average(x => x.CO2Level), 1),
                    TotalSunnyDays = g.Sum(x => x.SunnyDays),
                    TotalRainyDays = g.Sum(x => x.RainyDays),
                    AverageWindSpeed = Math.Round(g.Average(x => x.WindSpeed), 1)
                })
                .OrderBy(x => x.Year)
                .ToList();
        }

        public List<TemperatureTrend> GetTemperatureTrend(int cityId)
        {
            var yearlyData = GetYearlyData(cityId);
            var trends = new List<TemperatureTrend>();
            
            double? previousTemp = null;
            foreach (var data in yearlyData)
            {
                trends.Add(new TemperatureTrend
                {
                    Year = data.Year,
                    Temperature = data.AverageTemperature,
                    TemperatureChange = previousTemp.HasValue 
                        ? Math.Round(data.AverageTemperature - previousTemp.Value, 2) 
                        : 0
                });
                previousTemp = data.AverageTemperature;
            }

            return trends;
        }

        public List<SeasonalData> GetSeasonalData(int cityId, int? year = null)
        {
            var query = _climateData.Where(c => c.CityId == cityId);
            
            if (year.HasValue)
                query = query.Where(c => c.Year == year.Value);

            return query
                .GroupBy(c => c.Season)
                .Select(g => new SeasonalData
                {
                    Season = g.Key,
                    AverageTemperature = Math.Round(g.Average(x => x.AverageTemperature), 1),
                    Precipitation = Math.Round(g.Average(x => x.Precipitation), 1),
                    Humidity = Math.Round(g.Average(x => x.Humidity), 1)
                })
                .ToList();
        }

        public List<ClimateComparison> GetCityComparison(int year)
        {
            return _climateData
                .Where(c => c.Year == year && c.CityId != 0)
                .GroupBy(c => c.CityName)
                .Select(g => new ClimateComparison
                {
                    CityName = g.Key,
                    AverageTemperature = Math.Round(g.Average(x => x.AverageTemperature), 1),
                    TotalPrecipitation = Math.Round(g.Sum(x => x.Precipitation), 1),
                    CO2Level = Math.Round(g.Average(x => x.CO2Level), 1)
                })
                .OrderByDescending(x => x.AverageTemperature)
                .ToList();
        }

        public List<ExtremeWeatherEvent> GetExtremeEvents(int? cityId = null)
        {
            if (cityId.HasValue && cityId.Value != 0)
                return _extremeEvents.Where(e => e.CityId == cityId.Value).ToList();
            
            return _extremeEvents;
        }

        public object GetClimateStatistics(int cityId)
        {
            var data = _climateData.Where(c => c.CityId == cityId).ToList();
            
            if (!data.Any())
                return new { };

            var recentData = data.Where(c => c.Year >= 2020).ToList();
            var historicalData = data.Where(c => c.Year < 2010).ToList();

            return new
            {
                TotalRecords = data.Count,
                YearsOfData = data.Select(c => c.Year).Distinct().Count(),
                OverallAverageTemperature = Math.Round(data.Average(c => c.AverageTemperature), 1),
                HighestTemperature = data.Max(c => c.MaxTemperature),
                LowestTemperature = data.Min(c => c.MinTemperature),
                AveragePrecipitation = Math.Round(data.Average(c => c.Precipitation), 1),
                CurrentCO2Level = Math.Round(data.Where(c => c.Year == 2025).Average(c => c.CO2Level), 1),
                TemperatureIncrease = historicalData.Any() && recentData.Any() 
                    ? Math.Round(recentData.Average(c => c.AverageTemperature) - historicalData.Average(c => c.AverageTemperature), 2)
                    : 0
            };
        }
    }
}

