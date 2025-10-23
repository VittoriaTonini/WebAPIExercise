using Microsoft.AspNetCore.Http;
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

        public AllergensController(AllergenService allergenService)
        {
            _allergenService = allergenService;
        }

        // GET: AllergensController
        [HttpGet]
        public IEnumerable<Allergen> Get()
        {
            return _allergenService.GetAll();
        }

        // GET: AllergensController/search
        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var result = _allergenService.GetByName(name);
            return result == null ? NotFound() : Ok(result);
        }

        // POST: AllergensControllers
        [HttpPost]
        public IActionResult Post([FromBody] Allergen newAllergen)
        {
            var result = _allergenService.Add(newAllergen);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
