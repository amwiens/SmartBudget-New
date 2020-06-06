using Microsoft.EntityFrameworkCore;

using SmartBudget.Domain.Models;
using SmartBudget.Domain.Services;
using SmartBudget.EntityFramework.Services.Common;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBudget.EntityFramework.Services
{
    public class UserDataService : IUserService
    {
        private readonly SmartBudgetDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(SmartBudgetDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<User> Get(int id)
        {
            using (SmartBudgetDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (SmartBudgetDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Users
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (SmartBudgetDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            using (SmartBudgetDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .FirstOrDefaultAsync(u => u.Username == username);
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}