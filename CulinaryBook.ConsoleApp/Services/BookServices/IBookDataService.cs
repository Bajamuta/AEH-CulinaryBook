using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.BookServices
{
    public interface IBookDataService : IDataService<Book>
    {
        Task<IEnumerable> GetAllByName(string name);
    }
}