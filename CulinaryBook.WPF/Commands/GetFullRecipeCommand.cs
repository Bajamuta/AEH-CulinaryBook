using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.ConsoleApp.Services.IngredientsListServices;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.ConsoleApp.Services.RecipesListServices;
using CulinaryBook.ConsoleApp.Services.StepServices;
using CulinaryBook.ConsoleApp.Services.StepsListServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class GetFullRecipeCommand : ICommand
    {
        private readonly ShowtimeViewModel _showtimeViewModel;
        private readonly IAuthorDataService _authorDataService;
        private readonly IRecipesListDataService _recipesListDataService;
        private readonly IIngredientsListDataService _ingredientsListDataService;
        private readonly IRecipeDataService _recipeDataService;
        private readonly IBookDataService _bookDataService;
        private readonly IStepsListDataService _stepsListDataService;
        private readonly ICategoryDataService _categoryDataService;
        private readonly IStepService _stepService;
        private readonly IIngredientDataService _ingredientDataService;

        public GetFullRecipeCommand(ShowtimeViewModel showtimeViewModel, 
            IAuthorDataService authorDataService,
            IRecipesListDataService recipesListDataService, 
            IRecipeDataService recipeDataService, 
            IIngredientsListDataService ingredientsListDataService, 
            IBookDataService bookDataService, 
            IStepsListDataService stepsListDataService, 
            ICategoryDataService categoryDataService, IStepService stepService, 
            IIngredientDataService ingredientDataService)
        {
            _showtimeViewModel = showtimeViewModel;
            _authorDataService = authorDataService;
            _recipesListDataService = recipesListDataService;
            _recipeDataService = recipeDataService;
            _ingredientsListDataService = ingredientsListDataService;
            _bookDataService = bookDataService;
            _stepsListDataService = stepsListDataService;
            _categoryDataService = categoryDataService;
            _stepService = stepService;
            _ingredientDataService = ingredientDataService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            RecipesList selectedRecipeList = await _recipesListDataService.Get(1);
            Recipe recipe = await _recipeDataService.Get(selectedRecipeList.Id_Recipe);
            Book book = await _bookDataService.Get(selectedRecipeList.Id_Book);
            Author author = await _authorDataService.Get(recipe.Id_Author);
            Category category = await _categoryDataService.Get(selectedRecipeList.Id_Category);
            IEnumerable stepsList = await _stepsListDataService.GetByRecipe(recipe);
            IEnumerable ingredientsList = await _ingredientsListDataService.GetByRecipe(recipe);

            try
            {
                _showtimeViewModel.Recipe = recipe;
                _showtimeViewModel.Author = author;
                _showtimeViewModel.Book = book;
                _showtimeViewModel.Category = category;
                _showtimeViewModel.Steps = new List<Step>();
                foreach (StepsList s in stepsList)
                {
                    Step step = await _stepService.Get(s.Id_Step);
                    _showtimeViewModel.Steps.Add(step);
                }

                _showtimeViewModel.Ingredients = new List<Ingredient>();
                foreach (IngredientsList i in ingredientsList)
                {
                    Ingredient ingredient = await _ingredientDataService.Get(i.Id_Ingredient);
                    _showtimeViewModel.Ingredients.Add(ingredient);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public event EventHandler? CanExecuteChanged;
    }
}