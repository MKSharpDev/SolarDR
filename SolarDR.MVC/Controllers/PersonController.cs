using AutoMapper;
using Humanizer.Bytes;
using Microsoft.AspNetCore.Mvc;
using SolarDR.Application;
using SolarDR.Application.Contracts;
using SolarDR.Domain;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.MVC.Models.ImageModel;
using SolarDR.MVC.Models.PersonModel;
using System.Collections;
using System.Collections.Generic;

namespace SolarDR.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService, IMapper mapper, IImageService imageService)
        {
            this.personService = personService;
            this.mapper = mapper;
            this.imageService = imageService;
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
            var images = await imageService.GetByPersonIdAsync(id, HttpContext.RequestAborted);

            List<ImageSimpleModel> formFiles = new List<ImageSimpleModel>();

            PersonWithImagesResponce result = new PersonWithImagesResponce()
            {
                Id = person.Id,
                Images = mapper.Map<ICollection<ImageSimpleModel>>(images),
                Name = person.Name,
                LastName=person.LastName,
                Date = person.Date

            };
            return View(result);
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
                var id = collection["Id"];
                var name = collection["name"];
                var lastName = collection["lastName"];
                var date = collection["date"];
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastName)
                    && !string.IsNullOrEmpty(date))
                {
                    PersonDTO PersonToEditDTO = new PersonDTO()
                    {
                        Id = Guid.Parse(id),
                        Name = name,
                        LastName = lastName,
                        Date = DateOnly.Parse(date)
                    };

                    await personService.UpdateAsync(PersonToEditDTO, HttpContext.RequestAborted);
                }
                return RedirectToAction(nameof(Index));
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

        public async Task<ActionResult> AddImage(Guid id)
        {
            var person = await personService.GetByIdAsync(id, HttpContext.RequestAborted);
            return View(mapper.Map<PersonResponse>(person));
        }


        [HttpPost]
        public async Task<ActionResult> AddImage(IFormCollection collection)
        {
            try
            {
                var personId = collection["Id"];
                var image = collection.Files["Image"];

                if (image != null)
                {
                    byte[] imageData = null;
                    
                    using (var binaryReader = new BinaryReader(image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)image.Length);
                    }
                    
                    ImageDto newImage = new ImageDto()
                    {
                        Id = Guid.NewGuid(),
                        PersonId = Guid.Parse(personId),
                        bytes = imageData
                    };

                    await imageService.CreateAsync(newImage, HttpContext.RequestAborted);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }

        }

        public async Task<ActionResult> DeleteImage(Guid Id)
        {
            try
            {
                if (Guid.Empty != Id)
                {
                    await imageService.DeleteAsync(Id, HttpContext.RequestAborted);
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
