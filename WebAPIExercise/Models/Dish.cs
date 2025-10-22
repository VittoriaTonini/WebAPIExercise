namespace WebAPIExercise.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? CourseType { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
