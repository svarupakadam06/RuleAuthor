using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Customer
{
    public class KYCProfile
    {
        [Key]
        public long KYCId { get; set; }

        [Required]
        public long CustomerId { get; set; }

   

        [Required(ErrorMessage = "Documents are required")]
        public string DocumentRefsJSON { get; set; }

        [ForeignKey("CustomerId")]
        [ValidateNever]
        public PersonalDetails Customer { get; set; }
    }
}
