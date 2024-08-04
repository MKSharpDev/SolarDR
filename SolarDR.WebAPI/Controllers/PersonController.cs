using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolarDR.Application;
using SolarDR.Infrastructure.Core.Contracts;

namespace SolarDR.WebAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonController : Controller
    {
        private readonly IPersonService personService;


        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO personDTO)
        {
            personDTO.Id = Guid.NewGuid();
            var rezult = await personService.CreateAsync(personDTO, HttpContext.RequestAborted);
            return Ok(rezult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await personService.GetByIdAsync(id, HttpContext.RequestAborted));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await personService.Get(HttpContext.RequestAborted));
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditApplicationDraft(PersonDTO personDTO)
        {
            return Ok(await personService.UpdateAsync(personDTO, HttpContext.RequestAborted));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplicationDraft([FromRoute] Guid id)
        {
            await personService.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok("Запись удалена");
        }


    }
}
