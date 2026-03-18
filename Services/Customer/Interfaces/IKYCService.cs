using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface IKYCService
    {
        Task<KYCProfile> GetByIdAsync(long id);
        Task<List<KYCProfile>> SearchAsync(string query);
        Task<KYCProfile> CreateAsync(long customerId, List<IFormFile> documents, List<string> requiredDocs);
        Task<KYCProfile> UpdateAsync(long id, List<IFormFile> documents, List<string> requiredDocs);
        Task<KYCProfile> PatchAsync(long id, KYCProfile partialProfile);
    }
}