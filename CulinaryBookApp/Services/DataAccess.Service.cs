using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBookApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entityList = await context.Set<T>().ToListAsync();
                // TODO add error handling
                return entityList;
            }
        }

        public async Task<T> Get(int id)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.ID == id);
                // TODO add error handling
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                // TODO add error handling
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                entity.ID = id;
                // TODO add error handling
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
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