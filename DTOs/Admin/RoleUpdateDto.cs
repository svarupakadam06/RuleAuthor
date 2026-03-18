using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.DTOs.Admin
{
    public class RoleUpdateDto
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
    }
}