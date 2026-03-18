using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Customer
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long AccountId { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        public long CustomerId { get; set; }

        [ForeignKey("CustomerId")]

        [Required(ErrorMessage = "Account Number is required")]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Account Number must be alphanumeric")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Product Type is required")]
        [RegularExpression("Saving|Salary|Current", ErrorMessage = "Product Type must be Saving, Salary, or Current")]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [RegularExpression("USD|EUR|INR|GBP|JPY|AUD|CAD|CHF|CNY|NZD", ErrorMessage = "Currency must be valid")]
        public string Currency { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Balance must be non-negative")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("Active|Inactive", ErrorMessage = "Status must be Active or Inactive")]
        public string Status { get; set; }
    }
}
