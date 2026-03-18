using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
    public class KYCRepository : IKYCRepository
    {
        private readonly WebContext _context;

        public KYCRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<KYCProfile> GetByIdAsync(long id)
        {
            return await _context.KYCProfile
                .Include(k => k.Customer)
                .FirstOrDefaultAsync(k => k.KYCId == id);
        }

        public async Task<List<KYCProfile>> SearchAsync(string query)
        {
            return await _context.KYCProfile
                .Include(k => k.Customer)
                .Where(k => k.Customer.CustomerType.Contains(query))
                .ToListAsync();
        }


        public async Task<KYCProfile> AddAsync(KYCProfile profile)
        {
            _context.KYCProfile.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public Task<KYCProfile> UpdateAsync(KYCProfile profile)
        {
            throw new NotImplementedException();
        }

    }
}

