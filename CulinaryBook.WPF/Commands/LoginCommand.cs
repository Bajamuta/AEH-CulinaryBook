using System;
using System.Windows.Input;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        
        public LoginCommand(
            LoginViewModel loginViewModel, IAuthenticator authenticator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
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
                _loginViewModel.LoginResult = "Zalogowany";
            }
            else
            {
                _loginViewModel.LoginResult = "Błąd";
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}