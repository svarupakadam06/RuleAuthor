using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repository;
        public RolePermissionService(IRolePermissionRepository repository) => _repository = repository;

        public async Task<List<RolePermissionResponseDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(rp => new RolePermissionResponseDto
            {
                RolePermissionId = rp.RolePermissionId,
                RoleId = rp.RoleId,
                RoleName = rp.Role.RoleName,
                PermissionId = rp.PermissionId,
                ModuleName = rp.Permission.ModuleName,
                ActionName = rp.Permission.ActionName,
                AssignedAt = rp.AssignedAt
            }).ToList();
        }

        public async Task<RolePermissionResponseDto> GetByIdAsync(int id)
        {
            var rp = await _repository.GetByIdAsync(id)
                ?? throw new RolePermissionNotFoundException(id);

            return new RolePermissionResponseDto
            {
                RolePermissionId = rp.RolePermissionId,
                RoleId = rp.RoleId,
                RoleName = rp.Role.RoleName,
                PermissionId = rp.PermissionId,
                ModuleName = rp.Permission.ModuleName,
                ActionName = rp.Permission.ActionName,
                AssignedAt = rp.AssignedAt
            };
        }

        public async Task<string> AssignPermissionAsync(RolePermissionCreateDto dto)
        {
            if (!await _repository.RoleExistsAsync(dto.RoleId))
                throw new InvalidRoleException("Role does not exist.");

            if (!await _repository.PermissionExistsAsync(dto.PermissionId))
                throw new InvalidPermissionException("Permission does not exist.");

            var existing = await _repository.GetByRoleAndPermissionAsync(dto.RoleId, dto.PermissionId);
            if (existing != null)
                throw new DuplicateRolePermissionException();

            var rolePermission = new RolePermission
            {
                RoleId = dto.RoleId,
                PermissionId = dto.PermissionId,
                AssignedBy = dto.AssignedBy,
                AssignedAt = DateTime.UtcNow,
            };

            await _repository.AddAsync(rolePermission);
            await _repository.SaveAsync();
            return "Permission assigned to role successfully.";
        }

        public async Task<string> RemovePermissionAsync(int id)
        {
            var rp = await _repository.GetByIdAsync(id)
                ?? throw new RolePermissionNotFoundException(id);

            await _repository.DeleteAsync(rp);
            await _repository.SaveAsync();
            return "Permission removed successfully.";
        }
    }
}