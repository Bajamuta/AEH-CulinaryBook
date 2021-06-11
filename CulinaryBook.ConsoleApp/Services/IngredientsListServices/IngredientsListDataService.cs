using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services.IngredientsListServices
{
    public class IngredientsListDataService : IIngredientsListDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessService<IngredientsList> _service;

        public IngredientsListDataService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessService<IngredientsList>(contextFactory);
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<IngredientsList> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<IEnumerable> GetByRecipe(Recipe recipe)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<IngredientsList> ingredientsList = null;
                try
                {
                    ingredientsList = await context.Set<IngredientsList>().Where((e) => e.Id_Recipe == recipe.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return ingredientsList;
            }
        }

        public async Task<IEnumerable> GetByIngredient(Ingredient ingredient)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<IngredientsList> entityList = null;
                try
                {
                    entityList = await context.Set<IngredientsList>().Where(e=> e.Id_Ingredient == ingredient.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return entityList;
            }
        }

        public async Task<IngredientsList> Create(IngredientsList entity)
        {
            return await _service.Create(entity);
        }

        public async Task<IngredientsList> Update(int id, IngredientsList entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
    }
}