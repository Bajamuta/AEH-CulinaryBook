using System;
using System.Windows.Input;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;
using CulinaryBook.WPF.ViewModels.Factories;

namespace CulinaryBook.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        public LoginCommand(
            LoginViewModel loginViewModel, IAuthenticator authenticator, 
            IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
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
                // TODO if needed to add sth #16 9:20
                _renavigator.Renavigate();
            }
            else
            {
                _loginViewModel.LoginResult = "Błąd";
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}