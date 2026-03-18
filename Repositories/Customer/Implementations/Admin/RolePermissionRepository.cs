using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Admin;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Admin
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly WebContext _context;
        public RolePermissionRepository(WebContext context) => _context = context;

        public async Task<List<RolePermission>> GetAllAsync()
        {
            return await _context.RolePermissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .OrderBy(rp => rp.Role.RoleName)
                .ThenBy(rp => rp.Permission.ModuleName)
                .ThenBy(rp => rp.Permission.ActionName)
                .ToListAsync();
        }

        public async Task<RolePermission?> GetByIdAsync(int id)
        {
            return await _context.RolePermissions
                .Include(rp => rp.Role)
                .Include(rp => rp.Permission)
                .FirstOrDefaultAsync(rp => rp.RolePermissionId == id);
        }

        public async Task<RolePermission?> GetByRoleAndPermissionAsync(int roleId, int permissionId)
        {
            return await _context.RolePermissions
                .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        public Task AddAsync(RolePermission rolePermission)
        {
            return _context.RolePermissions.AddAsync(rolePermission).AsTask();
        }

        public Task DeleteAsync(RolePermission rolePermission)
        {
            _context.RolePermissions.Remove(rolePermission);
            return Task.CompletedTask;
        }

        public async Task<bool> RoleExistsAsync(int roleId)
        {
            return await _context.Roles.AnyAsync(r => r.RoleId == roleId);
        }

        public async Task<bool> PermissionExistsAsync(int permissionId)
        {
            return await _context.Permissions.AnyAsync(p => p.PermissionId == permissionId);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}