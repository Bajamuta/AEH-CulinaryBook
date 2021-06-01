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
            IDateService<IngredientsList> ingredientsService =
                new DataAccessService<IngredientsList>(new CulinaryBookContextFactory());
            IDateService<RecipesList> recipesService =
                new DataAccessService<RecipesList>(new CulinaryBookContextFactory());
            IDateService<StepsList> stepsService = new DataAccessService<StepsList>(new CulinaryBookContextFactory());
            Console.WriteLine(authorService.Get(1).Result.Name);
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