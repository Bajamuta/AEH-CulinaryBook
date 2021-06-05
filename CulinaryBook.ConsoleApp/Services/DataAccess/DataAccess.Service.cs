using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CulinaryBook.ConsoleApp.Services.DataAccess
{
    // DbObject is for making sure all T objects has ID property
    public class DataAccessService<T> : IDataService<T> where T : DbObject
    {
        private readonly CulinaryBookContextFactory _contextFactory;

        public DataAccessService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
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
            T entity = null;
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                try
                {
                    entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.ID == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                // TODO add error handling
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                // TODO add error handling e.x. required fields
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
                // TODO add error handling e.x. element is used as foreign key
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}