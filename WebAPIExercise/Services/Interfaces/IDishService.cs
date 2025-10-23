using Microsoft.AspNetCore.Http.HttpResults;
using WebAPIExercise.Models;

namespace WebAPIExercise.Services.Interfaces
{
    public interface IDishService
    {
        List<Dish> Dish { get; set; }
        List<Dish> Get();
        Dish? Search(string name);
    }
}
