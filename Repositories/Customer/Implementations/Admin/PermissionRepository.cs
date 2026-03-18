using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly WebContext _context;
        public PermissionRepository(WebContext context) => _context = context;

        public async Task<List<Permission>> GetAllAsync() =>
            await _context.Permissions
                .OrderBy(p => p.ModuleName)
                .ThenBy(p => p.ActionName)
                .ToListAsync();

        public async Task<Permission?> GetByIdAsync(int id) =>
            await _context.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id);

        public async Task<Permission?> GetByModuleAndActionAsync(string module, string action) =>
            await _context.Permissions.FirstOrDefaultAsync(p => p.ModuleName == module && p.ActionName == action);

        public async Task AddAsync(Permission permission) =>
            await _context.Permissions.AddAsync(permission);

        public Task UpdateAsync(Permission permission)
        {
            _context.Permissions.Update(permission);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Permission permission)
        {
            _context.Permissions.Remove(permission);
            return Task.CompletedTask;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}