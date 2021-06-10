using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Ingredients;
using CulinaryBook.WPF.Commands.Recipes;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class RecipesViewModel : ViewModelBase
    {
        private string _recipeName;
        private string _recipePhoto;
        private List<Recipe> _recipes;
        private Recipe _selectedRecipe;
        public string RecipeName
        {
            get => _recipeName;
            set
            {
                _recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }

        public string RecipePhoto
        {
            get => _recipePhoto;
            set
            {
                _recipePhoto = value;
                OnPropertyChanged(nameof(RecipePhoto));
            }
        }

        public Recipe SelectedRecipe
        {
            get => _selectedRecipe;
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        public List<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public ICommand SearchRecipeCommand { get; }
        public ICommand AddRecipeCommand { get; }
        public ICommand GetAllRecipesCommand { get; }

        public RecipesViewModel(IRecipeDataService recipeDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
               LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchRecipeCommand = new SearchRecipeCommand(this, recipeDataService);
            AddRecipeCommand = new AddRecipeCommand(this, recipeDataService);
            GetAllRecipesCommand = new GetAllRecipesCommand(this, recipeDataService);
        }
    }
}