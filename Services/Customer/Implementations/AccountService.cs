using FraudMonitoringSystem.Exceptions.Customer;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;

namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IAccountRepository repository, ILogger<AccountService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> CreateAccountAsync(Account account)
        {
            ValidateAccount(account);
            try
            {
                return await _repository.AddAsync(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating account for CustomerId {CustomerId}", account.CustomerId);
                throw new AccountDatabaseException("Failed to create account", ex);
            }
        }

        public async Task<Account> PatchAsync(long id, Account partialAccount)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new AccountNotFoundException($"Account with ID {id} not found.");


            if (!string.IsNullOrEmpty(partialAccount.AccountNumber))
                existing.AccountNumber = partialAccount.AccountNumber;

            if (!string.IsNullOrEmpty(partialAccount.ProductType))
                existing.ProductType = partialAccount.ProductType;

            if (!string.IsNullOrEmpty(partialAccount.Currency))
                existing.Currency = partialAccount.Currency;

            if (!string.IsNullOrEmpty(partialAccount.Status))
                existing.Status = partialAccount.Status;

            // ⚠️ Balance intentionally skipped (as you requested)

            return await _repository.PatchAsync(existing);
        }



        public async Task<Account> GetAccountByIdAsync(long id)
        {
            var account = await _repository.GetByIdAsync(id);
            if (account == null)
                throw new AccountNotFoundException($"Account with ID {id} not found.");
            return account;
        }

        private void ValidateAccount(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.AccountNumber))
                throw new AccountValidationException("AccountNumber is required.");

            if (account.Balance < 0)
                throw new AccountValidationException("Balance cannot be negative.");

            var validTypes = new[] { "Saving", "Salary", "Current" };
            if (!validTypes.Contains(account.ProductType))
                throw new AccountValidationException("Invalid ProductType.");

            var validStatus = new[] { "Active", "Inactive" };
            if (!validStatus.Contains(account.Status))
                throw new AccountValidationException("Invalid Status.");
        }
    }
}
