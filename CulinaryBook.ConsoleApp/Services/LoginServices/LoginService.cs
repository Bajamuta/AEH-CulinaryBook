using System;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using CulinaryBook.ConsoleApp.Services.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace CulinaryBook.ConsoleApp.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IAuthorDataService _authorService;
        private readonly IPasswordHasher<Author> _hasher;

        public LoginService(IAuthorDataService authorService, 
            IPasswordHasher<Author> hasher)
        {
            _authorService = authorService;
            _hasher = hasher;
        }

        public async Task<Author> Login(string login, string password)
        {
            Author storedAuthor = await _authorService.GetByLogin(login);
            PasswordVerificationResult result = 
                _hasher.VerifyHashedPassword(storedAuthor, storedAuthor.Password, password);

            if (result != PasswordVerificationResult.Success)
            {
                throw new Exception();
            }

            return storedAuthor;
        }

        public async Task<bool> Register(string name, string email, string login, string password, string confirmPassword, string type = "user")
        {
            bool success = false;
            
            if (password == confirmPassword)
            {
                Author author = new Author()
                {
                    Name = name,
                    Login = login,
                    Type = type,
                    Email = email,
                    Description = ""
                };
                author.Password = _hasher.HashPassword(author, password);
                Author authorCreated = await _authorService.Create(author);
                success = authorCreated != null;
            }
            else
            {
                throw new Exception();
            }

            return success;
        }
    }
}