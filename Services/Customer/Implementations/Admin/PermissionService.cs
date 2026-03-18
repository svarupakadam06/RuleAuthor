using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repository;
        public PermissionService(IPermissionRepository repository) => _repository = repository;

        public async Task<List<PermissionResponseDto>> GetAllAsync()
        {
            var permissions = await _repository.GetAllAsync();
            return permissions.Select(p => new PermissionResponseDto
            {
                PermissionId = p.PermissionId,
                ModuleName = p.ModuleName,
                ActionName = p.ActionName,
                Description = p.Description
            }).ToList();
        }

        public async Task<PermissionResponseDto> GetByIdAsync(int id)
        {
            var permission = await _repository.GetByIdAsync(id)
                ?? throw new PermissionNotFoundException(id);

            return new PermissionResponseDto
            {
                PermissionId = permission.PermissionId,
                ModuleName = permission.ModuleName,
                ActionName = permission.ActionName,
                Description = permission.Description
            };
        }

        public async Task<string> CreateAsync(PermissionCreateDto dto)
        {
            var module = dto.ModuleName?.Trim();
            var action = dto.ActionName?.Trim();

            if (string.IsNullOrWhiteSpace(module))
                throw new InvalidPermissionException("ModuleName is required");
            if (string.IsNullOrWhiteSpace(action))
                throw new InvalidPermissionException("ActionName is required");

            var existing = await _repository.GetByModuleAndActionAsync(module, action);
            if (existing != null)
                throw new PermissionAlreadyExistsException(module, action);

            var permission = new Permission
            {
                ModuleName = module,
                ActionName = action,
                Description = dto.Description?.Trim(),
            };

            await _repository.AddAsync(permission);
            await _repository.SaveAsync();
            return "Permission created successfully.";
        }

        public async Task<string> UpdateAsync(int id, PermissionUpdateDto dto)
        {
            if (id != dto.PermissionId)
                throw new InvalidPermissionException("Route Id and Body Id do not match");

            var permission = await _repository.GetByIdAsync(id)
                ?? throw new PermissionNotFoundException(id);

            var module = dto.ModuleName?.Trim();
            var action = dto.ActionName?.Trim();

            if (string.IsNullOrWhiteSpace(module))
                throw new InvalidPermissionException("ModuleName is required");
            if (string.IsNullOrWhiteSpace(action))
                throw new InvalidPermissionException("ActionName is required");

            var duplicate = await _repository.GetByModuleAndActionAsync(module, action);
            if (duplicate != null && duplicate.PermissionId != id)
                throw new PermissionAlreadyExistsException(module, action);

            permission.ModuleName = module;
            permission.ActionName = action;
            permission.Description = dto.Description?.Trim();
            await _repository.UpdateAsync(permission);
            await _repository.SaveAsync();
            return "Permission updated successfully.";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var permission = await _repository.GetByIdAsync(id)
                ?? throw new PermissionNotFoundException(id);

            await _repository.DeleteAsync(permission);
            await _repository.SaveAsync();
            return "Permission deleted successfully.";
        }
    }
}