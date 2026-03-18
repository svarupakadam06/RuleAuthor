using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Models;
namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{


    
        public interface IKYCRepository
        {
            Task<KYCProfile> GetByIdAsync(long id);
            Task<List<KYCProfile>> SearchAsync(string query);
            Task<KYCProfile> AddAsync(KYCProfile profile);
            Task<KYCProfile> UpdateAsync(KYCProfile profile);
        }
    }
