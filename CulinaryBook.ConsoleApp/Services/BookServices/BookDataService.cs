using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.BookServices
{
    public class BookDataService : IBookDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessWithNameService<Book> _service;

        public BookDataService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _service = new DataAccessWithNameService<Book>(contextFactory);
            
        }
        
        public Task<IEnumerable> GetAll()
        {
            return _service.GetAll();
        }

        public Task<Book> Get(int id)
        {
            return _service.Get(id);
        }

        public Task<Book> GetByName(string name)
        {
            return _service.GetByName(name);
        }

        public Task<Book> Create(Book entity)
        {
            return _service.Create(entity);
        }

        public Task<Book> Update(int id, Book entity)
        {
            return _service.Update(id, entity);
        }

        public Task<bool> Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}