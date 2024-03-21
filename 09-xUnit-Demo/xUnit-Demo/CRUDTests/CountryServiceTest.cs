using ServiceContracts;
using ServiceContracts.DTO;
using Services;
namespace CRUDTests;

public class CountryServiceTest
{
    private readonly ICountryService _countryService;

    public CountryServiceTest()
    {
        _countryService = new CountryService();
    }

    [Fact]
    public void AddCountry_NullCountry()
    {
        // Arrange
        CountryAddRequest? countryAddRequest = null;
        // Assert 
        Assert.Throws<ArgumentNullException>(
           // Act
           () => _countryService.AddCountry(countryAddRequest)
       );
    }

    [Fact]
    public void AddCountry_NullCountryIsNull()
    {
        // Arrange
        CountryAddRequest? countryAddRequest = new()
        {
            CountryName = null
        };
        // Assert 
        Assert.Throws<ArgumentNullException>(
           // Act
           () => _countryService.AddCountry(countryAddRequest)
       );
    }

    [Fact]
    public void AddCountry_DuplicateCountryName()
    {
        // Arrange
        CountryAddRequest? countryAddRequest = new()
        {
            CountryName = "India"
        };
        CountryAddRequest? countryAddRequest2 = new()
        {
            CountryName = "India"
        };
        // Assert 
        Assert.Throws<ArgumentNullException>(
           // Act
           () =>
           {
               _countryService.AddCountry(countryAddRequest);
               _countryService.AddCountry(countryAddRequest2);
           }
       );
    }

    [Fact]
    public void AddCountry_NotNullGuid()
    {
        // Arrange
        CountryAddRequest? countryAddRequest = new()
        {
            CountryName = "India"
        };
        
        CountryAddResponse response = _countryService.AddCountry(countryAddRequest);

        Assert.True(response.CountryId != Guid.Empty);
    }

    

}
