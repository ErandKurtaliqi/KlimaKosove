using System.Globalization;
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
            _climateData = LoadClimateData();
            _extremeEvents = LoadExtremeEvents();
        }

        private static List<City> InitializeCities()
        {
            return new List<City>
            {
                new City { Id = 0, Name = "Podujeva", NameAlbanian = "Komuna e Podujeves", Latitude = 42.9111, Longitude = 21.1925, Population = 88000, Region = "Podujeve" },
                new City { Id = 1, Name = "Shajkoc", NameAlbanian = "Shajkoc", Latitude = 42.9200, Longitude = 21.2500, Population = 1200, Region = "Podujeve" },
                new City { Id = 2, Name = "Podujeve", NameAlbanian = "Podujeve", Latitude = 42.9111, Longitude = 21.1925, Population = 23000, Region = "Podujeve" },
                new City { Id = 3, Name = "Pollate", NameAlbanian = "Pollate", Latitude = 42.9800, Longitude = 21.1900, Population = 1400, Region = "Podujeve" },
                new City { Id = 4, Name = "Kerpimeh", NameAlbanian = "Kerpimeh", Latitude = 42.9600, Longitude = 21.1200, Population = 900, Region = "Podujeve" },
                new City { Id = 5, Name = "Batllave", NameAlbanian = "Batllave", Latitude = 42.8600, Longitude = 21.3100, Population = 1700, Region = "Podujeve" }
            };
        }

        private static List<ClimateData> LoadClimateData()
        {
            const string csv = """
1,1,Shajkoc,2024,1,1.5,14.0,-9.5,0.0,75.8,1.047,0,30,,Winter
2,1,Shajkoc,2024,2,7.1,17.9,-6.8,0.0,66.8,0.034,26,4,,Winter
3,1,Shajkoc,2024,3,8.6,24.0,-1.7,0.0,68.6,5.926,0,30,,Spring
4,1,Shajkoc,2024,4,13.0,26.9,1.4,0.0,60.5,3.733,0,30,,Spring
5,1,Shajkoc,2024,5,14.6,24.8,7.3,0.0,77.9,14.077,0,30,,Spring
6,1,Shajkoc,2024,6,21.8,35.5,9.4,0.0,68.0,10.826,0,30,,Summer
7,1,Shajkoc,2024,7,23.9,36.6,11.3,0.0,57.0,32.108,0,30,,Summer
8,1,Shajkoc,2024,8,23.6,37.5,11.2,0.0,53.3,9.72,0,30,,Summer
9,1,Shajkoc,2024,9,16.9,34.2,4.4,0.0,70.0,3.623,0,30,,Autumn
10,1,Shajkoc,2024,10,12.6,23.3,2.1,0.0,79.0,2.472,0,30,,Autumn
11,1,Shajkoc,2024,11,4.3,18.8,-4.4,0.0,79.6,4.023,0,30,,Autumn
12,1,Shajkoc,2024,12,1.9,12.4,-4.6,0.0,87.3,1.536,0,30,,Winter
13,1,Shajkoc,2025,1,2.3,16.0,-7.4,0.0,82.6,0.688,0,30,,Winter
14,1,Shajkoc,2025,2,0.5,14.1,-12.9,0.0,76.4,0.366,0,30,,Winter
15,1,Shajkoc,2025,3,8.8,25.0,-5.2,0.0,64.8,2.592,0,30,,Spring
16,1,Shajkoc,2025,4,10.4,26.0,-6.5,0.0,70.3,7.504,0,30,,Spring
17,1,Shajkoc,2025,5,13.3,25.6,2.5,0.0,68.2,4.084,0,30,,Spring
18,1,Shajkoc,2025,6,21.9,35.4,8.4,0.0,53.1,1.204,25,5,,Summer
19,1,Shajkoc,2025,7,23.2,39.7,8.5,0.0,52.0,10.754,0,30,,Summer
20,1,Shajkoc,2025,8,21.8,35.3,7.5,0.0,51.5,18.244,0,30,,Summer
21,1,Shajkoc,2025,9,18.2,31.1,5.8,0.0,66.0,6.924,0,30,,Autumn
22,1,Shajkoc,2025,10,9.3,19.2,-0.4,0.0,80.5,2.933,0,30,,Autumn
23,1,Shajkoc,2025,11,7.6,20.7,-1.5,0.0,84.0,3.837,0,30,,Autumn
24,1,Shajkoc,2025,12,2.4,13.3,-8.8,0.0,86.1,0.596,0,30,,Winter
25,1,Shajkoc,2026,1,1.4,11.8,-10.8,0.0,83.5,5.421,0,30,,Winter
26,1,Shajkoc,2026,2,4.2,15.0,-5.7,0.0,82.3,2.343,0,30,,Winter
27,1,Shajkoc,2026,3,6.7,17.6,-0.8,0.0,64.8,2.693,0,30,,Spring
28,1,Shajkoc,2026,4,8.9,21.8,-1.0,0.0,70.4,0.849,0,30,,Spring
29,2,Podujeve,2024,9,16.4,28.2,3.2,32.2,,0.151,27,3,,Autumn
30,2,Podujeve,2024,10,12.6,25.5,-0.1,41.1,,0.084,22,8,,Autumn
31,2,Podujeve,2024,11,4.3,21.4,-7.1,92.4,,0.102,23,7,,Autumn
32,2,Podujeve,2024,12,2.3,15.4,-6.4,65.6,,0.03,18,12,,Winter
33,2,Podujeve,2025,1,2.3,17.4,-8.9,16.1,,0.02,23,7,,Winter
34,2,Podujeve,2025,2,0.8,15.1,-13.6,5.5,,0.014,25,5,,Winter
35,2,Podujeve,2025,3,9.1,27.3,-6.5,60.7,,0.048,17,13,,Spring
36,2,Podujeve,2025,4,11.3,27.9,-6.3,29.7,,0.031,14,16,,Spring
37,2,Podujeve,2025,5,14.2,28.1,0.9,63.1,,0.169,19,11,,Spring
38,2,Podujeve,2025,6,22.0,37.6,5.7,0.0,,,30,0,,Summer
39,2,Podujeve,2025,7,22.9,40.7,6.1,31.0,,0.1,24,6,,Summer
40,2,Podujeve,2025,8,21.1,38.0,-0.2,34.2,,0.302,24,6,,Summer
41,2,Podujeve,2025,9,15.8,32.8,-6.9,43.3,,0.296,20,10,,Autumn
42,2,Podujeve,2025,10,4.7,20.5,-25.0,132.0,,0.067,17,13,,Autumn
43,2,Podujeve,2025,11,5.8,21.7,-13.4,56.3,,0.047,16,14,,Autumn
44,2,Podujeve,2025,12,-0.4,10.8,-12.4,4.5,,0.039,28,2,,Winter
45,2,Podujeve,2026,1,1.7,13.6,-22.4,64.4,,0.043,18,12,,Winter
46,2,Podujeve,2026,2,3.4,16.6,-6.4,45.3,,0.048,15,15,,Winter
47,2,Podujeve,2026,3,6.3,19.6,-7.0,33.2,,0.047,23,7,,Spring
48,2,Podujeve,2026,4,10.5,24.4,-3.7,27.2,,0.044,23,7,,Spring
49,3,Pollate,2024,10,11.2,25.2,0.8,31.1,,0.642,25,5,,Autumn
50,3,Pollate,2024,11,3.0,20.3,-9.5,84.4,,0.128,22,8,,Autumn
51,3,Pollate,2024,12,1.3,11.8,-7.3,54.6,,0.035,19,11,,Winter
52,3,Pollate,2025,1,1.8,15.8,-12.1,12.8,,0.025,23,7,,Winter
53,3,Pollate,2025,2,-1.2,11.4,-17.3,11.7,,0.031,27,3,,Winter
54,3,Pollate,2025,3,7.2,22.6,-5.5,6.6,,0.016,25,5,,Spring
55,3,Pollate,2025,5,12.2,24.5,-0.0,47.4,,0.114,18,12,,Spring
56,3,Pollate,2025,6,20.2,37.1,5.5,0.0,,0.0,30,0,,Summer
57,3,Pollate,2025,7,23.6,37.2,8.0,0.0,,,30,0,,Summer
58,3,Pollate,2025,8,18.9,33.8,5.9,0.6,,0.022,29,1,,Summer
59,3,Pollate,2025,9,16.6,32.9,3.6,27.8,,0.28,21,9,,Autumn
60,3,Pollate,2025,10,8.9,21.8,-1.8,113.1,,0.079,15,15,,Autumn
61,3,Pollate,2025,11,6.7,21.8,-1.9,103.6,,0.049,13,17,,Autumn
62,3,Pollate,2025,12,1.2,13.2,-11.8,22.4,,0.016,24,6,,Winter
63,3,Pollate,2026,1,0.3,13.1,-13.3,90.9,,0.054,15,15,,Winter
64,3,Pollate,2026,2,3.5,14.6,-5.4,57.4,,0.044,14,16,,Winter
65,3,Pollate,2026,3,5.0,18.5,-3.3,38.2,,0.038,22,8,,Spring
66,3,Pollate,2026,4,9.1,23.7,-4.4,29.6,,0.023,24,6,,Spring
67,4,Kerpimeh,2024,10,,,,11.3,,0.069,27,3,,Autumn
68,4,Kerpimeh,2024,11,,,,95.1,,0.095,23,7,,Autumn
69,4,Kerpimeh,2024,12,,,,62.8,,0.029,17,13,,Winter
70,4,Kerpimeh,2025,1,,,,14.9,,0.022,22,8,,Winter
71,4,Kerpimeh,2025,2,,,,8.0,,0.021,25,5,,Winter
72,4,Kerpimeh,2025,3,,,,59.0,,0.069,16,14,,Spring
73,4,Kerpimeh,2025,4,,,,59.0,,0.302,16,14,,Spring
74,4,Kerpimeh,2025,5,,,,43.0,,2.178,17,13,,Spring
75,4,Kerpimeh,2025,6,,,,12.5,,0.454,29,1,,Summer
76,4,Kerpimeh,2025,7,,,,50.4,,0.215,22,8,,Summer
77,4,Kerpimeh,2025,8,,,,28.3,,0.264,24,6,,Summer
78,4,Kerpimeh,2025,9,,,,23.9,,0.189,21,9,,Autumn
79,4,Kerpimeh,2025,10,,,,122.0,,0.057,17,13,,Autumn
80,4,Kerpimeh,2025,11,,,,116.2,,0.047,12,18,,Autumn
81,4,Kerpimeh,2025,12,,,,11.3,,0.014,25,5,,Winter
82,4,Kerpimeh,2026,1,,,,100.8,,0.044,17,13,,Winter
83,4,Kerpimeh,2026,2,,,,48.3,,0.042,13,17,,Winter
84,4,Kerpimeh,2026,3,,,,22.5,,0.05,24,6,,Spring
85,4,Kerpimeh,2026,4,,,,30.7,,0.031,22,8,,Spring
86,5,Batllave,2025,6,,,,3.3,,0.506,29,1,,Summer
87,5,Batllave,2025,7,,,,41.3,,0.211,24,6,,Summer
88,5,Batllave,2025,8,,,,33.9,,0.255,26,4,,Summer
89,5,Batllave,2025,9,,,,41.2,,0.493,20,10,,Autumn
90,5,Batllave,2025,10,,,,122.0,,0.067,13,17,,Autumn
91,5,Batllave,2025,11,,,,140.0,,0.082,10,20,,Autumn
92,5,Batllave,2025,12,,,,22.2,,0.011,17,13,,Winter
93,5,Batllave,2026,1,,,,128.6,,0.044,13,17,,Winter
94,5,Batllave,2026,2,,,,44.6,,0.037,8,22,,Winter
95,5,Batllave,2026,3,,,,37.0,,0.041,23,7,,Spring
96,5,Batllave,2026,4,,,,11.2,,0.059,28,2,,Spring
""";

            return csv
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(ParseClimateRow)
                .ToList();
        }

        private static ClimateData ParseClimateRow(string row)
        {
            var parts = row.Split(',');

            return new ClimateData
            {
                Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                CityId = int.Parse(parts[1], CultureInfo.InvariantCulture),
                CityName = parts[2],
                Year = int.Parse(parts[3], CultureInfo.InvariantCulture),
                Month = int.Parse(parts[4], CultureInfo.InvariantCulture),
                AverageTemperature = ParseNullable(parts[5]),
                MaxTemperature = ParseNullable(parts[6]),
                MinTemperature = ParseNullable(parts[7]),
                Precipitation = ParseRequired(parts[8]),
                Humidity = ParseNullable(parts[9]),
                CO2Level = ParseNullable(parts[10]),
                SunnyDays = int.Parse(parts[11], CultureInfo.InvariantCulture),
                RainyDays = int.Parse(parts[12], CultureInfo.InvariantCulture),
                WindSpeed = ParseNullable(parts[13]),
                Season = parts[14]
            };
        }

        private static double? ParseNullable(string value) =>
            string.IsNullOrWhiteSpace(value) ? null : double.Parse(value, CultureInfo.InvariantCulture);

        private static double ParseRequired(string value) =>
            string.IsNullOrWhiteSpace(value) ? 0 : double.Parse(value, CultureInfo.InvariantCulture);

        private static List<ExtremeWeatherEvent> LoadExtremeEvents()
        {
            return new List<ExtremeWeatherEvent>
            {
                new ExtremeWeatherEvent { Id = 1, CityId = 1, CityName = "Shajkoc", Date = new DateTime(2024, 7, 1), EventType = "Temperatura te larta", Description = "Temperatura maksimale mujore deri ne 36.6 C sipas stacionit Shajkoc.", Severity = "High" },
                new ExtremeWeatherEvent { Id = 2, CityId = 2, CityName = "Podujeve", Date = new DateTime(2025, 10, 1), EventType = "Reshje te dendura", Description = "Muaji me reshje te larta, rreth 132 mm ne total.", Severity = "High" },
                new ExtremeWeatherEvent { Id = 3, CityId = 3, CityName = "Pollate", Date = new DateTime(2025, 10, 1), EventType = "Reshje te dendura", Description = "Totali mujor i reshjeve arriti rreth 113.1 mm.", Severity = "Medium" },
                new ExtremeWeatherEvent { Id = 4, CityId = 4, CityName = "Kerpimeh", Date = new DateTime(2025, 10, 1), EventType = "Reshje te dendura", Description = "Totali mujor i reshjeve arriti rreth 122 mm.", Severity = "High" },
                new ExtremeWeatherEvent { Id = 5, CityId = 5, CityName = "Batllave", Date = new DateTime(2025, 11, 1), EventType = "Reshje te dendura", Description = "Totali mujor i reshjeve arriti rreth 140 mm.", Severity = "High" }
            };
        }

        public List<City> GetAllCities() => _cities;

        public City? GetCityById(int id) => _cities.FirstOrDefault(c => c.Id == id);

        public List<ClimateData> GetClimateData(int? cityId = null, int? year = null, int? month = null)
        {
            var query = FilterByCity(_climateData, cityId);

            if (year.HasValue)
                query = query.Where(c => c.Year == year.Value);
            if (month.HasValue)
                query = query.Where(c => c.Month == month.Value);

            return query.ToList();
        }

        public List<YearlyClimateData> GetYearlyData(int? cityId = null)
        {
            return FilterByCity(_climateData, cityId)
                .GroupBy(c => new { CityId = cityId == 0 ? 0 : c.CityId, CityName = cityId == 0 ? "Podujeve" : c.CityName, c.Year })
                .Select(g => new YearlyClimateData
                {
                    CityId = g.Key.CityId,
                    CityName = g.Key.CityName,
                    Year = g.Key.Year,
                    AverageTemperature = Average(g.Select(x => x.AverageTemperature)),
                    TotalPrecipitation = Math.Round(g.Sum(x => x.Precipitation), 1),
                    AverageHumidity = Average(g.Select(x => x.Humidity)),
                    CO2Level = Average(g.Select(x => x.CO2Level), 3),
                    TotalSunnyDays = g.Sum(x => x.SunnyDays),
                    TotalRainyDays = g.Sum(x => x.RainyDays),
                    AverageWindSpeed = Average(g.Select(x => x.WindSpeed))
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
                    TemperatureChange = data.AverageTemperature.HasValue && previousTemp.HasValue
                        ? Math.Round(data.AverageTemperature.Value - previousTemp.Value, 2)
                        : (double?)null
                });

                if (data.AverageTemperature.HasValue)
                    previousTemp = data.AverageTemperature;
            }

            return trends;
        }

        public List<SeasonalData> GetSeasonalData(int cityId, int? year = null)
        {
            var query = FilterByCity(_climateData, cityId);

            if (year.HasValue)
                query = query.Where(c => c.Year == year.Value);

            return query
                .GroupBy(c => c.Season)
                .Select(g => new SeasonalData
                {
                    Season = g.Key,
                    AverageTemperature = Average(g.Select(x => x.AverageTemperature)),
                    Precipitation = Math.Round(g.Sum(x => x.Precipitation), 1),
                    Humidity = Average(g.Select(x => x.Humidity))
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
                    AverageTemperature = Average(g.Select(x => x.AverageTemperature)),
                    TotalPrecipitation = Math.Round(g.Sum(x => x.Precipitation), 1),
                    CO2Level = Average(g.Select(x => x.CO2Level), 3)
                })
                .OrderByDescending(x => x.AverageTemperature.HasValue)
                .ThenByDescending(x => x.AverageTemperature)
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
            var data = FilterByCity(_climateData, cityId).ToList();

            if (!data.Any())
                return new { };

            var earliestYear = data.Min(c => c.Year);
            var latestYear = data.Max(c => c.Year);
            var earliestData = data.Where(c => c.Year == earliestYear).ToList();
            var latestData = data.Where(c => c.Year == latestYear).ToList();

            var earliestAverage = Average(earliestData.Select(c => c.AverageTemperature));
            var latestAverage = Average(latestData.Select(c => c.AverageTemperature));

            return new
            {
                TotalRecords = data.Count,
                YearsOfData = data.Select(c => c.Year).Distinct().Count(),
                OverallAverageTemperature = Average(data.Select(c => c.AverageTemperature)),
                HighestTemperature = Max(data.Select(c => c.MaxTemperature)),
                LowestTemperature = Min(data.Select(c => c.MinTemperature)),
                AveragePrecipitation = Math.Round(data.Average(c => c.Precipitation), 1),
                CurrentCO2Level = Average(latestData.Select(c => c.CO2Level), 3),
                TemperatureIncrease = earliestAverage.HasValue && latestAverage.HasValue
                    ? Math.Round(latestAverage.Value - earliestAverage.Value, 2)
                    : (double?)null
            };
        }

        private static IEnumerable<ClimateData> FilterByCity(IEnumerable<ClimateData> query, int? cityId)
        {
            return cityId.HasValue && cityId.Value != 0
                ? query.Where(c => c.CityId == cityId.Value)
                : query;
        }

        private static double? Average(IEnumerable<double?> values, int digits = 1)
        {
            var filtered = values.Where(v => v.HasValue).Select(v => v!.Value).ToList();
            return filtered.Any() ? Math.Round(filtered.Average(), digits) : null;
        }

        private static double? Max(IEnumerable<double?> values)
        {
            var filtered = values.Where(v => v.HasValue).Select(v => v!.Value).ToList();
            return filtered.Any() ? filtered.Max() : null;
        }

        private static double? Min(IEnumerable<double?> values)
        {
            var filtered = values.Where(v => v.HasValue).Select(v => v!.Value).ToList();
            return filtered.Any() ? filtered.Min() : null;
        }
    }
}
