using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CulinaryBookApp
{
    public class CulinaryBookContextFactory : IDesignTimeDbContextFactory<CulinaryBookContext>
    {
        public CulinaryBookContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<CulinaryBookContext>();
            options.UseSqlServer("Data Source=(local); Database=KUCHARSKA;User Id=jap; Password='Baz1nga!';");
            return new CulinaryBookContext(options.Options);
        }
    }
}