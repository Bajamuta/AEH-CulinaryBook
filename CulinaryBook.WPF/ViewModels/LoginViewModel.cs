using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.Commands;
using CulinaryBook.WPF.State.Authenticators;
using CulinaryBook.WPF.State.Navigators;

namespace CulinaryBook.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _loginResult;
        private Author _author;
        private string _userLogin;

        public Author Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public string LoginResult
        {
            get => _loginResult;
            set
            {
                _loginResult = value;
                OnPropertyChanged(nameof(LoginResult));
            }
        }

        public string UserLogin
        {
            get => _userLogin;
            set
            {
                _userLogin = value;
                OnPropertyChanged(nameof(UserLogin));
            }
        }

        public ICommand LoginCommand { get; }
        
        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }
    }
}