using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.IngredientsListServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.ConsoleApp.Services.RecipesListServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.ConsoleApp.Services.StepsListServices;
using CulinaryBook.WPF.Commands;

namespace CulinaryBook.WPF.ViewModels
{
    public class ShowtimeViewModel : ViewModelBase
    {
        private Recipe _recipe;
        private Book _book;
        private Category _category;
        private List<Ingredient> _ingredients;
        private List<Step> _steps;

        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(ConsoleApp.Models.Recipe));
            }
        }

        public Book Book
        {
            get => _book;
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public List<Step> Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
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
        
        public ICommand GetFullRecipeCommand { get; }

        public ShowtimeViewModel(IRecipesListDataService recipesListDataService,
            IRecipeDataService recipeDataService, IIngredientsListDataService ingredientsListDataService,
            IBookDataService bookDataService, IStepsListDataService stepsListDataService,
            ICategoryDataService categoryDataService, IStepService stepService, 
            IIngredientDataService ingredientDataService)
        {
            GetFullRecipeCommand = new GetFullRecipeCommand(this, recipesListDataService,
                recipeDataService, ingredientsListDataService, bookDataService, stepsListDataService, categoryDataService,
                stepService, ingredientDataService);
        }
    }
}