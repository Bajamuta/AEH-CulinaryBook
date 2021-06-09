using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.RecipeServices
{
    public interface IRecipeDataService : IDataService<Recipe>
    {
        Task<IEnumerable> GetAllByName(string name);
    }
}