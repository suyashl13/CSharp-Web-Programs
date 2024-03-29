namespace ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

public interface IPersonServices
{
    PersonResponse AddPerson(PersonAddRequest personAddRequest);
    
    List<PersonResponse> GetAllPerson();
    
    PersonResponse? GetPersonByPersonId(Guid? personId);
    
    List<PersonResponse> GetFilteredPersons(string? searchBy, string? searchString);

    /// <summary>
    /// Returns Sorted list of perople
    /// </summary>
    /// <param name="allPersonResponse"></param>
    /// <param name="sortBy"></param>
    /// <param name="sortOptions"></param>
    /// <returns></returns>
    List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersonResponse, string sortBy, SortOptions sortOptions);
}