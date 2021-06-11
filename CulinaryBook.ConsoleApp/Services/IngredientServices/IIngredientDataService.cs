using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.IngredientServices
{
    public interface IIngredientDataService : IDataService<Ingredient>
    {
        Task<IEnumerable> GetAllByName(string name);
    }
}