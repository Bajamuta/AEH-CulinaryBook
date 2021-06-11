using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services.RecipesListServices
{
    public class RecipesListDataService : IRecipesListDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessService<RecipesList> _service;

        public RecipesListDataService(CulinaryBookContextFactory contextFactory)
        {
            _service = new DataAccessService<RecipesList>(contextFactory);
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<RecipesList> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<RecipesList> Create(RecipesList entity)
        {
            return await _service.Create(entity);
        }

        public async Task<RecipesList> Update(int id, RecipesList entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }

        public async Task<RecipesList> GetByRecipe(Recipe recipe)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                RecipesList recipesList = null;
                try
                {
                    recipesList = await context.Set<RecipesList>().FirstOrDefaultAsync((e) => e.Id_Recipe == recipe.ID);
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return recipesList;
            }
        }

        public async Task<IEnumerable> GetByCategory(Category category)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<RecipesList> recipesList = null;
                try
                {
                    recipesList = await context.Set<RecipesList>().Where((e) => e.Id_Category == category.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return recipesList;
            }
        }

        public async Task<IEnumerable> GetByBook(Book book)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<RecipesList> recipesList = null;
                try
                {
                    recipesList = await context.Set<RecipesList>().Where((e) => e.Id_Book == book.ID).ToListAsync();
                }
                catch (Exception e)
                {
                    throw new Exception();
                }
                return recipesList;
            }
        }
    }
}