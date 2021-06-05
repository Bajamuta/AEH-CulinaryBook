using System;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class SearchIngredientCommand : ICommand
    {
        private IngredientsViewModel _ingredientsViewModel;
        private IIngredientDataService _ingredientDataService;
        
        public SearchIngredientCommand(
            IngredientsViewModel ingredientsViewModel, 
            IIngredientDataService ingredientDataService)
        {
            _ingredientsViewModel = ingredientsViewModel;
            _ingredientDataService = ingredientDataService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                DbObjectWithName ingredient = await _ingredientDataService.GetByName(_ingredientsViewModel.Search);
                _ingredientsViewModel.Ingredient = ingredient;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}