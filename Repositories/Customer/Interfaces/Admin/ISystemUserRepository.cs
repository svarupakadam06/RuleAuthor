using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface ISystemUserRepository
    {
        Task<List<SystemUser>> GetAllAsync(int page, int pageSize);
        Task<SystemUser?> GetByIdAsync(int id);
        Task<List<SystemUser>> GetByRoleIdAsync(int roleId);
        Task AddAsync(SystemUser user);
        Task DeleteAsync(SystemUser user);
        Task<bool> ExistsByRegistrationId(int registrationId);
        Task<int> CountByRoleIdAsync(int roleId);
    }
}