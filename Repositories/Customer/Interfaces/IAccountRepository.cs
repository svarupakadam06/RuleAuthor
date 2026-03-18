using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> AddAsync(Account account);
        Task<Account> PatchAsync(Account account);
        Task<Account> GetByIdAsync(long id);
    }
}
