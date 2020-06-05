using SmartBudget.Domain.Models;

using System.Threading.Tasks;

namespace SmartBudget.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        Task<User> Login(string username, string password);
    }
}