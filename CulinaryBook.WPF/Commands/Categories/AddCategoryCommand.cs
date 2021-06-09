using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Categories
{
    public class AddCategoryCommand : ICommand
    {
        private readonly ICategoryDataService _service;
        private readonly CategoriesViewModel _categoriesViewModel;
        public AddCategoryCommand(CategoriesViewModel categoriesViewModel, ICategoryDataService service)
        {
            _categoriesViewModel = categoriesViewModel;
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
                    new Category()
                    {
                        Name = _categoriesViewModel.CategoryName,
                        Description = _categoriesViewModel.CategoryDescription
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