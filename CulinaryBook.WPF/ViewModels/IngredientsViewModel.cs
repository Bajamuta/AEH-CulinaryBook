using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Ingredients;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class IngredientsViewModel : ViewModelBase
    {
        private string _ingredientName;
        private string _ingredientJunit;
        
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

        public ICommand SearchIngredientCommand { get; }
        public ICommand AddIngredientCommand { get; }

        public IngredientsViewModel(IIngredientDataService ingredientDataService)
        {
            SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
            AddIngredientCommand = new AddIngredientCommand(this, ingredientDataService);
            // TODO get all ingredients
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}