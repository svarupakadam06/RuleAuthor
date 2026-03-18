using FraudMonitoringSystem.DTOs.Admin;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IRolePermissionService
    {
        Task<List<RolePermissionResponseDto>> GetAllAsync();
        Task<RolePermissionResponseDto> GetByIdAsync(int id);
        Task<string> AssignPermissionAsync(RolePermissionCreateDto dto);
        Task<string> RemovePermissionAsync(int id);
    }
}