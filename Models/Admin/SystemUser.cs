using FraudMonitoringSystem.Models.Customer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Admin
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RegistrationId { get; set; }

        [ForeignKey(nameof(RegistrationId))]
        public Registration Registration { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

    }
}