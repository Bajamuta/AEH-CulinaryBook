using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Exceptions;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.AuthorServices;
using Microsoft.AspNetCore.Identity;
using Type = CulinaryBook.ConsoleApp.Models.Type;

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
                throw new InvalidPasswordException(login, password);
            }

            return storedAuthor;
        }

        public async Task<RegistrationResult> Register(string name, string email, string login, 
            string password, string confirmPassword, string description, Type type = Type.User)
        {
            RegistrationResult registrationResult;
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (password == confirmPassword)
            {
                if (await _authorService.GetByLogin(login) != null)
                {
                    registrationResult = RegistrationResult.LoginAlreadyExists;
                }
                else if (await _authorService.GetExactByName(name) != null)
                {
                    registrationResult = RegistrationResult.NameAlreadyExists;
                }
                else if(!regex.IsMatch(email))
                {
                    registrationResult = RegistrationResult.EmailNotValid;
                }
                else
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
                    if (authorCreated != null)
                    {
                        registrationResult = RegistrationResult.Success;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            else
            {
                registrationResult = RegistrationResult.PasswordDoNotMatch;
            }

            return registrationResult;
        }
    }
}