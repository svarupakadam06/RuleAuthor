using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.DTOs.Admin
{
    public class RoleCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
}