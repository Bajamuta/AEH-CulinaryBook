using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services.StepsListServices
{
    public class StepsListDataService : IStepsListDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessService<StepsList> _service;

        public StepsListDataService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessService<StepsList>(contextFactory);
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<StepsList> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<StepsList> Create(StepsList entity)
        {
            return await _service.Create(entity);
        }

        public async Task<StepsList> Update(int id, StepsList entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }

        public async Task<IEnumerable> GetByRecipe(Recipe recipe)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<StepsList> stepsList = null;
                try
                {
                    stepsList = await context.Set<StepsList>().Where((e) => e.Id_Recipe == recipe.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return stepsList;
            }
        }

        public async Task<IEnumerable> GetByStep(Step step)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<StepsList> stepsList = null;
                try
                {
                    stepsList = await context.Set<StepsList>().Where(e=> e.Id_Step == step.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return stepsList;
            }
        }
    }
}