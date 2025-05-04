using Microsoft.AspNetCore.Mvc;
using Training_App.Models;
using Trianing_App.Models;


namespace Training_App.Controllers
{
    [Route("City")]
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
        public IActionResult Create(CityInputModel model)
        {
            if (ModelState.IsValid)
            {
                _cityRepo.InsertCity(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    

        // POST: City/Create
        [HttpPost("CreteApi")]
        public IActionResult CreateApi([FromBody] CityInputModel model)
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
                var isAdded = _cityRepo.InsertCity(model);

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


        [HttpPut("UpdateAPI")]
        public IActionResult UpdateAPI([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid input.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                var isUpdated = _cityRepo.UpdateCity(city);
                if (isUpdated)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City updated successfully."
                    });
                }

                return NotFound(new
                {
                    success = false,
                    message = "City not found."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An error occurred while updating.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("DeleteAPI/{id}")]
        public IActionResult DeleteAPI(int id)
        {
            try
            {
                var isDeleted = _cityRepo.DeleteCity(id);
                if (isDeleted)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "City deleted successfully."
                    });
                }

                return NotFound(new
                {
                    success = false,
                    message = "City not found."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An error occurred while deleting.",
                    error = ex.Message
                });
            }
        }


        [HttpGet("GetAllAPI")]
        public IActionResult GetAllAPI()
        {
            try
            {
                var cities = _cityRepo.GetAllCities();
                return Ok(new
                {
                    success = true,
                    data = cities
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An error occurred while retrieving data.",
                    error = ex.Message
                });
            }
        }


    }
}
