using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Investigator
{
    public class RiskScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreID { get; set; }


       
        [Required(ErrorMessage = "TransactionID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "TransactionID must be greater than zero.")]
        public int TransactionID { get; set; }

        [ForeignKey(nameof(TransactionID))]
        public Transaction Transaction { get; set; }  



        [Required(ErrorMessage = "ScoreValue is required.")]
        [Range(0, 100, ErrorMessage = "ScoreValue must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")] 
        public decimal ScoreValue { get; set; }

        [Required(ErrorMessage = "ReasonsJSON is required.")]
        [StringLength(1000, ErrorMessage = "ReasonsJSON cannot exceed 1000 characters.")]
        public string ReasonsJSON { get; set; }

        [Required(ErrorMessage = "EvaluatedAt timestamp is required.")]
        public DateTime EvaluatedAt { get; set; }
    }
}
