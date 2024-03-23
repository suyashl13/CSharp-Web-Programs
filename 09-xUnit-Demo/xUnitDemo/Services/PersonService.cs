namespace Services;

using System.Collections.Generic;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Helper;

public class PersonService : IPersonServices
{

    private readonly List<Person> _peopleList;
    private readonly ICountryServices _countryServices;

    public PersonService()
    {
        _peopleList = [];
        _countryServices = new CountriesService();
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        // Check Person request is not null
        ArgumentNullException.ThrowIfNull(personAddRequest);

        // Validations
        ValidationHelper.ModelValidation(personAddRequest);

        Person person = personAddRequest.ToPerson();
        person.PersonID = Guid.NewGuid();
        _peopleList.Add(person);
        return ConvertPersonToPersonResponse(person);
    }

    public List<PersonResponse> GetAllPerson() => _peopleList.Select((p) => ConvertPersonToPersonResponse(p)).ToList();

    public List<PersonResponse> GetFilteredPersons(string? searchBy, string? searchString)
    {
        List<PersonResponse> allPeople = this.GetAllPerson();

        if (String.IsNullOrEmpty(searchString)) return allPeople;

        return searchBy switch
        {
            "PersonName" => allPeople
                                .Where((p) => p.PersonName!
                                .Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                                .ToList(),
            "Email" => allPeople
                                .Where((p) => p.Email!
                                .Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                                .ToList(),
            "Address" => allPeople
                                .Where((p) => p.Address!
                                .Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                                .ToList(),
            _ => [],
        };
    }

    public PersonResponse? GetPersonByPersonId(Guid? personId)
    {
        if (personId == null) return null;
        return _peopleList.FirstOrDefault((person) => person.PersonID == personId)?.ToPersonResponse();
    }

    private PersonResponse ConvertPersonToPersonResponse(Person person)
    {
        PersonResponse personResponse = person.ToPersonResponse();
        personResponse.Country = _countryServices.GetCountryByCountryId(person.CountryID)?.CountryName;
        return personResponse;
    }

}