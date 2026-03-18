using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly WebContext _context;
        public SystemUserRepository(WebContext context) => _context = context;

        public async Task<List<SystemUser>> GetAllAsync(int page, int pageSize)
        {
            return await _context.SystemUsers
                .Include(x => x.Registration)
                .Include(x => x.Role)
                .OrderBy(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<SystemUser?> GetByIdAsync(int id)
        {
            return await _context.SystemUsers
                .Include(x => x.Registration)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SystemUser>> GetByRoleIdAsync(int roleId)
        {
            return await _context.SystemUsers
                .Include(x => x.Registration)
                .Include(x => x.Role)
                .Where(x => x.RoleId == roleId)
                .ToListAsync();
        }

        public async Task AddAsync(SystemUser user)
        {
            await _context.SystemUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SystemUser user)
        {
            _context.SystemUsers.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByRegistrationId(int registrationId)
        {
            return await _context.SystemUsers.AnyAsync(x => x.RegistrationId == registrationId);
        }

        public async Task<int> CountByRoleIdAsync(int roleId)
        {
            return await _context.SystemUsers.CountAsync(x => x.RoleId == roleId);
        }
    }
}