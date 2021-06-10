using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Categories
{
    public class GetAllCategoriesCommand : ICommand
    {
        private readonly ICategoryDataService _service;
        private readonly CategoriesViewModel _categoriesViewModel;
        public GetAllCategoriesCommand(CategoriesViewModel categoriesViewModel, ICategoryDataService service)
        {
            _service = service;
            _categoriesViewModel = categoriesViewModel;
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
                    _categoriesViewModel.ItemsList = new List<ItemList>();
                    foreach (Category item in items)
                    {
                        _categoriesViewModel.ItemsList.Add(
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