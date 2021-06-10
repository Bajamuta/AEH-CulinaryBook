using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.AuthorServices
{
    public interface IAuthorDataService : IDataService<Author>
    {
        Task<IEnumerable> GetAllByName(string name);
        Task<Author> GetExactByName(string name);
        Task<Author> GetByLogin(string login);
    }
}