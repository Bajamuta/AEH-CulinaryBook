using System;
using System.Runtime.Serialization;

namespace CulinaryBook.ConsoleApp.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public string UserLogin { get; }
        public string UserPassword { get; }
        
        public InvalidPasswordException(string userPassword, string userLogin)
        {
            UserPassword = userPassword;
            UserLogin = userLogin;
        }

        public InvalidPasswordException(string? message, string userPassword, string userLogin) : base(message)
        {
            UserPassword = userPassword;
            UserLogin = userLogin;
        }

        public InvalidPasswordException(string? message, Exception? innerException, string userPassword, string userLogin) : base(message, innerException)
        {
            UserPassword = userPassword;
            UserLogin = userLogin;
        }
    }
}