using System.Collections;
using System.Threading.Tasks;

namespace CulinaryBook.ConsoleApp.Services.AuthorServices
{
    public interface IAuthorDataService
    {
        Task<IEnumerable> GetAll();
        Task<Author> Get(int id);
        Task<Author> GetByName(string name);
        Task<Author> GetByLogin(string login);
        Task<Author> Create(Author entity);
        Task<Author> Update(int id, Author entity);
        Task<bool> Delete(int id);
    }
}