using FraudMonitoringSystem.Models.Admin;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin
{
    public interface IRolePermissionRepository
    {
        Task<List<RolePermission>> GetAllAsync();
        Task<RolePermission?> GetByIdAsync(int id);
        Task<RolePermission?> GetByRoleAndPermissionAsync(int roleId, int permissionId);

        Task AddAsync(RolePermission rolePermission);
        Task DeleteAsync(RolePermission rolePermission);

        Task<bool> RoleExistsAsync(int roleId);
        Task<bool> PermissionExistsAsync(int permissionId);

        Task SaveAsync();
    }
}