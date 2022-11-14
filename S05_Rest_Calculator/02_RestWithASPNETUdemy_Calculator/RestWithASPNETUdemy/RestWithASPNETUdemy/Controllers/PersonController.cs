using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Implementations;
using System;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }


        [HttpGet]
        public IActionResult Get()

        {
            return Ok(_personService.FindAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindID(id);
            if (person == null) return NotFound();
            return Ok(person);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Creator(person));
        }


        [HttpPut]
        public IActionResult Put([FromBody] Person person) // FromBody: Corpo que aparece do Json
        {
            return Ok(_personService.Update(person));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id) // Quando for deletar, deleta pelo ID: Ex: Deletar Id 02, deleta a pessoa do ID2
        {
            var person = _personService.FindID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
    }


}



