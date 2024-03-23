using Services;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Xunit.Abstractions;

public class PersonServiceTests
{

    private readonly IPersonServices _personService;
    private readonly ICountryServices _countryServices;
    private readonly ITestOutputHelper testOutputHelper;

    public PersonServiceTests(ITestOutputHelper testOutputHelper)
    {
        _personService = new PersonService();
        _countryServices = new CountriesService();
        this.testOutputHelper = testOutputHelper;
    }

    #region AddPerson
    [Fact]
    public void AddPerson_NullPerson()
    {
        // Arrange
        PersonAddRequest? _personAddRequest = null;

        // Act
        Assert.Throws<ArgumentNullException>(() =>
        {
            // Assert
            _personService.AddPerson(_personAddRequest!);
        });

    }

    [Fact]
    public void AddPerson_PersonNameIsNull()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new() { PersonName = null };

        //Act
        Assert.Throws<ArgumentException>(() =>
        {
            _personService.AddPerson(personAddRequest);
        });
    }

    //When we supply proper person details, it should insert the person into the persons list; and it should return an object of PersonResponse, which includes with the newly generated person id
    [Fact]
    public void AddPerson_ProperPersonDetails()
    {
        //Arrange
        PersonAddRequest? personAddRequest = new() { PersonName = "Person name...", Email = "person@example.com", Address = "sample address value lorem ipsum dolor sit amet consectetur adipisicing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua ut enim ad minim veniam quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat ", CountryID = Guid.NewGuid(), Gender = GenderOptions.Male, DateOfBirth = DateTime.Parse("2000-01-01"), ReceiveNewsLetters = true };

        //Act
        PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);

        List<PersonResponse> persons_list = _personService.GetAllPerson();

        //Assert
        Assert.True(person_response_from_add.PersonID != Guid.Empty);

        Assert.Contains(person_response_from_add, persons_list);
    }
    #endregion

    #region GetPersonByPersonID
    [Fact]
    public void GetPersonByPersonID_NullPersonID()
    {
        Guid? guid = null;

        // Act
        Assert.Null(_personService.GetPersonByPersonId(guid));
    }

    [Fact]
    public void GetPersonByPersonID_WithValidPersonID()
    {
        CountryAddRequest countryAddRequest = new()
        {
            CountryName = "India"
        };
        Guid CountryId = _countryServices.AddCountry(countryAddRequest).CountryId;

        PersonAddRequest personAddRequest = new()
        {
            PersonName = "Suyash Lawand",
            Email = "suyashlawand@in.com",
            DateOfBirth = Convert.ToDateTime("2000-01-01"),
            Gender = GenderOptions.Male,
            CountryID = CountryId,
            Address = "sample address value lorem /Practice-Workspace/CSharp-Web-Programs/09-xUnit-Demo/xUnitDemo/ServiceContracts/bin/Debug/net8.0/ServiceContracts.dll Services -> /Users/suyashlawand/Practice-Workspace/CSharp-Web-Programs/09-xUnit-Demo/xUnitDemo/Services/bin/Debug/net8.0/Services.dll CRUDTests -> /Users/suyashlawand/Practice-Workspace/CSharp-Web-Programs/09-xUnit-Demo/xUnitDemo/CRUDTests/bin/Debug/net8.0/CRUDTests.dll *  Terminal will be reused by tasks, pres ",
            ReceiveNewsLetters = true
        };

        PersonResponse? personResponseFromAdd = _personService.AddPerson(personAddRequest);
        PersonResponse? personResponseFromGet = _personService.GetPersonByPersonId(personResponseFromAdd.PersonID)!;

        Assert.Equal(personResponseFromAdd, personResponseFromGet);
    }
    #endregion

    #region GetAllPersons
    [Fact]
    public void GetAllPersons_EmptyList()
    {
        // Act
        List<PersonResponse> persons = _personService.GetAllPerson();
        Assert.Empty(persons);

        Assert.Empty(persons);
    }

    [Fact]
    public void GetAllPersons_NonEmptyList()
    {
        // Act
        CountryAddRequest countryAddRequest = new()
        {
            CountryName = "India"
        }, countryAddRequest2 = new()
        {
            CountryName = "USA"
        }, countryAddRequest3 = new()
        {
            CountryName = "UK"
        };

        CountryResponse countryResponse1 = _countryServices.AddCountry(countryAddRequest);
        CountryResponse countryResponse2 = _countryServices.AddCountry(countryAddRequest2);
        CountryResponse countryResponse3 = _countryServices.AddCountry(countryAddRequest3);

        List<PersonAddRequest> personAddRequests = [
        new() {
            PersonName = "Suyash",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse1.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-01-01"),
            Email = "suyashlawand@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        },  new()
        {
            PersonName = "Mahendra Singh",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse2.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-06-06"),
            Email = "suyashl@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }, new()
        {
            PersonName = "Muhameed shami",
            Address = "Katraj, Rune, India",
            CountryID = countryResponse3.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-07-06"),
            Email = "suyashld@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }
        ];


        List<PersonResponse> personsFromAddOperation = personAddRequests.Select((personFromReq) => _personService.AddPerson(personFromReq)).ToList();
        List<PersonResponse> personsFromResponse = _personService.GetAllPerson();

        Assert.NotEmpty(personsFromResponse);

        foreach (var person in personsFromAddOperation)
        {
            testOutputHelper.WriteLine($"{person.PersonID.ToString()} {person.PersonName}");
            Assert.Contains(person, personsFromResponse);
        }
    }
    #endregion

    #region GetFilteredPersons
    [Fact]
    public void GetFilteredPersons_EmptySearchString()
    {
        // Act
        CountryAddRequest countryAddRequest = new()
        {
            CountryName = "India"
        }, countryAddRequest2 = new()
        {
            CountryName = "USA"
        }, countryAddRequest3 = new()
        {
            CountryName = "UK"
        };

        CountryResponse countryResponse1 = _countryServices.AddCountry(countryAddRequest);
        CountryResponse countryResponse2 = _countryServices.AddCountry(countryAddRequest2);
        CountryResponse countryResponse3 = _countryServices.AddCountry(countryAddRequest3);

        List<PersonAddRequest> personAddRequests = [
        new() {
            PersonName = "Suyash",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse1.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-01-01"),
            Email = "suyashlawand@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        },  new()
        {
            PersonName = "Mahendra Singh",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse2.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-06-06"),
            Email = "suyashl@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }, new()
        {
            PersonName = "Muhameed shami",
            Address = "Katraj, Rune, India",
            CountryID = countryResponse3.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-07-06"),
            Email = "suyashld@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }
        ];


        List<PersonResponse> personsFromAddOperation = personAddRequests.Select((personFromReq) => _personService.AddPerson(personFromReq)).ToList();
        List<PersonResponse> personsFromSearchResponse = _personService.GetFilteredPersons(nameof(PersonResponse.PersonName), "");

        Assert.NotEmpty(personsFromSearchResponse);

        foreach (var person in personsFromAddOperation)
        {
            testOutputHelper.WriteLine($"{person.PersonID.ToString()} {person.PersonName}");
            Assert.Contains(person, personsFromSearchResponse);
        }
    }

    [Fact]
    public void GetFilteredPersons_ValidSearchString()
    {
        // Act
        CountryAddRequest countryAddRequest = new()
        {
            CountryName = "India"
        }, countryAddRequest2 = new()
        {
            CountryName = "USA"
        }, countryAddRequest3 = new()
        {
            CountryName = "UK"
        };

        CountryResponse countryResponse1 = _countryServices.AddCountry(countryAddRequest);
        CountryResponse countryResponse2 = _countryServices.AddCountry(countryAddRequest2);
        CountryResponse countryResponse3 = _countryServices.AddCountry(countryAddRequest3);

        List<PersonAddRequest> personAddRequests = [
        new() {
            PersonName = "Suyash",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse1.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-01-01"),
            Email = "suyashlawand@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        },  new()
        {
            PersonName = "Mahendra Singh",
            Address = "Katraj, Pune, India",
            CountryID = countryResponse2.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-06-06"),
            Email = "suyashl@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }, new()
        {
            PersonName = "Muhameed shami",
            Address = "Katraj, Rune, India",
            CountryID = countryResponse3.CountryId,
            DateOfBirth = Convert.ToDateTime("2000-07-06"),
            Email = "suyashld@in.com",
            Gender = GenderOptions.Male,
            ReceiveNewsLetters = true
        }
        ];


        List<PersonResponse> personsFromAddOperation = personAddRequests.Select((personFromReq) => _personService.AddPerson(personFromReq)).ToList();
        List<PersonResponse> personsFromSearchResponse = _personService.GetFilteredPersons(nameof(PersonResponse.PersonName), "M");

        Assert.NotEmpty(personsFromSearchResponse);

        foreach (var person in personsFromAddOperation) 
        {
            testOutputHelper.WriteLine($"{person.PersonID.ToString()} {person.PersonName}");
            Assert.True(personsFromSearchResponse.TrueForAll((person) => person.PersonName!.Contains('M')));
        }
    }

    #endregion
}