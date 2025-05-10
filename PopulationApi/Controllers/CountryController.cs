using Microsoft.AspNetCore.Mvc;
using PopulationApi.Models;
using PopulationApi.Services;

namespace PopulationApi.Controllers
{
    [ApiController]
    [Route("api/v1/data/country")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        // POST: api/v1/data/country
        [HttpPost]
        public async Task<IActionResult> FetchAndSaveCountries()
        {
            try
            {
                int inserted = await _countryService.FetchAndSaveCountriesAsync();

                return Ok(new
                {
                    message = "Data saved successfully.",
                    countriesInserted = inserted
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "An error occurred while saving data.",
                    details = ex.Message
                });
            }
        }

        // GET: api/v1/data/country
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return Ok(_countryService.GetAllCountries());
        }
    }
}
