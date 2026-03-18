using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using FraudMonitoringSystem.Repositories.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Admin
{
    public class SystemUserService : ISystemUserService
    {
        private readonly ISystemUserRepository _repository;
        private readonly IRegistrationRepository _registrationRepository;

        public SystemUserService(
            ISystemUserRepository repository,
            IRegistrationRepository registrationRepository)
        {
            _repository = repository;
            _registrationRepository = registrationRepository;
        }

        public async Task<List<SystemUserResponseDto>> GetAllAsync(int page, int pageSize)
        {
            var users = await _repository.GetAllAsync(page, pageSize);
            return users.Select(x => new SystemUserResponseDto
            {
                Id = x.Id,
                FirstName = x.Registration?.FirstName,
                LastName = x.Registration?.LastName,
                Role = x.Role?.RoleName
            }).ToList();
        }

        public async Task<List<SystemUserResponseDto>> GetByRoleIdAsync(int roleId)
        {
            var users = await _repository.GetByRoleIdAsync(roleId);
            return users.Select(x => new SystemUserResponseDto
            {
                Id = x.Id,
                FirstName = x.Registration?.FirstName,
                LastName = x.Registration?.LastName,
                Role = x.Role?.RoleName
            }).ToList();
        }

        public async Task AddAsync(SystemUserCreateDto dto)
        {
            var registration = await _registrationRepository.GetByIdAsync(dto.RegistrationId);
            if (registration == null)
                throw new RoleNotFoundException("Registration not found"); // or a NotFoundException you use elsewhere

            // If you need to block Customers:
            // if (registration.Role == RegisterRole.Customer)
            //     throw new InvalidRoleException("Customer cannot be system user");

            if (await _repository.ExistsByRegistrationId(dto.RegistrationId))
                throw new RoleAlreadyExistsException("System user already exists for this registration"); // replace with DuplicateException if you have one

            var user = new SystemUser
            {
                RegistrationId = dto.RegistrationId,
                RoleId = dto.RoleId,
            };

            await _repository.AddAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                throw new RoleNotFoundException("SystemUser not found"); // or your NotFoundException

            await _repository.DeleteAsync(user);
        }
    }
}