using Microsoft.EntityFrameworkCore;

namespace CulinaryBookApp
{
    public class CulinaryBookContext : DbContext
    {
        public CulinaryBookContext(DbContextOptions<CulinaryBookContext> options) : base(options)
        {
        }
        
        protected CulinaryBookContext()
        {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo");
            /*modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                    
                }
            );*/
            base.OnModelCreating(modelBuilder);
        }
        
        /*public DbSet<AuthorEntity> Author { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<IngredientEntity> Ingredient { get; set; }
        public DbSet<StepEntity> Step { get; set; }
        public DbSet<RecipeEntity> Recipe { get; set; }
        public DbSet<StepsListEntity> StepsList { get; set; }
        public DbSet<IngredientsListEntity> IngredientsList { get; set; }
        public DbSet<RecipesListsEntity> RecipesList { get; set; }*/

        /*public DbSet<Author> Author { get; set; }*/
        public DbSet<AuthorEntity> Author { get; set; }
    }
}