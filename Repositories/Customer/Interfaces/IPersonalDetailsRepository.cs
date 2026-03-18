using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{
    public interface IPersonalDetailsRepository
    {
        Task<int> AddAsync(PersonalDetails details);
        Task<PersonalDetails?> GetByIdAsync(long id);
        Task<List<PersonalDetails>> GetAllAsync();
        Task<int> UpdateAsync(PersonalDetails details);
        Task<int> DeleteAsync(long id);

        Task<int> PatchAsync(PersonalDetails details);
    }
}