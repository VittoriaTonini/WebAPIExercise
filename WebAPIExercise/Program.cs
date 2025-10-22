using WebApiExercise.Endpoints;

namespace WebAPIExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer(); //lo utilizziamo per far funzionare gli endpoints
            builder.Services.AddControllers(); //lo utilizziamo per far funzionare i controllers
            builder.Services.AddSwaggerGen(); //lo utilizziamo per usare swagger

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); //lo utilizziamo per swagger
                app.UseSwaggerUI(); //lo utilizziamo per swagger
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers(); //serve per mappare i controllers

            app.MapDishEndpoints(); //metodo della classe DishEndpoints

            app.Run();
        }
    }
}
