using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolarDR.Application.Contracts;
using SolarDR.Application.Services;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.MVC.Models;
using SolarDR.MVC.Models.PersonModel;
using System.Diagnostics;

namespace SolarDR.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IPersonService personService, IMapper mapper)
        {
            this.logger = logger;
            this.personService = personService;
            this.mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var persons = await personService.Get(HttpContext.RequestAborted);

            return View(mapper.Map<ICollection<PersonResponse>>(persons));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
