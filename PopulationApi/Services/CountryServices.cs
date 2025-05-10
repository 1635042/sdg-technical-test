using PopulationApi.Data;
using PopulationApi.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace PopulationApi.Services
{
    public class CountryService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public CountryService(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<int> FetchAndSaveCountriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<JsonElement>>("https://restcountries.com/v3.1/all");

            if (response is null) return 0;

            int insertCount = 0;

            foreach (var item in response)
            {
                var name = item.GetProperty("name").GetProperty("common").GetString();
                var population = item.GetProperty("population").GetInt64();

                if (string.IsNullOrWhiteSpace(name) || population <= 0)
                    continue;

                if (!_context.Countries.Any(c => c.CountryName == name))
                {
                    _context.Countries.Add(new Country
                    {
                        CountryName = name,
                        Population = population
                    });
                    insertCount++;
                }
            }

            await _context.SaveChangesAsync();
            return insertCount;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

    }
}
