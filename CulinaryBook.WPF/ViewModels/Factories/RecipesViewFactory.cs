using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class RecipesViewFactory : IViewModelFactory<RecipesViewModel>
    {
        private readonly IRecipeDataService _service;
        private readonly IAuthenticator _authenticator;

        public RecipesViewFactory(IRecipeDataService service, IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        }
        public RecipesViewModel CreateViewModel()
        {
            return new RecipesViewModel(_service, _authenticator);
        }
    }
}