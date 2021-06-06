using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.CategoryServices
{
    public class CategoryDataService : ICategoryDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessWithNameService<Category> _service;

        public CategoryDataService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _service = new DataAccessWithNameService<Category>(contextFactory);
        }
        
        public Task<IEnumerable> GetAll()
        {
            return _service.GetAll();
        }

        public Task<Category> Get(int id)
        {
            return _service.Get(id);
        }

        public Task<Category> GetByName(string name)
        {
            return _service.GetByName(name);
        }

        public Task<Category> Create(Category entity)
        {
            return _service.Create(entity);
        }

        public Task<Category> Update(int id, Category entity)
        {
            return _service.Update(id, entity);
        }

        public Task<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}