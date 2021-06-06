using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;

namespace CulinaryBook.ConsoleApp.Services.CategoryServices
{
    public interface ICategoryDataService
    {
        Task<IEnumerable> GetAll();
        Task<Category> Get(int id);
        Task<Category> GetByName(string name);
        Task<Category> Create(Category entity);
        Task<Category> Update(int id, Category entity);
        Task<bool> Delete(int id);
    }
}