using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;

namespace CulinaryBook.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Author _author;
        
        public string LoginResult { get; set; }
        
        
        public LoginViewModel(ILoginService loginService)
        {
            //SearchIngredientCommand = new SearchIngredientCommand(this, ingredientDataService);
        }
    }
}