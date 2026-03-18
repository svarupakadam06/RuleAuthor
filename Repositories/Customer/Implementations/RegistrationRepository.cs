using FraudMonitoringSystem.Controllers.Admin;
using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Implementations
{
   
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly WebContext _context;

        public RegistrationRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<int> RegisterAsync(Registration registration)
        {
            await _context.Registrations.AddAsync(registration);
            return await _context.SaveChangesAsync();
        }

        public async Task<Registration?> GetByEmailAsync(string email)
        {
            return await _context.Registrations
                                 .FirstOrDefaultAsync(r => r.Email == email);
        }

        public async Task<Registration?> GetByRoleAsync(RegisterRole role)
        {
            return await _context.Registrations
                                 .FirstOrDefaultAsync(r => r.Role == role);
        }

     

       
        public async Task<Registration?> GetByIdAsync(int id)
        {
            return await _context.Registrations
                .FirstOrDefaultAsync(r => r.RegistrationId == id);
        }
        // Admin
        public async Task AddSystemUserAsync(Registration registration)
        {
           
            var exists = await _context.SystemUsers
                .AnyAsync(u => u.RegistrationId == registration.RegistrationId);
            if (exists)
            {
                return; // or throw new InvalidOperationException("System user already exists for this registration.");
            }

            // 2) Map RegisterRole enum -> Role.RoleName (must be seeded/created)
            var roleName = registration.Role.ToString(); // e.g., "Analyst", "Investigator", etc.
            var role = await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RoleName == roleName);

            if (role == null)
            {
                // Fail fast (or auto-create role if that's your policy)
                throw new InvalidOperationException(
                    $"Role '{roleName}' not found in Roles table. Seed/create the role first.");
            }

            // 3) Create SystemUser with RoleId FK
            var systemUser = new SystemUser
            {
                RegistrationId = registration.RegistrationId,
                RoleId = role.RoleId
                // BaseEntity fields (CreatedAt/IsActive/IsDeleted) will use defaults
            };

            await _context.SystemUsers.AddAsync(systemUser);
            await _context.SaveChangesAsync();
        }

    }
}
