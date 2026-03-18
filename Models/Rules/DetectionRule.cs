using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.Models.Rules
{
    public class DetectionRule
    {
        [Key]
        public int RuleId { get; set; }

        [Required(ErrorMessage = "ScenarioId is required")]
        public int ScenarioId { get; set; }

        [Required(ErrorMessage = "Rule expression is required")]
        [StringLength(250)]
        public required string Expression { get; set; }

        [Required(ErrorMessage = "Threshold is required")]
        public decimal Threshold { get; set; }

        [StringLength(20)]
        public string? Version { get; set; }

        [StringLength(50)]
        public string? CustomerType { get; set; }

        public bool IsActive { get; set; } = true;

     
        public Scenario? Scenario { get; set; }
    }
}
