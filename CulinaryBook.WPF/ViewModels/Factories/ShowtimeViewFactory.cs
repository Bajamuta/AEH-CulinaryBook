using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.IngredientsListServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.ConsoleApp.Services.RecipesListServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.ConsoleApp.Services.StepsListServices;

namespace CulinaryBook.WPF.ViewModels.Factories
{
    public class ShowtimeViewFactory : IViewModelFactory<ShowtimeViewModel>
    {
        private readonly IRecipesListDataService _recipesListDataService;
        private readonly IAuthorDataService _authorDataService;
        private readonly IIngredientsListDataService _ingredientsListDataService;
        private readonly IRecipeDataService _recipeDataService;
        private readonly IBookDataService _bookDataService;
        private readonly IStepsListDataService _stepsListDataService;
        private readonly ICategoryDataService _categoryDataService;
        private readonly IStepService _stepService;
        private readonly IIngredientDataService _ingredientDataService;

        public ShowtimeViewFactory(
            IAuthorDataService authorDataService,
            IRecipesListDataService recipesListDataService, 
            IIngredientsListDataService ingredientsListDataService, 
            IRecipeDataService recipeDataService, 
            IBookDataService bookDataService, 
            IStepsListDataService stepsListDataService, 
            ICategoryDataService categoryDataService, IStepService stepService, 
            IIngredientDataService ingredientDataService)
        {
            _authorDataService = authorDataService;
            _recipesListDataService = recipesListDataService;
            _ingredientsListDataService = ingredientsListDataService;
            _recipeDataService = recipeDataService;
            _bookDataService = bookDataService;
            _stepsListDataService = stepsListDataService;
            _categoryDataService = categoryDataService;
            _stepService = stepService;
            _ingredientDataService = ingredientDataService;
        }

        public ShowtimeViewModel CreateViewModel()
        {
            return new ShowtimeViewModel(_recipesListDataService,_authorDataService, _recipeDataService, _ingredientsListDataService,
                _bookDataService, _stepsListDataService, _categoryDataService, _stepService, _ingredientDataService);
        }
    }
}