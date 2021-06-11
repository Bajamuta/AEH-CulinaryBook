using System;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.Models;
using CulinaryBook.WPF.State.Accounts;
using Type = CulinaryBook.ConsoleApp.Models.Type;

namespace CulinaryBook.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly ILoginService _loginService;
        private readonly IAccountStore _accountStore;
        public Authenticator(ILoginService loginService, IAccountStore accountStore)
        {
            _loginService = loginService;
            _accountStore = accountStore;
        }

        public Author CurrentUser
        {
            get => _accountStore.CurrentAccount;
            private set
            {
                _accountStore.CurrentAccount = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;
        
        public async Task<RegistrationResult> Register(string name, string email, string login, string password, string confirmPassword, string description, Type type)
        {
            return await _loginService.Register(name, email, login, password, confirmPassword, description, type);
        }

        public async Task<bool> Login(string userLogin, string userPassword)
        {
            bool success = true;
            try
            {
                CurrentUser = await _loginService.Login(userLogin, userPassword);
            }
            catch (Exception e)
            {
                // TODO error handling lost connection with database
                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}