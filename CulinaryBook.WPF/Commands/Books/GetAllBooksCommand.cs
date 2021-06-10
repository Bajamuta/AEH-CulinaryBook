using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Books
{
    public class GetAllBooksCommand : ICommand
    {
        private readonly IBookDataService _service;
        private readonly BooksViewModel _booksViewModel;
        public GetAllBooksCommand(BooksViewModel booksViewModel, IBookDataService service)
        {
            _service = service;
            _booksViewModel = booksViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                IEnumerable items = await _service.GetAll();
                if (items != null)
                {
                    _booksViewModel.ItemsList = new List<ItemList>();
                    foreach (Book item in items)
                    {
                        _booksViewModel.ItemsList.Add(
                            new ItemList()
                            {
                                Title = item.Name,
                                RecipeCount = "(3)"
                            });
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}