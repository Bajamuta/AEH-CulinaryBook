using System.Windows.Input;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LoginViewFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;

        public LoginViewFactory(IAuthenticator authenticator, INavigator navigator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
        } 
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator, _navigator);
        }
    }
}