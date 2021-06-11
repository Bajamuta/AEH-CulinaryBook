using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.CategoryServices
{
    public interface ICategoryDataService : IDataService<Category>
    {
        Task<IEnumerable> GetAllByName(string name);
    }
}