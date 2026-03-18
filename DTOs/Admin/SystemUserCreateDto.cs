using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.DTOs.Admin
{
    public class SystemUserCreateDto
    {
        [Required]
        public int RegistrationId { get; set; }
        [Required]
        public int  RoleId { get; set; }
    }
}