using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System.Security.Cryptography.X509Certificates;
using NLayerProject.API.DTOs;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(PersonDto personDto)
        {
            var persons = await _personService.Where(x =>x.Email== personDto.mail& x.Password==personDto.password);
            if (persons.Count() > 0)
            {
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Ok(newPerson);
        }

        [HttpGet]
        [Route("{mail}")]
        public async Task<IActionResult> Get(string mail)
        {
            var currentUser = await _personService.GetByMailAsync(mail);
            return Ok(currentUser);
        }
    }
}
