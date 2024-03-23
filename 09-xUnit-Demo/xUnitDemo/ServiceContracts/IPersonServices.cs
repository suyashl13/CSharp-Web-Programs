namespace ServiceContracts;
using ServiceContracts.DTO;


public interface IPersonServices
{
    PersonResponse AddPerson(PersonAddRequest personAddRequest);
    
    List<PersonResponse> GetAllPerson();
    
    PersonResponse? GetPersonByPersonId(Guid? personId);
    
    List<PersonResponse> GetFilteredPersons(string? searchBy, string? searchString);
}