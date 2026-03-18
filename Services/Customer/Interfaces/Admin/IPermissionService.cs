using FraudMonitoringSystem.DTOs.Admin;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IPermissionService
    {
        Task<List<PermissionResponseDto>> GetAllAsync();
        Task<PermissionResponseDto> GetByIdAsync(int id);
        Task<string> CreateAsync(PermissionCreateDto dto);
        Task<string> UpdateAsync(int id, PermissionUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}
