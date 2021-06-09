using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class AuthorsViewModel : ViewModelBase
    {
        private DbObjectWithName _author;

        public DbObjectWithName Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public ICommand SearchAuthorCommand { get; set; }

        public AuthorsViewModel(IAuthorDataService authorDataService)
        {
            SearchAuthorCommand = new SearchAuthorCommand(this, authorDataService);
            // TODO get all Authors
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}