using System.Collections;
using System.Threading.Tasks;
using CulinaryBookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBookApp.Services
{
    // DbObject is for making sure all T objects has ID property
    public class DataAccessService<T> : IDateService<T> where T : DbObject
    {
        private readonly CulinaryBookContextFactory _contextFactory;

        public DataAccessService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /*public void TestDB()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Author.Add(new AuthorEntity()
                {
                    NAME = "Jaś Fasola",
                    LOGIN = "fasola",
                    PASSWORD = "B4@n$!",
                    TYPE = "user",
                    DESCRIPTION = "beans beans",
                    EMAIL = "jas@fasola.com"
                });
            }
        }*/
        public async Task<IEnumerable> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> Create(T entity)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                var createdEntity = await context.Set<T>().AddAsync(entity);
                // TODO add error handling
                await context.SaveChangesAsync();
                return createdEntity.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.ID == id);
                context.Set<T>().Remove(entity);
                // TODO add error handling
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}