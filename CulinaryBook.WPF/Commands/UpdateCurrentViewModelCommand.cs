#nullable enable
using System;
using System.Windows.Input;
using CulinaryBook.WPF.State.Navigators;
using CulinaryBook.WPF.ViewModels;

namespace CulinaryBook.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Books:
                        _navigator.CurrentViewModel = new BooksViewModel();
                        break;
                    case ViewType.Categories:
                        _navigator.CurrentViewModel = new CategoriesViewModel();
                        break;
                    case ViewType.Recipes:
                        _navigator.CurrentViewModel = new RecipesViewModel();
                        break;
                    case ViewType.Ingredients:
                        _navigator.CurrentViewModel = new IngredientsViewModel();
                        break;
                    case ViewType.Authors:
                        _navigator.CurrentViewModel = new AuthorsViewModel();
                        break;
                    case ViewType.Login:
                        _navigator.CurrentViewModel = new LoginViewModel();
                        break;
                    case ViewType.Logout:
                        _navigator.CurrentViewModel = new LogoutViewModel();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}