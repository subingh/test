namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public double Price { get; set; }

        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
