using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface IAccountService
    {
        Task<int> CreateAccountAsync(Account account);

        Task<Account> PatchAsync(long id, Account partialAccount);
        Task<Account> GetAccountByIdAsync(long id);
    }
}
