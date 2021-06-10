using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Recipes
{
    public class GetListOfIngredientsCommand : ICommand
    {
        private readonly IIngredientDataService _service;
        private readonly RecipesViewModel _recipesViewModel;
        public GetListOfIngredientsCommand(RecipesViewModel recipesViewModel, IIngredientDataService service)
        {
            _recipesViewModel = recipesViewModel;
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
                _recipesViewModel.AllIngredients = new List<Ingredient>();
                if (items != null)
                {
                    foreach (Ingredient item in items)
                    {
                        _recipesViewModel.AllIngredients.Add(item);
                    }
                }
                else
                {
                    _recipesViewModel.AllIngredients.Add(
                        new Ingredient()
                        {
                            Name = "no data",
                            Junit = ""
                        });
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