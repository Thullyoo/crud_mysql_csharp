using crud_mysql.Request;

namespace crud_mysql.Data.Repository;

public interface IPersonRepository
{
    Task<Person> AddPerson(PersonRequest personRequest);
    
    Task<Person> UpdatePerson(Guid id, PersonRequest personRequest);
    
    void DeletePerson(Guid id);
    
    Task<Person> GetPersonById(Guid id);
    
    Task<List<Person>> GetAllPersons();
}