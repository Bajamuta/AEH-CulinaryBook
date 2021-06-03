using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services
{
    public class DataAccessWithNameService<T> : DataAccessService<T> where T : DbObjectWithName
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        public DataAccessWithNameService(CulinaryBookContextFactory contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task<T> GetByName(string name)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Name.Contains(name));
                // TODO add error handling
                return entity;
            }
        }
    }
}