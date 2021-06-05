using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        
        public async Task<T> GetByName(string name)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Name.Contains(name));
                // TODO add error handling
                return entity;
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