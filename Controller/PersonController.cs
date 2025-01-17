using crud_mysql.Data.Repository;
using crud_mysql.Request;
using Microsoft.AspNetCore.Mvc;

namespace crud_mysql.Controller;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(PersonRequest person)
    {
        var result = _personRepository.AddPerson(person);

        if (result == null)
        {
            return BadRequest();
        }

        return Created("", person);
    }
}