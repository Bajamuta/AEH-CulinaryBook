using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.BookServices;
using CulinaryBook.ConsoleApp.Services.IngredientServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Books;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class BooksViewModel : ViewModelBase
    {
        private string _bookName;
        private Book _selectedBook;
        private List<Book> _books;

        public string BookName
        {
            get => _bookName;
            set
            {
                _bookName = value;
                OnPropertyChanged(nameof(BookName));
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        public List<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        
        public ICommand SearchBookCommand { get; }
        public ICommand AddBookCommand { get; }
        public ICommand GetAllBooksCommand { get; }

        public BooksViewModel(IBookDataService bookDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchBookCommand = new SearchBookCommand(this, bookDataService);
            AddBookCommand = new AddBookCommand(this, bookDataService);
            GetAllBooksCommand = new GetAllBooksCommand(this, bookDataService);
        }
    }
}