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
            List<ItemList> items = new List<ItemList>();
            try
            {
                // TODO search by Author
                IEnumerable recipes = await _recipeDataService.GetAllByName(_recipesViewModel.Search);
                
                foreach (Recipe recipe in recipes)
                {
                    items.Add(new ItemList
                    {
                        Title = recipe.Name
                    });
                }
                _recipesViewModel.ItemsList = items;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}