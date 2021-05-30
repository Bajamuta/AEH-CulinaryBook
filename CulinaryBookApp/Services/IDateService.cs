using System.Collections;
using System.Threading.Tasks;

namespace CulinaryBookApp.Services
{
    public interface IDateService<T>
    {
        Task<IEnumerable> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}