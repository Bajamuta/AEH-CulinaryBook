using System;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;
using CulinaryBook.WPF.Models;

namespace CulinaryBook.WPF.State.Authenticators
{
    public class Authenticator : ObservableObject, IAuthenticator
    {
        private readonly ILoginService _loginService;
        private Author _currentUser;

        public Authenticator(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public Author CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;
        
        public async Task<RegistrationResult> Register(string name, string email, string login, string password, string confirmPassword)
        {
            return await _loginService.Register(name, email, login, password, confirmPassword, "user");
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