using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class SearchCategoryCommand : ICommand
    {
        private readonly CategoriesViewModel _categoriesViewModel;
        private readonly ICategoryDataService _categoryDataService;
        
        public SearchCategoryCommand(
            CategoriesViewModel categoriesViewModel, 
            ICategoryDataService categoryDataService)
        {
            _categoriesViewModel = categoriesViewModel;
            _categoryDataService = categoryDataService;
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
                IEnumerable categories = await _categoryDataService.GetByName(_categoriesViewModel.Search);
                foreach (Category category in categories)
                {
                    items.Add(new ItemList
                    {
                        Title = category.Name,
                        RecipeCount = "(" + 2 + ")"
                    });
                }
                _categoriesViewModel.CategoriesList = items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}