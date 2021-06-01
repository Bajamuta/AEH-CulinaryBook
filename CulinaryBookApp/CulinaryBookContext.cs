using CulinaryBookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBookApp
{
    public class CulinaryBookContext : DbContext
    {
        public CulinaryBookContext(DbContextOptions<CulinaryBookContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasOne<Author>(recipe => recipe.Author)
                .WithOne(author => author.Recipe)
                .HasForeignKey<Recipe>(recipe => recipe.Id_Author);

            modelBuilder.Entity<IngredientsList>()
                .HasKey(ingr => new {ingr.Id_Recipe, ingr.Id_Ingredient});
            modelBuilder.Entity<IngredientsList>()
                .HasOne<Recipe>(list => list.Recipe)
                .WithMany(recipe => recipe.IngredientsLists)
                .HasForeignKey(ingr => ingr.Id_Recipe);
            modelBuilder.Entity<IngredientsList>()
                .HasOne<Ingredient>(list => list.Ingredient)
                .WithMany(ingredient => ingredient.IngredientsLists)
                .HasForeignKey(list => list.Id_Ingredient);
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}