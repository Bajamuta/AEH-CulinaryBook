using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.RecipesListServices;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class GetListRecipeCommand : ICommand
    {
        private readonly IRecipesListDataService _service;
        private readonly ShowtimeViewModel _showtimeViewModel;
        public GetListRecipeCommand(ShowtimeViewModel showtimeViewModel, 
            IRecipesListDataService service)
        {
            _showtimeViewModel = showtimeViewModel;
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
                IEnumerable recipes = await _service.GetAll();
                _showtimeViewModel.RecipesLists = new List<RecipesList>();
                foreach (RecipesList r in recipes)
                {
                    _showtimeViewModel.RecipesLists.Add(r);
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}