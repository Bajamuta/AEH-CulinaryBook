using System;
using System.Windows.Input;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        public LoginCommand(
            LoginViewModel loginViewModel, IAuthenticator authenticator,
            INavigator navigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _navigator = navigator;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool success = await _authenticator.Login(_loginViewModel.UserLogin, parameter.ToString());
            if (success)
            {
                _loginViewModel.Author = _authenticator.CurrentUser;
            }
            else
            {
                _loginViewModel.LoginResult = "Błąd";
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}