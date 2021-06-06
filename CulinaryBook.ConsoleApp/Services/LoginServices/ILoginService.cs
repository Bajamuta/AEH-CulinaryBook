using System.Threading.Tasks;

namespace CulinaryBook.ConsoleApp.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<Author> Login(string login, string password);
        public Task<bool> Register(string name, string email, string login, string password, string confirmPassword, string type);
    }
}