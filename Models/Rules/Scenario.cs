using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.Models.Rules
{
    public class Scenario
    {
        [Key]
        public int ScenarioId { get; set; }

        [Required(ErrorMessage = "Scenario Name is required")]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Risk Domain is required")]
        [StringLength(50)]
        public required string RiskDomain { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
