using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Recipes
{
    public class AddSelectedIngredientCommand : ICommand
    {
        private readonly RecipesViewModel _recipesViewModel;
        public AddSelectedIngredientCommand(RecipesViewModel recipesViewModel)
        {
            _recipesViewModel = recipesViewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Ingredient ingredient = _recipesViewModel.SelectedIngredient;
            if (ingredient != null)
            {
                _recipesViewModel.RecipeIngredients.Add(ingredient);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}