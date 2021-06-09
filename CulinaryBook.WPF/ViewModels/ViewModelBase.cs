using System.Collections.Generic;
using CulinaryBook.ConsoleApp;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string _search;
        private List<ItemList> _items;
        private Author _loggedAuthor;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
        
        public List<ItemList> ItemsList
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(ItemsList));
            }
        }
        
        public Author LoggedAuthor
        {
            get => _loggedAuthor;
            set
            {
                _loggedAuthor = value;
                OnPropertyChanged(nameof(LoggedAuthor));
                OnPropertyChanged(nameof(IsLogged));
            }
        }

        public bool IsLogged => LoggedAuthor != null;
    }
}