using Microsoft.AspNetCore.Mvc;
using DAL.ModelsDAL;
using Trianing_App.BL.BLInterface;

namespace Training_App.Controllers
{
    [Route("Citizen")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenBLService _citizenService;

        public CitizenController(ICitizenBLService citizenService)
        {
            _citizenService = citizenService;
        }

        [HttpGet("GetAllApi")]
        public IActionResult GetAllApi()
        {
            try
            {
                var citizens = _citizenService.GetAllCitizens();
                return Ok(new { success = true, data = citizens });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Error retrieving data", error = ex.Message });
            }
        }

        [HttpPost("CreateApi")]
        public IActionResult CreateApi([FromBody] Citizen model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation failed.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            try
            {
                bool isAdded = _citizenService.AddCitizen(model);
                return isAdded
                    ? Ok(new { success = true, message = "Citizen added successfully." })
                    : StatusCode(500, new { success = false, message = "Failed to add citizen." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Unexpected error", error = ex.Message });
            }
        }

        [HttpPut("UpdateApi")]
        public IActionResult UpdateApi([FromBody] Citizen model)
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
                var isUpdated = _citizenService.UpdateCitizen(model);
                return isUpdated
                    ? Ok(new { success = true, message = "Citizen updated successfully." })
                    : NotFound(new { success = false, message = "Citizen not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Update error", error = ex.Message });
            }
        }

        [HttpDelete("DeleteApi/{id}")]
        public IActionResult DeleteApi(string id)
        {
            try
            {
                var isDeleted = _citizenService.DeleteCitizen(id);
                return isDeleted
                    ? Ok(new { success = true, message = "Citizen deleted successfully." })
                    : NotFound(new { success = false, message = "Citizen not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Delete error", error = ex.Message });
            }
        }
    }
}
