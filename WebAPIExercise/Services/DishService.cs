using WebAPIExercise.Models;
using WebAPIExercise.Services.Interfaces;

namespace WebAPIExercise.Services
{
    public class DishService : IDishService
    {
        public List<Dish> Dish { get; set; }

        public DishService()
        {
            Dish = new List<Dish>
            {
                new Dish { Id = 1, Name = "Pizza", CourseType = "Main course", Description = "Typical italian food", Price = 10},
                new Dish { Id = 2, Name = "Tiramisu", CourseType = "Dessert", Description = "Italian dessert with coffee, mascarpone and cocoa", Price = 5}
            };
        }

        public List<Dish> Get()
        {
            return Dish;
        }

        public Dish? Search(string name)
        {
            var result = Dish.FirstOrDefault(d => d.Name == name);
            return result;
        }
    }
}
