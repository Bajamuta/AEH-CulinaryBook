using System;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Ingredients
{
    public class AddIngredientCommand : ICommand
    {
        private readonly IIngredientDataService _service;
        private readonly IngredientsViewModel _ingredientsViewModel;
        public AddIngredientCommand(IngredientsViewModel ingredientsViewModel, IIngredientDataService service)
        {
            _service = service;
            _ingredientsViewModel = ingredientsViewModel;
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
                    new Ingredient()
                    {
                        Name = _ingredientsViewModel.IngredientName,
                        Junit = _ingredientsViewModel.IngredientJunit
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