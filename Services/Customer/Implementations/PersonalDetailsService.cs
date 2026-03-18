using FraudMonitoringSystem.Exceptions.Customer;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;

namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly IPersonalDetailsRepository repo;

        public PersonalDetailsService(IPersonalDetailsRepository repository)
        {
            repo = repository;
        }

        public async Task<string> AddAsync(PersonalDetails details)
        {
            var existing = await repo.GetByIdAsync(details.CustomerId);
            if (existing != null)
                throw new DuplicateRecordException($"Customer {details.CustomerId} already exists");

            await repo.AddAsync(details);
            return $"Personal details added for Customer ID {details.CustomerId}";
        }

        public async Task<PersonalDetails> GetByIdAsync(long id)
        {
            var details = await repo.GetByIdAsync(id);
            if (details == null)
                throw new UserNotFoundException($"Customer {id} not found");
            return details;
        }

        public async Task<List<PersonalDetails>> GetAllAsync()
        {
            return await repo.GetAllAsync();
        }

        public async Task<string> UpdateAsync(PersonalDetails details)
        {
            var updated = await repo.UpdateAsync(details);
            if (updated == 0) throw new UserNotFoundException($"Customer {details.CustomerId} not found");
            return $"Personal details updated for Customer ID {details.CustomerId}";
        }
        public async Task<string> DeleteAsync(long id)
        {
            var deleted = await repo.DeleteAsync(id);
            if (deleted == 0)
                throw new UserNotFoundException($"Customer {id} not found");
            return $"Personal details deleted for Customer ID {id}";
        }
        public async Task<string> PatchAsync(long id, PersonalDetails details)
        {
            details.CustomerId = id; // ensure ID is set
            var patched = await repo.PatchAsync(details);
            if (patched == 0) throw new UserNotFoundException($"Customer {id} not found");
            return $"Personal details patched for Customer ID {id}";
        }
    }
}
