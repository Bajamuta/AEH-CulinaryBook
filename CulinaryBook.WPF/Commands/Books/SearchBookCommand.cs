using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class SearchBookCommand : ICommand
    {
        private readonly BooksViewModel _booksViewModel;
        private readonly IBookDataService _bookDataService;
        
        public SearchBookCommand(
            BooksViewModel booksViewModel, 
            IBookDataService bookDataService)
        {
            _booksViewModel = booksViewModel;
            _bookDataService = bookDataService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            List<Book> items = new List<Book>();
            try
            {
                IEnumerable books = await _bookDataService.GetAllByName(_booksViewModel.Search);
                if (books != null)
                {
                    _booksViewModel.Books = new List<Book>();
                    foreach (Book book in books)
                    {
                        _booksViewModel.Books.Add(book);
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}