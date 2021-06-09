using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        private DbObjectWithName _book;
        public DbObjectWithName Book
        {
            get => _book;
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public ICommand SearchBookCommand { get; set; }

        public BooksViewModel(IBookDataService bookDataService)
        {
            SearchBookCommand = new SearchBookCommand(this, bookDataService);
            // TODO get all books
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}