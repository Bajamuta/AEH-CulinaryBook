using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.StepsListServices
{
    public interface IStepsListDataService : IDataService<StepsList>
    {
        public Task<IEnumerable> GetByRecipe(Recipe recipe);
        public Task<IEnumerable> GetByStep(Step step);
    }
}