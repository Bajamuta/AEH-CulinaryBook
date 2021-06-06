using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly ILoginService _loginService;
        
        public LoginCommand(
            LoginViewModel loginViewModel, 
            ILoginService loginService)
        {
            _loginViewModel = loginViewModel;
            _loginService = loginService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                Author loggedAuthor = await _loginService.Login("porzadny", "P@$$w0rd");
                if (loggedAuthor != null)
                {
                    _loginViewModel.Author = loggedAuthor;
                    _loginViewModel.LoginResult = "You have been logged, " + loggedAuthor.Name;
                }
                else
                {
                    // TODO create Exception for failed login
                    _loginViewModel.LoginResult = "Error occured when logging";
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}