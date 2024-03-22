namespace CRUDTests;
using ServiceContracts;
using Entities;
using ServiceContracts.DTO;
using Services;

public class CountryServiceTest
{
    private ICountryServices _countryService;

    public CountryServiceTest()
    {
        _countryService = new CountriesService();
    }

    [Fact]
    public void AddCountry_NullCountry()
    {
        CountryAddRequest? request = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => _countryService.AddCountry(request));
    }


    [Fact]
    public void AddCountry_CountryNameIsNull()
    {
        CountryAddRequest? request = new() { CountryName = null };

        // Assert
        Assert.Throws<ArgumentException>(() => _countryService.AddCountry(request));
    }


    [Fact]
    public void AddCountry_CountryNameIsDuplicate()
    {
        CountryAddRequest? request = new() { CountryName = "USA" };
        CountryAddRequest? request2 = new() { CountryName = "USA" };

        // Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _countryService.AddCountry(request);
            _countryService.AddCountry(request2);
        });
    }

    [Fact]
    public void AddCountry_ProperCountryDetails()
    {
        // Arrange
        CountryAddRequest countryAddRequest = new()
        {
            CountryName = "India"
        };

        // Act
        CountryResponse countryResponse = _countryService.AddCountry(countryAddRequest);

        // Assert
        Assert.NotNull(countryResponse);
        Assert.Equal("India", countryResponse.CountryName);
    }

    [Fact]
    public void GetCountryByCountryId_NullCountryId()
    {
        Guid? countryId = null;
        
        // Act
        CountryResponse? countryResponse = _countryService.GetCountryByCountryId(countryId);
        _countryService.GetCountryByCountryId(countryId);

        Assert.Null(countryResponse);
    }


    [Fact]
    public void GetCountryByCountryId_ValidCountryId() 
    {
        CountryAddRequest? countryAddRequest = new CountryAddRequest() { CountryName= "China" };

        // Act
        CountryResponse? countryResponse = _countryService.AddCountry(countryAddRequest);
        _countryService.GetCountryByCountryId(countryResponse!.CountryId);

        // Assert
        Assert.Equal("China", countryResponse.CountryName);
    }

}