using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite key
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            // Define relationships
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredient) // ✅ Corrected reference
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredient) // ✅ Corrected reference
                .HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id=1, Name="Koshary", Price= 30, ImageUrl= "https://www.google.com/url?sa=i&url=https%3A%2F%2Fsilkroadrecipes.com%2Fkoshari%2F&psig=AOvVaw1khwqu3O6HYzrYLC9x9fO6&ust=1741428786647000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIDjzfPd94sDFQAAAAAdAAAAABAE" }
                );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id=2, Name="Humus"}
                );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { IngredientId=1, DishId=1},
                 new DishIngredient { IngredientId = 2, DishId = 1 }
                );
        }
       public DbSet<Dish> Dish { get; set; }
        public DbSet <Ingredient> ingredients { get; set; }
        public DbSet <DishIngredient> DishIngredient { get; set; }
    }
}
