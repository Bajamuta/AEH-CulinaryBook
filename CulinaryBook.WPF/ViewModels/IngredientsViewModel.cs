using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class IngredientsViewModel : ViewModelBase
    {
        private DbObjectWithName _ingredient;
        private List<ItemList> _ingredientsList;

        public DbObjectWithName Ingredient
        {
            get => _ingredient;
            set
            {
                _ingredient = value;
                OnPropertyChanged(nameof(Ingredient));
            }
        }

        public List<ItemList> IngredientsList
        {
            get => _ingredientsList;
            set
            {
                _ingredientsList = value;
                OnPropertyChanged(nameof(IngredientsList));
            }
        }

        public ICommand SearchIngredientCommand { get; set; }

        public IngredientsViewModel(IIngredientDataService ingredientDataService)
        {
            SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
            // TODO get all ingredients
            IngredientsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}