using System;
using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.BasicServices
{
    public class BasicService<T> : IBasicService<T> where T : DbObject
    {
        private readonly IDateService<T> _service;

        public BasicService()
        {
            _service = new DataAccessService<T>(new CulinaryBookContextFactory());
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await _service.Create(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }

        public async Task<bool> Update(int id, T entity)
        {
            try
            {
                await _service.Update(id, entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return true;
        }

        public T Get(int id)
        {
            T temp = null;
            try
            {
                temp = _service.Get(id).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return temp;
        }

        public IEnumerable ShowAll()
        {
            IEnumerable all = null;
            try
            {
                all = _service.GetAll().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return all;
        }
    }
}