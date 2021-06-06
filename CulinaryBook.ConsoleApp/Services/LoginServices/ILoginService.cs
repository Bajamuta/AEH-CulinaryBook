using System.Threading.Tasks;

namespace CulinaryBook.ConsoleApp.Services.LoginServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        EmailAlreadyExists,
        LoginAlreadyExists,
        NameAlreadyExists
    }
    public interface ILoginService
    {
        public Task<Author> Login(string login, string password);
        public Task<RegistrationResult> Register(string name, string email, string login, string password, string confirmPassword, string type);
    }
}