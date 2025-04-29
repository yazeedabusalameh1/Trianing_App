using Microsoft.AspNetCore.Mvc;
using Training_App.Models;
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
    

        // POST: City/Create
        [HttpPost]
        public IActionResult CreateApi([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation failed.",
                    errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var isAdded = _cityRepo.InsertCity(city);

                if (isAdded)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City added successfully."
                    });
                }

                return StatusCode(500, new
                {
                    success = false,
                    message = "Failed to add city due to internal issue."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred.",
                    error = ex.Message
                });
            }
        }

    }
}
