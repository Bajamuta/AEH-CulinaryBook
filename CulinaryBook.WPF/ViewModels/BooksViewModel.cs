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
        private List<ItemList> _booksList;

        public DbObjectWithName Book
        {
            get => _book;
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
            }
        }

        public List<ItemList> BooksList
        {
            get => _booksList;
            set
            {
                _booksList = value;
                OnPropertyChanged(nameof(BooksList));
            }
        }

        public ICommand SearchBookCommand { get; set; }

        public BooksViewModel(IBookDataService bookDataService)
        {
            SearchBookCommand = new SearchBookCommand(this, bookDataService);
            // TODO get all books
            BooksList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}