using crud_mysql.Data.Repository;
using crud_mysql.Request;
using crud_mysql.Service;
using Microsoft.AspNetCore.Mvc;

namespace crud_mysql.Controller;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> addPerson(PersonRequest person)
    {
        var result = _personService.AddPerson(person);

        if (result == null)
        {
            return BadRequest();
        }

        return Created("", person);
    }
    
    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<IActionResult> getPersons()
    {
        var result = await _personService.GetPersons();
        
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
    
    [HttpPut]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("{id:guid}")]
    public async Task<IActionResult> updatePerson(Guid id, PersonRequest person)
    {
        var result = _personService.UpdatePerson(id, person);

        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok(result.GetAwaiter().GetResult());
    }

    [HttpDelete]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("{id:guid}")]
    public async Task<IActionResult> deletePerson(Guid id)
    {
        _personService.DeletePerson(id);
        
        return NoContent();
    }

    [HttpGet]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("{id:guid}")]
    public async Task<IActionResult> getPersonById(Guid id)
    {
        var result = await _personService.GetPersonById(id);

        if (result == null)
        {
            return BadRequest();
        }
        
        return Ok(result);
    }
    
    
}