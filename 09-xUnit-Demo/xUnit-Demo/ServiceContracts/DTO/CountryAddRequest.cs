using Entities;

namespace ServiceContracts.DTO
{

    // <summary> Country Request DTO </summary>
    public class CountryAddRequest
    {
        public string? CountryName { get; set; }

        public  Country ToCountry()
        {
            return new Country
            {
                CountryName = CountryName
            };
        }
    }
}