using System;
using CulinaryBookApp;
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
            Console.WriteLine(authorService.Get(1).Result.NAME);
            Console.ReadLine();
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

public class Startup
{
    private HostBuilderContext _context;

    public Startup(HostBuilderContext context)
    {
        _context = context;
    }
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContextFactory<CulinaryBookContext>(
            options => options.UseSqlServer("Data Source=(local); Database=KUCHARSKA;User Id=jap; Password='Baz1nga!';"));

}