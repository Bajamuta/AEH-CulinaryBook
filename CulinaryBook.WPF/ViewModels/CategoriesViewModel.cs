using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.CategoryServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private DbObjectWithName _category;

        public DbObjectWithName Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public ICommand SearchCategoryCommand { get; set; }

        public CategoriesViewModel(ICategoryDataService categoryDataService)
        {
            SearchCategoryCommand = new SearchCategoryCommand(this, categoryDataService);
            // TODO get all Categorys
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}