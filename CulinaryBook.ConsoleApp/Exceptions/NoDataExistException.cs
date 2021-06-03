using System;
using System.Runtime.Serialization;

namespace CulinaryBook.ConsoleApp.Exceptions
{
    public class NoDataExistException : Exception
    {
        public int Id;
        public NoDataExistException(int id)
        {
            Id = id;
        }

        public NoDataExistException(int id, string? message) : base(message)
        {
            Id = id;
        }

        public NoDataExistException(int id, string? message, Exception? innerException) : base(message, innerException)
        {
            Id = id;
        }
    }
}