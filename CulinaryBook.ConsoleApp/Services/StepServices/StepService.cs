using System.Collections;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;

namespace CulinaryBook.ConsoleApp.Services.StepServices
{
    public class StepService : IStepService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessService<Step> _service;

        public StepService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessService<Step>(contextFactory);
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<Step> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<Step> Create(Step entity)
        {
            return await _service.Create(entity);
        }

        public async Task<Step> Update(int id, Step entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}