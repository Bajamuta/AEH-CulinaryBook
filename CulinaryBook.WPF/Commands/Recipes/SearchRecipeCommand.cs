using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Recipes
{
    public class SearchRecipeCommand : ICommand
    {
        private readonly RecipesViewModel _recipesViewModel;
        private readonly IRecipeDataService _recipeDataService;
        
        public SearchRecipeCommand(
            RecipesViewModel recipesViewModel, 
            IRecipeDataService recipeDataService)
        {
            _recipesViewModel = recipesViewModel;
            _recipeDataService = recipeDataService;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            List<Recipe> items = new List<Recipe>();
            try
            {
                // TODO search by Author
                IEnumerable recipes = await _recipeDataService.GetAllByName(_recipesViewModel.Search);
                if (recipes != null)
                {
                    _recipesViewModel.Recipes = new List<Recipe>();
                    foreach (Recipe recipe in recipes)
                    {
                        _recipesViewModel.Recipes.Add(recipe);
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