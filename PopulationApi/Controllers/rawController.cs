using Microsoft.AspNetCore.Mvc;

namespace PopulationApi.Controllers
{
    [ApiController]
    [Route("api/v1/data/raw")]
    public class RawController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RawController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetRawData()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
                var json = await response.Content.ReadAsStringAsync();

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }
    }
}
