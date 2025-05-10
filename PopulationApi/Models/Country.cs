using System.ComponentModel.DataAnnotations;

namespace PopulationApi.Models
{
    public class Country
    {
        [Key]
        public required string CountryName { get; set; }
        public long Population { get; set; }
    }
}
