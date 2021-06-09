using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Ingredients;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class IngredientsViewModel : ViewModelBase
    {
        private string _ingredientName;
        private string _ingredientJunit;
        private Author _recipeAuthor;
        
        public string IngredientName
        {
            get => _ingredientName;
            set
            {
                _ingredientName = value;
                OnPropertyChanged(nameof(IngredientName));
            }
        }

        public string IngredientJunit
        {
            get => _ingredientJunit;
            set
            {
                _ingredientJunit = value;
                OnPropertyChanged(nameof(IngredientJunit));
            }
        }
        
        public Author RecipeAuthor
        {
            get => _recipeAuthor;
            set
            {
                _recipeAuthor = value;
                OnPropertyChanged(nameof(RecipeAuthor));
                OnPropertyChanged(nameof(IsLogged));
            }
        }

        public bool IsLogged => RecipeAuthor != null;

        public ICommand SearchIngredientCommand { get; }
        public ICommand AddIngredientCommand { get; }

        public IngredientsViewModel(IIngredientDataService ingredientDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                RecipeAuthor = authenticator.CurrentUser; 
            }
            SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
            AddIngredientCommand = new AddIngredientCommand(this, ingredientDataService);
            // TODO get all ingredients
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}