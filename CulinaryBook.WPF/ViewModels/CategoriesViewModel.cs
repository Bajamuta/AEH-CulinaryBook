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
        private List<ItemList> _categoriesList;

        public DbObjectWithName Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public List<ItemList> CategoriesList
        {
            get => _categoriesList;
            set
            {
                _categoriesList = value;
                OnPropertyChanged(nameof(CategoriesList));
            }
        }

        public ICommand SearchCategoryCommand { get; set; }

        public CategoriesViewModel(ICategoryDataService categoryDataService)
        {
            SearchCategoryCommand = new SearchCategoryCommand(this, categoryDataService);
            // TODO get all Categorys
            CategoriesList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}