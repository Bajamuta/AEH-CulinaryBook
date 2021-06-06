using System.Windows.Input;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.Commands;

namespace CulinaryBook.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _loginResult;
        private Author _author;

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

        public ICommand LoginCommand { get; set; }
        
        public LoginViewModel(ILoginService loginService)
        {
            //SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
            LoginCommand = new LoginCommand(this, loginService);
        }
    }
}