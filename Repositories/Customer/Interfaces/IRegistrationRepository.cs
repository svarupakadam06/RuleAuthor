using FraudMonitoringSystem.Models.Customer;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Repositories.Interfaces
{
   
    public interface IRegistrationRepository
    {
        Task<int> RegisterAsync(Registration registration);
        Task<Registration?> GetByEmailAsync(string email);
        Task<Registration?> GetByRoleAsync(RegisterRole role);
        //Task<List<Registration>> GetSystemUsersAsync();

        Task AddSystemUserAsync(Registration registration);
           
        Task <Registration?> GetByIdAsync(int id);
    }
}
