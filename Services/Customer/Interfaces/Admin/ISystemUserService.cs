using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface ISystemUserService
    {
        Task<List<SystemUserResponseDto>> GetAllAsync(int page, int pageSize);
        Task<List<SystemUserResponseDto>> GetByRoleIdAsync(int roleId);
        Task AddAsync(SystemUserCreateDto dto);
        Task DeleteAsync(int id);
    }
}