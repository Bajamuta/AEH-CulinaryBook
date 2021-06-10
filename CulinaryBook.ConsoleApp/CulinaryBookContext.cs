using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp
{
    public class CulinaryBookContext : DbContext
    {
        public CulinaryBookContext(DbContextOptions<CulinaryBookContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<IngredientsList> IngredientsLists { get; set; }
        public DbSet<RecipesList> RecipesLists { get; set; }
        public DbSet<StepsList> StepsLists { get; set; }
    }
}