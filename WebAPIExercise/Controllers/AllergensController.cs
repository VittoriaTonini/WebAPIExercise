using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Models;
using WebAPIExercise.Services;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergensController : Controller
    {
        private readonly AllergenService _allergenService;
        private readonly ILogger<AllergenService> _logger;

        public AllergensController(AllergenService allergenService, ILogger<AllergenService> logger)
        {
            _allergenService = allergenService;
            _logger = logger;
        }

        // GET: api/AllergensController
        [HttpGet]
        public IEnumerable<Allergen> Get()
        {
            return _allergenService.GetAll();
        }

        // GET: api/AllergensController/search
        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var result = _allergenService.GetByName(name);
            return result == null ? NotFound() : Ok(result);
        }

        // POST: api/AllergensControllers
        [HttpPost]
        public IActionResult Post([FromBody] Allergen newAllergen)
        {
            var result = _allergenService.Add(newAllergen);
            return result == null ? NotFound() : Ok(result);
        }

        //DELETE: api/AllergensController/delete
        [HttpDelete]
        public IActionResult Delete(string name)
        {
            var result = _allergenService.DeleteByName(name);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
