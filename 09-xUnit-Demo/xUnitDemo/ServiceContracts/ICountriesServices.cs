using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts;

public interface ICountryServices
{
    CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    List<CountryResponse> GetAllCountries();

    CountryResponse? GetCountryByCountryId(Guid? countryId);
}