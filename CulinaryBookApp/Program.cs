using System;
using CulinaryBookApp;
using CulinaryBookApp.Models;
using CulinaryBookApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CulinaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            IDateService<Author> authorService = new DataAccessService<Author>(new CulinaryBookContextFactory());
            IDateService<Book> bookService = new DataAccessService<Book>(new CulinaryBookContextFactory());
            IDateService<Category> categoryService = new DataAccessService<Category>(new CulinaryBookContextFactory());
            IDateService<Ingredient> ingredientService =
                new DataAccessService<Ingredient>(new CulinaryBookContextFactory());
            IDateService<Recipe> recipeService = new DataAccessService<Recipe>(new CulinaryBookContextFactory());
            IDateService<Step> stepService = new DataAccessService<Step>(new CulinaryBookContextFactory());
            IDateService<IngredientsList> ingredientsService =
                new DataAccessService<IngredientsList>(new CulinaryBookContextFactory());
            IDateService<RecipesList> recipesService =
                new DataAccessService<RecipesList>(new CulinaryBookContextFactory());
            IDateService<StepsList> stepsService = new DataAccessService<StepsList>(new CulinaryBookContextFactory());
            Console.WriteLine(authorService.Get(1).Result.Name);
            /*authorService.Create(
                new Author
                    {
                        Type = "user", 
                        Name = "Jagoda Malinka", 
                        Login = "jagoda", 
                        Password = "m@l!nk!", 
                        Email = "jagoda@malinka.pl", 
                        Description = "Malinka jagody truskawki"
                    });*/
            bookService.Create(
                new Book
                {
                    Name = "Japanese Cuisine"
                }
            );
            categoryService.Create(
                new Category
                {
                    Name = "Dessert",
                    Description = "Sweets for you"
                }
            );
            ingredientService.Create(
                new Ingredient
                {
                    Name = "rice",
                    Junit = "g"
                }
                );
            recipeService.Create(
                new Recipe
                {
                    Name = "Sushi",
                    Id_Author = 1005,
                    Photo = "www.pinterest.com"
                }
            );
            stepService.Create(
                new Step
                {
                    Description = "chop vegetables"
                }
            );
            Console.WriteLine(ingredientsService.Get(1).Result.Id_Ingredient);
            Console.WriteLine(recipesService.Get(2).Result.Id_Book);
            Console.WriteLine(stepsService.Get(1).Result.Step_Number);
            //Console.ReadLine();
        }
            /*=> CreateHostBuilder(args).Build().Run();*/
            
        /*public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).ConfigureServices(
                (context, services) =>
                {
                    new Startup(context).ConfigureServices(services);
                });*/

    }
}

/*public class Startup
{
    private HostBuilderContext _context;

    public Startup(HostBuilderContext context)
    {
        _context = context;
    }
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContextFactory<CulinaryBookContext>(
            options => options.UseSqlServer("Data Source=(local); Database=KUCHARSKA;User Id=jap; Password='Baz1nga!';"));

}*/