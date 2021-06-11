using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class CategoriesViewFactory : IViewModelFactory<CategoriesViewModel>
    {
        private readonly ICategoryDataService _service;
        private readonly IAuthenticator _authenticator;

        public CategoriesViewFactory(ICategoryDataService service, 
            IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        } 
        public CategoriesViewModel CreateViewModel()
        {
            return new CategoriesViewModel(_service, _authenticator);
        }
    }
}