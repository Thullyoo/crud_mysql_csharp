using crud_mysql.Data.Repository;
using crud_mysql.Request;

namespace crud_mysql.Service;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    public async Task<List<Person>> GetPersons()
    {
        return await _personRepository.GetAllPersons();
    }

    public async Task<Person> GetPersonById(Guid id)
    {
        return await _personRepository.GetPersonById(id);
    }

    public async Task<Person> AddPerson(PersonRequest person)
    {
        return await _personRepository.AddPerson(person);
    }

    public async Task<Person> UpdatePerson(Guid id, PersonRequest person)
    {
        return await _personRepository.UpdatePerson(id, person);
    }

    public void DeletePerson(Guid id)
    { 
        _personRepository.DeletePerson(id);
    }
}