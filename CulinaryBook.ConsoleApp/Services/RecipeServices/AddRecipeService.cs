using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.RecipeServices
{
    public class AddRecipeService : IAddRecipeService
    {
        private readonly IDateService<Recipe> _recipeService;

        public AddRecipeService(IDateService<Recipe> recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Recipe> AddRecipe(int authorId, string name, string photo)
        {
            Recipe recipe = new Recipe()
            {
                Name = name,
                Photo = photo,
                Id_Author = authorId
            };
            await _recipeService.Create(recipe);
            return recipe;
        }
    }
}