using Entities;

namespace ServiceContracts.DTO
{
    public class CountryAddResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }

    public static class CountryExtensions
    {
        public static CountryAddResponse ToCountryAddResponse(this Country country)
        {
            return new CountryAddResponse
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
} 