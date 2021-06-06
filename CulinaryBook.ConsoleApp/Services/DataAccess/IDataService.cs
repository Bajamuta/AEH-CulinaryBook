using System.Collections;
using System.Threading.Tasks;

namespace CulinaryBook.ConsoleApp.Services.DataAccess
{
    public interface IDataService<T>
    {
        Task<IEnumerable> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}