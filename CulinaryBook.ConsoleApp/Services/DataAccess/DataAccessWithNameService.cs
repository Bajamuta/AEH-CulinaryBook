using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services.DataAccess
{
    public class DataAccessWithNameService<T> where T : DbObjectWithName
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessService<T> _service;
        public DataAccessWithNameService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _service = new DataAccessService<T>(contextFactory);
        }
        
        public async Task<IEnumerable> GetAllByName(string name)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entityList = await context.Set<T>().Where((e) => e.Name.Contains(name)).ToListAsync();
                // TODO add error handling
                return entityList;
            }
        }

        public async Task<T> GetExactByName(string name)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                {
                    T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Name == name);
                    return entity;
                }
            }
        }
        
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<T> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<T> Create(T entity)
        {
            return await _service.Create(entity);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}