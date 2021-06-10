using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.ViewModels;
using Type = CulinaryBook.ConsoleApp.Models.Type;

namespace CulinaryBook.WPF.Commands.Authors
{
    public class AddAuthorCommand : ICommand
    {
        private readonly IAuthorDataService _service;
        private readonly AuthorsViewModel _authorsViewModel;
        private readonly IAuthenticator _authenticator;
        public AddAuthorCommand(AuthorsViewModel authorsViewModel, IAuthorDataService service,
        IAuthenticator authenticator)
        {
            _service = service;
            _authenticator = authenticator;
            _authorsViewModel = authorsViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            string name = _authorsViewModel.AuthorName;
            string login = _authorsViewModel.AuthorLogin;
            Type type = _authorsViewModel.AuthorType;
            string password = _authorsViewModel.AuthorPassword;
            // TODO confirm password
            string email = _authorsViewModel.AuthorEmail;
            string description = _authorsViewModel.AuthorDescription;
            try
            {
                await _authenticator.Register(name, email, login, password, password, description, type);
            }
            catch (Exception e)
            {
                // TODO exception error during create
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}