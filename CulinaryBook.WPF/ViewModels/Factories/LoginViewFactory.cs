using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LoginViewFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;

        public LoginViewFactory(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        } 
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator);
        }
    }
}