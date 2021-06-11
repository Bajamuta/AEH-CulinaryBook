using System.Windows.Input;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class LoginViewFactory : IViewModelFactory<LoginViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginViewFactory(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        } 
        public LoginViewModel CreateViewModel()
        {
            return new LoginViewModel(_authenticator, _renavigator);
        }
    }
}