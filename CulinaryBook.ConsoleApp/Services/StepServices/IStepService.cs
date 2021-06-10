using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.StepServices
{
    public interface IStepService : IDataService<Step>
    {
        Task<IEnumerable> GetAllByText(string text);
    }
}