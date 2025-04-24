using Microsoft.AspNetCore.Mvc;
using Training_App.Data;
using Trianing_App.Models;

namespace Training_App.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository _cityRepo;

        public CityController(CityRepository cityRepo)
        {
            _cityRepo = cityRepo;
        }

        // GET: City/Index
        public IActionResult Index()
        {
            var cities = _cityRepo.GetAllCities();
            return View(cities);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.InsertCity(city);
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }
    }
}
