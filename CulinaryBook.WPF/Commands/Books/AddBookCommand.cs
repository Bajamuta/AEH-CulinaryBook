using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Books
{
    public class AddBookCommand : ICommand
    {
        private readonly IBookDataService _service;
        private readonly BooksViewModel _booksViewModel;
        public AddBookCommand(BooksViewModel booksViewModel, IBookDataService service)
        {
            _booksViewModel = booksViewModel;
            _service = service;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await _service.Create(
                    new Book()
                    {
                        Name = _booksViewModel.BookName,
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