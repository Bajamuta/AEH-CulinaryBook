using System.Collections.Generic;
using System.Windows.Input;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.Commands.Authors;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Authenticators;

namespace CulinaryBook.WPF.ViewModels
{
    public class AuthorsViewModel : ViewModelBase
    {
        private string _authorName;
        private string _authorType;
        private string _authorLogin;
        private string _authorPassword;
        private string _authorEmail;
        private string _authorDescription;
        private string _loggedTypeUser;

        public string AuthorName
        {
            get => _authorName;
            set
            {
                _authorName = value;
                OnPropertyChanged(nameof(AuthorName));
            }
        }

        public string AuthorLogin
        {
            get => _authorLogin;
            set
            {
                _authorLogin = value;
                OnPropertyChanged(nameof(AuthorLogin));
            }
        }

        public string AuthorPassword
        {
            get => _authorPassword;
            set
            {
                // TODO change to getProperty
                _authorPassword = value;
                OnPropertyChanged(nameof(AuthorPassword));
            }
        }

        public string AuthorType
        {
            get => _authorType;
            set
            {
                _authorType = value;
                OnPropertyChanged(nameof(AuthorType));
            }
        }

        public string AuthorDescription
        {
            get => _authorDescription;
            set
            {
                _authorDescription = value;
                OnPropertyChanged(nameof(AuthorDescription));
            }
        }

        public string AuthorEmail
        {
            get => _authorEmail;
            set
            {
                _authorEmail = value;
                OnPropertyChanged(AuthorEmail);
            }
        }

        public string LoggedTypeUser => LoggedAuthor.Type;

        public ICommand SearchAuthorCommand { get; }
        public ICommand AddAuthorCommand { get; }

        public AuthorsViewModel(IAuthorDataService authorDataService, IAuthenticator authenticator)
        {
            if (authenticator.CurrentUser != null)
            {
                LoggedAuthor = authenticator.CurrentUser; 
            }
            SearchAuthorCommand = new SearchAuthorCommand(this, authorDataService);
            AddAuthorCommand = new AddAuthorCommand(this, authorDataService);
            // TODO get all Authors
            ItemsList = new List<ItemList> {new ItemList {Title = "none", RecipeCount = "(0)"}};
        }
    }
}