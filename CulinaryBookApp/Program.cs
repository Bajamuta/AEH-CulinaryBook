using System;
using CulinaryBookApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CulinaryBookApp
{
    class Program
    {
        static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();
            
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args).ConfigureServices(
                (context, services) =>
                {
                    new Startup(context).ConfigureServices(services);
                });

    }
}

public class Startup
{
    private HostBuilderContext _context;

    public Startup(HostBuilderContext context)
    {
        _context = context;
        /*using (var scope = _context..Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<CulinaryBookContext>();
            db.Database.EnsureCreated();
            db.Author.Add(
                new AuthorEntity()
                {
                    NAME = "Jaś Fasola",
                    LOGIN = "fasola",
                    PASSWORD = "B4@n$!",
                    TYPE = "user",
                    DESCRIPTION = "beans beans",
                    EMAIL = "jas@fasola.com"
                });
        }*/
    }
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContextFactory<CulinaryBookContext>(
            options => options.UseSqlServer("Data Source=(local); Database=KUCHARSKA;User Id=jap; Password='Baz1nga!';"));

}