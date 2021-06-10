using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.RecipeServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands.Recipes
{
    public class GetAllRecipesCommand : ICommand
    {
        private readonly IRecipeDataService _service;
        private readonly RecipesViewModel _recipesViewModel;
        public GetAllRecipesCommand(RecipesViewModel recipesViewModel, IRecipeDataService service)
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
                if (items != null)
                {
                    _recipesViewModel.ItemsList = new List<ItemList>();
                    foreach (Recipe item in items)
                    {
                        _recipesViewModel.ItemsList.Add(
                            new ItemList()
                            {
                                Title = item.Name,
                                RecipeCount = "(3)"
                            });
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