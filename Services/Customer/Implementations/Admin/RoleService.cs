using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Exceptions;
using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository) => _repository = repository;

        public async Task<IEnumerable<RoleResponseDto>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(r => new RoleResponseDto
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName,
                Description = r.Description
            });
        }

        public async Task<RoleResponseDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidRoleException("Invalid Role Id");
            var role = await _repository.GetByIdAsync(id) ?? throw new RoleNotFoundException("Role not found");

            return new RoleResponseDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = role.Description
            };
        }

        public async Task<string> CreateAsync(RoleCreateDto dto)
        {
            var name = dto.RoleName?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidRoleException("Role name is required");

            var existing = await _repository.GetByNameAsync(name);
            if (existing != null)
                throw new Exceptions.RoleAlreadyExistsException("Role already exists");

            var role = new Role
            {
                RoleName = name,
                Description = dto.Description?.Trim(),
            };

            await _repository.AddAsync(role);
            await _repository.SaveAsync();
            return "Role created successfully";
        }

        public async Task<string> UpdateAsync(int id, RoleUpdateDto dto)
        {
            if (id != dto.RoleId)
                throw new InvalidRoleException("Route Id and Body Id do not match");

            var role = await _repository.GetByIdAsync(id) ?? throw new RoleNotFoundException("Role not found");

            var name = dto.RoleName?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidRoleException("Role name is required");

            var existing = await _repository.GetByNameAsync(name);
            if (existing != null && existing.RoleId != id)
                throw new Exceptions.RoleAlreadyExistsException("Role already exists");

            role.RoleName = name;
            role.Description = dto.Description?.Trim();
            _repository.Update(role);
            await _repository.SaveAsync();
            return "Role updated successfully";
        }

        public async Task<string> DeleteAsync(int id)
        {
            if (id <= 0) throw new InvalidRoleException("Invalid Role Id");
            var role = await _repository.GetByIdAsync(id) ?? throw new RoleNotFoundException("Role not found");

            _repository.Delete(role);
            await _repository.SaveAsync();
            return "Role deleted successfully";
        }
    }
}