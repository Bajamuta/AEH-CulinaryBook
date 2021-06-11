using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Ingredients
{
    public class SearchIngredientCommand : ICommand
    {
        private readonly IngredientsViewModel _ingredientsViewModel;
        private readonly IIngredientDataService _ingredientDataService;
        
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
            List<Ingredient> items = new List<Ingredient>();
            try
            {
                IEnumerable ingredients = await _ingredientDataService.GetAllByName(_ingredientsViewModel.Search);

                if (ingredients != null)
                {
                    _ingredientsViewModel.Ingredients = new List<Ingredient>();
                    foreach (Ingredient ingredient in ingredients)
                    {
                        _ingredientsViewModel.Ingredients.Add(ingredient);
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