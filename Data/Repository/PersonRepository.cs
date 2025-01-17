using crud_mysql.Mapper;
using crud_mysql.Request;
using Microsoft.EntityFrameworkCore;

namespace crud_mysql.Data.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _context;
    
    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Person> AddPerson(PersonRequest personRequest)
    {
        Person person = PersonMapper.MapRequestToPerson(personRequest);
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> UpdatePerson(Guid id, PersonRequest personRequest)
    {
        Person person = GetPersonById(id).GetAwaiter().GetResult();

        if (personRequest.email != "")
        {
            person.setEmail(personRequest.email);
        }

        if (personRequest.password != "")
        {
            person.setPassword(personRequest.password);
        }
        
        await _context.SaveChangesAsync();

        return person;
    }

    public async void DeletePerson(Guid id)
    {
       Person person = GetPersonById(id).GetAwaiter().GetResult();
       _context.Persons.Remove(person);
       await _context.SaveChangesAsync();
    }

    public async Task<Person> GetPersonById(Guid id)
    {
        Person person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        if (person == null)
        {
            throw new KeyNotFoundException("Person not found"); 
        }
        return person;
    }

    public async Task<List<Person>> GetAllPersons()
    {
        return _context.Persons.ToList();
    }
}