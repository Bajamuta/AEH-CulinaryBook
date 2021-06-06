using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.BookServices
{
    public interface IBookDataService
    {
        Task<IEnumerable> GetAll();
        Task<Book> Get(int id);
        Task<IEnumerable> GetByName(string name);
        Task<Book> Create(Book entity);
        Task<Book> Update(int id, Book entity);
        Task<bool> Delete(int id);
    }
}