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
        private Category _selectedCategory;
        private List<Category> _categories;

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

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public List<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ICommand SearchCategoryCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand GetAllCategoriesCommand { get; }

        public CategoriesViewModel(ICategoryDataService categoryDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchCategoryCommand = new SearchCategoryCommand(this, categoryDataService);
            AddCategoryCommand = new AddCategoryCommand(this, categoryDataService);
            GetAllCategoriesCommand = new GetAllCategoriesCommand(this, categoryDataService);
        }
    }
}