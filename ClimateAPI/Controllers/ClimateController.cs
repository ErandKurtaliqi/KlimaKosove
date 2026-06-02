using Microsoft.AspNetCore.Mvc;
using ClimateAPI.Models;
using ClimateAPI.Services;

namespace ClimateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimateController : ControllerBase
    {
        private readonly ClimateDataService _dataService;

        public ClimateController(ClimateDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Merr listën e të gjitha qyteteve të Kosovës
        /// </summary>
        [HttpGet("cities")]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return Ok(_dataService.GetAllCities());
        }

        /// <summary>
        /// Merr një qytet sipas ID-së
        /// </summary>
        [HttpGet("cities/{id}")]
        public ActionResult<City> GetCity(int id)
        {
            var city = _dataService.GetCityById(id);
            if (city == null)
                return NotFound(new { message = "Qyteti nuk u gjet" });
            
            return Ok(city);
        }

        /// <summary>
        /// Merr të dhënat klimatike me filtra opsionalë
        /// </summary>
        [HttpGet("data")]
        public ActionResult<IEnumerable<ClimateData>> GetClimateData(
            [FromQuery] int? cityId,
            [FromQuery] int? year,
            [FromQuery] int? month)
        {
            var data = _dataService.GetClimateData(cityId, year, month);
            return Ok(data);
        }

        /// <summary>
        /// Merr të dhënat klimatike vjetore
        /// </summary>
        [HttpGet("yearly")]
        public ActionResult<IEnumerable<YearlyClimateData>> GetYearlyData([FromQuery] int? cityId)
        {
            var data = _dataService.GetYearlyData(cityId);
            return Ok(data);
        }

        /// <summary>
        /// Merr trendin e temperaturës për një qytet
        /// </summary>
        [HttpGet("temperature-trend/{cityId}")]
        public ActionResult<IEnumerable<TemperatureTrend>> GetTemperatureTrend(int cityId)
        {
            var trend = _dataService.GetTemperatureTrend(cityId);
            return Ok(trend);
        }

        /// <summary>
        /// Merr të dhënat sezonale për një qytet
        /// </summary>
        [HttpGet("seasonal/{cityId}")]
        public ActionResult<IEnumerable<SeasonalData>> GetSeasonalData(int cityId, [FromQuery] int? year)
        {
            var data = _dataService.GetSeasonalData(cityId, year);
            return Ok(data);
        }

        /// <summary>
        /// Merr krahasimin e qyteteve për një vit të caktuar
        /// </summary>
        [HttpGet("comparison/{year}")]
        public ActionResult<IEnumerable<ClimateComparison>> GetCityComparison(int year)
        {
            var comparison = _dataService.GetCityComparison(year);
            return Ok(comparison);
        }

        /// <summary>
        /// Merr ngjarjet ekstreme të motit
        /// </summary>
        [HttpGet("extreme-events")]
        public ActionResult<IEnumerable<ExtremeWeatherEvent>> GetExtremeEvents([FromQuery] int? cityId)
        {
            var events = _dataService.GetExtremeEvents(cityId);
            return Ok(events);
        }

        /// <summary>
        /// Merr statistikat klimatike për një qytet
        /// </summary>
        [HttpGet("statistics/{cityId}")]
        public ActionResult<object> GetClimateStatistics(int cityId)
        {
            var stats = _dataService.GetClimateStatistics(cityId);
            return Ok(stats);
        }
    }
}

