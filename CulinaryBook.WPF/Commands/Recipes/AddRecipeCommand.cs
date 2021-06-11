using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Recipes
{
    public class AddRecipeCommand : ICommand
    {
        private readonly IRecipeDataService _service;
                private readonly RecipesViewModel _recipesViewModel;
                public AddRecipeCommand(RecipesViewModel recipesViewModel, 
                    IRecipeDataService service)
                {
                    _service = service;
                    _recipesViewModel = recipesViewModel;
                }
                public bool CanExecute(object? parameter)
                {
                    return true;
                }
        
                public async void Execute(object? parameter)
                {
                    try
                    {
                        await _service.Create(
                            new Recipe()
                            {
                                Name = _recipesViewModel.RecipeName,
                                Photo = _recipesViewModel.RecipePhoto,
                                Id_Author = _recipesViewModel.LoggedAuthor.ID
                            });
                    }
                    catch (Exception e)
                    {
                        // TODO exception error during create
                        throw new Exception();
                    }
                    
                }

        public event EventHandler? CanExecuteChanged;
    }
}