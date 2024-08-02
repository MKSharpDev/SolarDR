using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolarDR.Application;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.MVC.Models.PersonModel;

namespace SolarDR.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var persons = await personService.Get(HttpContext.RequestAborted);

            return View(mapper.Map<ICollection<PersonResponse>>(persons));
        }
        public ActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var name = collection["name"];
                var lastName = collection["lastName"];
                var date = collection["date"];
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastName) 
                    && !string.IsNullOrEmpty(date))
                {
                    PersonDTO newPersonDTO = new PersonDTO()
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        LastName = lastName,
                        Date = DateOnly.Parse(date)
                    };
                    await personService.CreateAsync(newPersonDTO, HttpContext.RequestAborted);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var person = await personService.GetByIdAsync(id, HttpContext.RequestAborted);
            return View(mapper.Map<PersonResponse>(person));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var person = await personService.GetByIdAsync(id, HttpContext.RequestAborted);
            return View(mapper.Map<PersonResponse>(person));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(IFormCollection collection)
        {
            try
            {
                var Id = collection["Id"];
                var name = collection["name"];
                var lastName = collection["lastName"];
                var date = collection["date"];
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastName)
                    && !string.IsNullOrEmpty(date))
                {
                    PersonDTO PersonToEditDTO = new PersonDTO()
                    {
                        Id = Guid.Parse(Id),
                        Name = name,
                        LastName = lastName,
                        Date = DateOnly.Parse(date)
                    };

                    await personService.UpdateAsync(PersonToEditDTO, HttpContext.RequestAborted);
                }
                return RedirectToAction(nameof(Edit));
            }
            catch (Exception)
            {

                return View();
            }
        }


        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if (Guid.Empty != id)
                {
                    await personService.DeleteAsync(id, HttpContext.RequestAborted);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
