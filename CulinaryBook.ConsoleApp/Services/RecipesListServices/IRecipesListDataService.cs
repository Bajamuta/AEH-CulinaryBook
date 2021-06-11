using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.RecipesListServices
{
    public interface IRecipesListDataService : IDataService<RecipesList>
    {
        public Task<RecipesList> GetByRecipe(Recipe recipe);
        public Task<IEnumerable> GetByCategory(Category category);
        public Task<IEnumerable> GetByBook(Book book);
    }
}