using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Customer;
using Microsoft.EntityFrameworkCore;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;



namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly WebContext _context;

        public AccountRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            return await _context.SaveChangesAsync();
        }

        public async Task<Account> PatchAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }



        public async Task<Account> GetByIdAsync(long id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
        }
    }
}
