using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CulinaryBook.ConsoleApp.Models;
using CulinaryBook.ConsoleApp.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CulinaryBook.ConsoleApp.Services.AuthorServices
{
    public class AuthorDataService : IAuthorDataService
    {
        private readonly CulinaryBookContextFactory _contextFactory;
        private readonly DataAccessWithNameService<Author> _service;

        public AuthorDataService(CulinaryBookContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _service = new DataAccessWithNameService<Author>(contextFactory);
            
        }

        public async Task<Author> GetByLogin(string login)
        {
            using (CulinaryBookContext context = _contextFactory.CreateDbContext())
            {
                Author author = await context.Authors.FirstOrDefaultAsync((a) => a.Login == login);
                // TODO add error handling
                return author;
            }
        }
        
        public async Task<IEnumerable> GetByName(string name)
        {
            return await _service.GetByName(name);
        }
        
        public async Task<IEnumerable> GetAll()
        {
            return await _service.GetAll();
        }

        public async Task<Author> Get(int id)
        {
            return await _service.Get(id);
        }

        public async Task<Author> Create(Author entity)
        {
            return await _service.Create(entity);
        }

        public async Task<Author> Update(int id, Author entity)
        {
            return await _service.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _service.Delete(id);
        }
        
    }
}