using crud_mysql.Request;

namespace crud_mysql.Service;

public interface IPersonService
{
    Task<List<Person>> GetPersons();
    Task<Person> GetPersonById(Guid id);
    Task<Person> AddPerson(PersonRequest person);
    Task<Person> UpdatePerson(Guid id, PersonRequest person);
    void DeletePerson(Guid id);
}