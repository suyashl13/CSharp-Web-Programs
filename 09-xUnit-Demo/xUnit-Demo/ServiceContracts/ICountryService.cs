using Entities;
using ServiceContracts.DTO;

namespace ServiceContracts;


// <summary>Countains Country Service Contract logic</summary>
public interface ICountryService
{
    public CountryAddResponse AddCountry(CountryAddRequest? countryAddRequest);
    
    
}