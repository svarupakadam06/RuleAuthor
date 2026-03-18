using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.Models.Admin
{
    public class Permission : BaseEntity
    {
        [Key]
        public int PermissionId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ActionName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        // Navigation
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}