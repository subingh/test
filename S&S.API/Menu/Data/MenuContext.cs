using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i => i.IngredientId);
            modelBuilder.Entity<Dish>().HasData
            (
                 new Dish
                 {
                     Id = 1,
                     Name = "Pizza",
                     Price = 7.0,
                     ImageUrl = "https://www.allrecipes.com/thmb/0xH8n2D4cC97t7mcC7eT2SDZ0aE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/6776_Pizza-Dough_ddmfs_2x1_1725-fdaa76496da045b3bdaadcec6d4c5398.jpg"
                 }
            );
            modelBuilder.Entity<Ingredient>().HasData
            (
                new Ingredient
                {
                    Id = 1,
                    Name = "Tomato Sauce",
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Mozzarella",
                }
            ) ;
            modelBuilder.Entity<DishIngredient>().HasData
            (
                new DishIngredient
                {
                    DishId = 1,
                    IngredientId = 2

                }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
