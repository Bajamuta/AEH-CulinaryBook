using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.RecipeServices
{
    public interface IAddRecipeService
    {
        Task<Recipe> AddRecipe(int authorId, string name, string photo);
    }
}