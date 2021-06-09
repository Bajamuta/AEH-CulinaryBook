using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class AddAuthorCommand : ICommand
    {
        private readonly IAuthorDataService _service;
        private AuthorsViewModel _authorsViewModel;
        public AddAuthorCommand(AuthorsViewModel authorsViewModel, IAuthorDataService service)
        {
            _service = service;
            _authorsViewModel = authorsViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            // TODO hash password!
            try
            {
                await _service.Create(
                    new Author()
                    {
                        Name = _authorsViewModel.AuthorName,
                        Type = _authorsViewModel.AuthorType,
                        Login = _authorsViewModel.AuthorLogin,
                        Password = _authorsViewModel.AuthorPassword,
                        Email = _authorsViewModel.AuthorEmail,
                        Description = _authorsViewModel.AuthorDescription
                    });
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