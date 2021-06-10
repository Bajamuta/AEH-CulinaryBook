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
        private Ingredient _selectedIngredient;
        private List<Ingredient> _ingredients;
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

        public Ingredient SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }

        public List<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }
        
        public ICommand SearchIngredientCommand { get; }
        public ICommand AddIngredientCommand { get; }
        public ICommand GetAllIngredientsCommand { get; }

        public IngredientsViewModel(IIngredientDataService ingredientDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
            AddIngredientCommand = new AddIngredientCommand(this, ingredientDataService);
            GetAllIngredientsCommand = new GetAllIngredientsCommand(this, ingredientDataService);
        }
    }
}