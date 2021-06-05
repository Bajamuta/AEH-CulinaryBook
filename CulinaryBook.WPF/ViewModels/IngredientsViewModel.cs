using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class IngredientsViewModel : ViewModelBase
    {
        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }

        private DbObjectWithName _ingredient;

        public DbObjectWithName Ingredient
        {
            get => _ingredient;
            set
            {
                _ingredient = value;
                OnPropertyChanged(nameof(Ingredient));
            }
        }

        public ICommand SearchIngredientCommand { get; set; }
    }
}