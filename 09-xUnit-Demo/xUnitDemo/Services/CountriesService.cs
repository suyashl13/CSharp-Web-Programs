using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;
 
public class CountriesService : ICountryServices
{
    private readonly List<Country> _countriesList;

    public CountriesService()
    {
        _countriesList = [];
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        ArgumentNullException.ThrowIfNull(countryAddRequest);
        Country country = countryAddRequest.ToCountry();

        if (_countriesList.Exists(country => country.CountryName == countryAddRequest.CountryName))
        {
            throw new ArgumentException("Country already exists");
        }

        _countriesList.Add(country);
        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries() => _countriesList.Select(country => country.ToCountryResponse()).ToList();

    public CountryResponse? GetCountryByCountryId(Guid? countryId)
    {
        return _countriesList
            .Where(country => country.CountryId == countryId)
            .Select(country => country.ToCountryResponse())
            .FirstOrDefault();
    }
}
