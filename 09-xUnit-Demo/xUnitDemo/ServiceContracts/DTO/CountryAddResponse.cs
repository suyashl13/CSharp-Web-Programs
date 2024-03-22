namespace ServiceContracts.DTO;
using Entities;

public class CountryResponse
{
    public Guid CountryId { get; set; }
    public string? CountryName { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        
        CountryResponse countryObj = (CountryResponse) obj!;
        return this.CountryId == countryObj!.CountryId && this.CountryName == countryObj!.CountryName;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Country ToCountry()
    {
        return new Country()
        {
            CountryId = CountryId,
            CountryName = CountryName
        };
     }
}

public static class CountryExtension 
{

    public static Country ToCountry(this CountryAddRequest countryAddRequest) {
        return new Country(){
            CountryId = Guid.NewGuid(),
            CountryName = countryAddRequest.CountryName
        };
    }

    public static CountryResponse ToCountryResponse(this Country country)
    {
        return new CountryResponse
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName
        };
    } 
}