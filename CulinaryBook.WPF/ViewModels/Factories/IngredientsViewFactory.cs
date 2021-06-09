using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class IngredientsViewFactory : IViewModelFactory<IngredientsViewModel>
    {
        private readonly IIngredientDataService _service;
        private readonly IAuthenticator _authenticator;

        public IngredientsViewFactory(IIngredientDataService service,
            IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        }

        public IngredientsViewModel CreateViewModel()
        {
            return new IngredientsViewModel(_service, _authenticator);
        }
    }
}