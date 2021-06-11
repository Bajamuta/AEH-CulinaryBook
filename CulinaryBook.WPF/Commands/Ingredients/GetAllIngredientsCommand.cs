using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Ingredients
{
    public class GetAllIngredientsCommand : ICommand
    {
        private readonly IIngredientDataService _service;
        private readonly IngredientsViewModel _ingredientsViewModel;
        public GetAllIngredientsCommand(IngredientsViewModel ingredientsViewModel, IIngredientDataService service)
        {
            _ingredientsViewModel = ingredientsViewModel;
            _service = service;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                IEnumerable items = await _service.GetAll();
                if (items != null)
                {
                    _ingredientsViewModel.Ingredients = new List<Ingredient>();
                    foreach (Ingredient item in items)
                    {
                        _ingredientsViewModel.Ingredients.Add(item);
                    }
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