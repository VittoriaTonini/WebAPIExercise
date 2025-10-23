using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;
using WebAPIExercise.Models;
using WebAPIExercise.Services;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergensController : Controller
    {
        private readonly AllergenService _allergenService;
        private readonly ILogger<AllergensController> _logger;

        public AllergensController(AllergenService allergenService, ILogger<AllergensController> logger)
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
            _logger.LogInformation("New allergen: {message}", JsonSerializer.Serialize(newAllergen));
            var result = _allergenService.Add(newAllergen);
            return result == null ? NotFound() : Ok(result);
        }

        //DELETE: api/AllergensController/delete
        [HttpDelete]
        public IActionResult Delete(string name)
        {
            _logger.LogInformation("Deleted allergen's name: {message}", JsonSerializer.Serialize(name));
            var result = _allergenService.DeleteByName(name);
            return result == null ? NotFound() : Ok(result);
        }

        //PUT: api/AllergensController/put
        [HttpPut]
        public IActionResult Put(int id, Allergen newAllergen)
        {
            _logger.LogInformation("Modified allergen's id: {message}", JsonSerializer.Serialize(id));
            var result = _allergenService.ModifyById(id, newAllergen);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
