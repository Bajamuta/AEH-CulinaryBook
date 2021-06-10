using System.Collections.Generic;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string _search;
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