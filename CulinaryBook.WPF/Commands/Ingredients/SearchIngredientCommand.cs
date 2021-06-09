using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
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
            List<ItemList> items = new List<ItemList>();
            try
            {
                IEnumerable ingredients = await _ingredientDataService.GetAllByName(_ingredientsViewModel.Search);
                
                foreach (Ingredient ingredient in ingredients)
                {
                    items.Add(new ItemList
                    {
                        Title = ingredient.Name,
                        RecipeCount = "(" + 2 + ")"
                    });
                }
                _ingredientsViewModel.ItemsList = items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}