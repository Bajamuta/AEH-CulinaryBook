using System;
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
            List<ItemList> items = new List<ItemList>();
            try
            {
                DbObjectWithName book = await _bookDataService.GetByName(_booksViewModel.Search);
                _booksViewModel.Book = book;
                items.Add(new ItemList
                {
                    Title = book.Name,
                    RecipeCount = "(" + 2 + ")"
                });
                _booksViewModel.BooksList = items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}