using FraudMonitoringSystem.DTOs.Admin;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Admin
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDto>> GetAllAsync();
        Task<RoleResponseDto> GetByIdAsync(int id);
        Task<string> CreateAsync(RoleCreateDto dto);
        Task<string> UpdateAsync(int id, RoleUpdateDto dto);
        Task<string> DeleteAsync(int id);
    }
}