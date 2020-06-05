using SmartBudget.Domain.Models;

using System.Threading.Tasks;

namespace SmartBudget.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByUsername(string username);

        Task<User> GetByEmail(string Email);
    }
}