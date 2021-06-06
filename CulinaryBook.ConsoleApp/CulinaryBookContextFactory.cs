using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CulinaryBook.ConsoleApp
{
    public class CulinaryBookContextFactory : IDesignTimeDbContextFactory<CulinaryBookContext>
    {
        public CulinaryBookContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<CulinaryBookContext>();
            options.UseSqlServer("Data Source=(local); Database=CulinaryBook;User Id=jap; Password='Baz1nga!';");
            return new CulinaryBookContext(options.Options);
        }
    }
}