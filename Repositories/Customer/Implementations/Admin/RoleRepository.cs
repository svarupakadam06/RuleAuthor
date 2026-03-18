using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class RoleRepository : IRoleRepository
    {
        private readonly WebContext _context;
        public RoleRepository(WebContext context) => _context = context;

        public async Task<IEnumerable<Role>> GetAllAsync() =>
            await _context.Roles
                .OrderBy(r => r.RoleName)
                .ToListAsync();

        public async Task<Role?> GetByIdAsync(int id) =>
            await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.RoleId == id);

        public async Task<Role?> GetByNameAsync(string roleName) =>
            await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);

        public async Task AddAsync(Role role) => await _context.Roles.AddAsync(role);

        public void Update(Role role) => _context.Roles.Update(role);

        public void Delete(Role role) => _context.Roles.Remove(role);

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}