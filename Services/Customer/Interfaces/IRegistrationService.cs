using FraudMonitoringSystem.Models.Customer;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Services.Interfaces
{
    /// <summary>
    /// Service interface for registration business logic.
    /// </summary>
    public interface IRegistrationService
    {
        Task<string> RegisterAsync(Registration registration);
        Task<Registration?> GetUserByRoleAsync(RegisterRole role);
    //    Task<List<Registration>> GetSystemUsersAsync();
    }
}
