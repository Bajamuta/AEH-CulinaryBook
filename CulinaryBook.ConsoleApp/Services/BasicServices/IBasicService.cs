using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.BasicServices
{
    public interface IBasicService<T> where T : DbObject
    {
        Task<bool> Add(T entity);
        Task<bool> Remove(int id);
        Task<bool> Update(int id, T entity);
        T Get(int id);
        IEnumerable ShowAll();
    }
}