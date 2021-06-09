using System;
using System.Windows.Input;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;

        public LogoutCommand(IAuthenticator authenticator, INavigator navigator)
        {
            _navigator = navigator;
            _authenticator = authenticator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                _authenticator.Logout();
                _navigator.CurrentViewModel = new LogoutViewModel();
            }
            catch (Exception e)
            {
                // TODO logout exception
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}