using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.IngredientServices
{
    public class IngredientDataService : IIngredientDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessWithNameService<Ingredient> _service;

        public IngredientDataService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessWithNameService<Ingredient>(contextFactory);
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable> GetAllByName(string name)
        {
            return await _service.GetAllByName(name);
        }
        
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<Ingredient> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<Ingredient> Create(Ingredient entity)
        {
            return await _service.Create(entity);
        }

        public async Task<Ingredient> Update(int id, Ingredient entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}