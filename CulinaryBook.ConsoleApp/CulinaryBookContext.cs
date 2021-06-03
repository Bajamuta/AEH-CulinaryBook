using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp
{
    public class CulinaryBookContext : DbContext
    {
        public CulinaryBookContext(DbContextOptions<CulinaryBookContext> options) : base(options)
        {
            //Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Recipe>()
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
            
            modelBuilder.Entity<StepsList>()
                .HasKey(ingr => new {ingr.Id_Recipe, ingr.Id_Step});
            modelBuilder.Entity<StepsList>()
                .HasOne<Recipe>(list => list.Recipe)
                .WithMany(recipe => recipe.StepsLists)
                .HasForeignKey(ingr => ingr.Id_Recipe);
            modelBuilder.Entity<StepsList>()
                .HasOne<Step>(list => list.Step)
                .WithMany(ingredient => ingredient.StepsLists)
                .HasForeignKey(list => list.Id_Step);
            
            modelBuilder.Entity<RecipesList>()
                .HasKey(ingr => new {ingr.Id_Recipe, ingr.Id_Category, ingr.Id_Book});
            modelBuilder.Entity<RecipesList>()
                .HasOne<Recipe>(list => list.Recipe)
                .WithMany(recipe => recipe.RecipesLists)
                .HasForeignKey(ingr => ingr.Id_Recipe);
            modelBuilder.Entity<RecipesList>()
                .HasOne<Category>(list => list.Category)
                .WithMany(category => category.RecipesLists)
                .HasForeignKey(list => list.Id_Category);
            modelBuilder.Entity<RecipesList>()
                .HasOne<Book>(list => list.Book)
                .WithMany(book => book.RecipesLists)
                .HasForeignKey(list => list.Id_Book);*/
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