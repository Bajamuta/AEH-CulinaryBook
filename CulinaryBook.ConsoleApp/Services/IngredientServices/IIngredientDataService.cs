using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.IngredientServices
{
    public interface IIngredientDataService
    {
        Task<IEnumerable> GetAll();
        Task<Ingredient> Get(int id);
        Task<Ingredient> GetByName(string name);
        Task<Ingredient> Create(Ingredient entity);
        Task<Ingredient> Update(int id, Ingredient entity);
        Task<bool> Delete(int id);
    }
}