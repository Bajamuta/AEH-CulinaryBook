using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class RecipesViewFactory : IViewModelFactory<RecipesViewModel>
    {
        private readonly IRecipeDataService _service;
        private readonly IAuthenticator _authenticator;
        private readonly IIngredientDataService _ingredientDataService;

        public RecipesViewFactory(IRecipeDataService service, IAuthenticator authenticator, IIngredientDataService ingredientDataService)
        {
            _service = service;
            _authenticator = authenticator;
            _ingredientDataService = ingredientDataService;
        }
        public RecipesViewModel CreateViewModel()
        {
            return new RecipesViewModel(_service, _authenticator, _ingredientDataService);
        }
    }
}