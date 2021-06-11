using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.IngredientsListServices
{
    public interface IIngredientsListDataService : IDataService<IngredientsList>
    {
        public Task<IEnumerable> GetByRecipe(Recipe recipe);
        public Task<IEnumerable> GetByIngredient(Ingredient ingredient);
    }
}