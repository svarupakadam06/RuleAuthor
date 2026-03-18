using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FraudMonitoringSystem.Models.Investigator
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int TransactionID { get; set; }

        [Required(ErrorMessage = "AccountID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "AccountID must be greater than zero.")]
        public int AccountID { get; set; }

        [Required(ErrorMessage = "CounterpartyAccount is required.")]
        [StringLength(50, ErrorMessage = "CounterpartyAccount cannot exceed 50 characters.")]
        public string CounterpartyAccount { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        [StringLength(3, ErrorMessage = "Currency must be a valid 3-letter ISO code.")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "TransactionType is required.")]
        [RegularExpression("^(Credit|Debit)$", ErrorMessage = "TransactionType must be either Credit or Debit.")]
        public string TransactionType { get; set; }

        [Required(ErrorMessage = "Channel is required.")]
        [RegularExpression("^(Branch|ATM|Online|Card|Wire|Wallet)$", ErrorMessage = "Invalid channel type.")]
        public string Channel { get; set; }

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; }

        [StringLength(100, ErrorMessage = "GeoLocation cannot exceed 100 characters.")]
        public string GeoLocation { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("^(Posted|Reversed)$", ErrorMessage = "Status must be Posted or Reversed.")]
        public string Status { get; set; }



    }
}
