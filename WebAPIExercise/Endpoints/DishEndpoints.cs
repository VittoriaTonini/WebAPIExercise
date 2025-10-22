using Microsoft.AspNetCore.Http.HttpResults;
using WebAPIExercise.Models;

namespace WebApiExercise.Endpoints
{
    public static class DishEndpoints
    {
        static readonly List<Dish> _dishList =
        [
            new Dish { Id = 1, Name = "Pizza", CourseType = "Main course", Description = "Typical italian food", Price = 10},
            new Dish { Id = 2, Name = "Tiramisu", CourseType = "Dessert", Description = "Italian dessert with coffee, mascarpone and cacao", Price = 5}
        ];


        public static void MapDishEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/dish").WithDescription("Dish Enpoints"); //MapGroup crea un gruppo di endpoints con un prefisso comune
            
            endpoints.MapGet("/", Get).WithSummary("Gets the dish");
            endpoints.MapGet("/search", Search).WithSummary("Searches a specific dish");
        }

        static List<Dish> Get()
        {
            return _dishList;
        }

        static Results<Ok<Dish>, NotFound, ProblemHttpResult> Search(string name)
        {
            var result = _dishList.FirstOrDefault(d => d.Name == name);
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
