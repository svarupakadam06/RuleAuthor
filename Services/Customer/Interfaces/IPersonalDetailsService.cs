using FraudMonitoringSystem.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Models;
using FraudMonitoringSystem.Models.Customer;


namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface IPersonalDetailsService
    {
        Task<string> AddAsync(PersonalDetails details);
        Task<PersonalDetails> GetByIdAsync(long id);
        Task<List<PersonalDetails>> GetAllAsync();
        Task<string> UpdateAsync(PersonalDetails details);
        Task<string> DeleteAsync(long id);

        Task<string> PatchAsync(long id, PersonalDetails details);
    }
}