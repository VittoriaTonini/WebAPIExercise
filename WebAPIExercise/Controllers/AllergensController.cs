using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExercise.Models;

namespace WebApiExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergensController : Controller
    {
        public List<Allergen> allergenList; //dichiarazione della lista


        public AllergensController() //istanziamo la lista nel costruttore
        {
            allergenList = new List<Allergen>()
            {
                new Allergen { Id = 1, Name = "Milk"},
                new Allergen { Id = 2, Name = "Eggs"},
                new Allergen { Id = 3, Name = "Gluten"}
            };
        }

        // GET: AllergensController
        [HttpGet]
        public IEnumerable<Allergen> Index()
        {
            return allergenList;
        }

        // GET: AllergensController/search
        [HttpGet("search")]
        public IActionResult Get(string name)
        {
            var result = allergenList.FirstOrDefault(a => a.Name == name);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST: AllergensControllers
        [HttpPost]
        public IActionResult Post([FromBody] Allergen newAllergen)
        {
            return Ok(new { success = true, newAllergen });
        }
    }
}
