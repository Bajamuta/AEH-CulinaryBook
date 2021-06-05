using System;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.BasicServices
{
    public class BasicServiceWithName<T> : BasicService<T> where T : DbObjectWithName
    {
        private readonly DataAccessWithNameService<T> _service;

        public BasicServiceWithName()
        {
            _service = new DataAccessWithNameService<T>(new CulinaryBookContextFactory());
        }

        public T SearchByName(string name)
        {
            T temp = null;
            try
            {
                // TODO uupercase, spaces etc.
                temp = _service.GetByName(name).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return temp;
        }
    }
}