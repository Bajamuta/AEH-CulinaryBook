using System;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;

namespace CulinaryBook.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly ILoginService _loginService;

        public Authenticator(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public Author CurrentUser { get; private set; }
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