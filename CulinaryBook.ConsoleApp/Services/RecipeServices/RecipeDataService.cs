using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.RecipeServices
{
    public class RecipeDataService : IRecipeDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessWithNameService<Recipe> _service;

        public RecipeDataService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessWithNameService<Recipe>(contextFactory);
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<Recipe> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<Recipe> Create(Recipe entity)
        {
            return await _service.Create(entity);
        }

        public async Task<Recipe> Update(int id, Recipe entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }

        public async Task<IEnumerable> GetAllByName(string name)
        {
            return await _service.GetAllByName(name);
        }
    }
}