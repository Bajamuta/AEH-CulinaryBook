using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class AuthorsViewFactory : IViewModelFactory<AuthorsViewModel>
    {
        private readonly IAuthorDataService _service;
        private readonly IAuthenticator _authenticator;

        public AuthorsViewFactory(IAuthorDataService service, 
            IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
        }
        public AuthorsViewModel CreateViewModel()
        {
            return new AuthorsViewModel(_service, _authenticator);
        }
    }
}