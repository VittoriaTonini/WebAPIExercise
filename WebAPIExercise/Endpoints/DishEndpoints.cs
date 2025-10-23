using Microsoft.AspNetCore.Http.HttpResults;
using WebAPIExercise.Models;
using WebAPIExercise.Services.Interfaces;

namespace WebApiExercise.Endpoints
{
    public static class DishEndpoints
    {
        public static void MapDishEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("api/dish").WithDescription("Dish Enpoints"); //MapGroup crea un gruppo di endpoints con un prefisso comune
            
            endpoints.MapGet("/", Get).WithSummary("Gets the dish");
            endpoints.MapGet("/search", Search).WithSummary("Searches a specific dish");
        }

        static Results<Ok<List<Dish>>, NotFound, ProblemHttpResult> Get(IDishService service) //l'interfaccia come parametro ci serve per la method injection
        {
            var result = service.Get(); //method injection
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result); ;
        }

        static Results<Ok<Dish>, NotFound, ProblemHttpResult> Search(string name, IDishService service)
        {
            var result = service.Search(name);
            return result == null ? TypedResults.NotFound() : TypedResults.Ok(result);
        }
    }
}
