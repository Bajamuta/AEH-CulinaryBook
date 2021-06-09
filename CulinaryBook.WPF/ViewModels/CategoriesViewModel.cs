using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Categories;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private string _categoryName;
        private string _categoryDescription;

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public string CategoryDescription
        {
            get => _categoryDescription;
            set
            {
                _categoryDescription = value;
                OnPropertyChanged(nameof(CategoryDescription));
            }
        }
        public ICommand SearchCategoryCommand { get; }
        public ICommand AddCategoryCommand { get; }

        public CategoriesViewModel(ICategoryDataService categoryDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchCategoryCommand = new SearchCategoryCommand(this, categoryDataService);
            AddCategoryCommand = new AddCategoryCommand(this, categoryDataService);
            // TODO get all Categorys
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}