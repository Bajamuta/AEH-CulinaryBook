using System.Threading.Tasks;
using CulinaryBook.ConsoleApp;
using CulinaryBook.ConsoleApp.Services.LoginServices;

namespace CulinaryBook.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Author CurrentUser { get; }
        bool IsLoggedIn { get; }
        
        Task<RegistrationResult> Register(string name, string email, string login, string password,
            string confirmPassword);

        Task<bool> Login(string userLogin, string userPassword);
        void Logout();
    }
}