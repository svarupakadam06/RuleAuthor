using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FraudMonitoringSystem.Models.Customer
{
    public class PersonalDetails
    {
        [Key]
        public long CustomerId { get; set; }


        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Middle name cannot exceed 100 characters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "Father name cannot exceed 100 characters")]
        public string FatherName { get; set; }

        [StringLength(100, ErrorMessage = "Mother name cannot exceed 100 characters")]
        public string MotherName { get; set; }


        [Required(ErrorMessage = "Customer type is required")]
        [StringLength(50, ErrorMessage = "Customer type cannot exceed 50 characters")]
        [RegularExpression("Business|Student|Retail",
            ErrorMessage = "Customer type must be Business, Student, or Normal Worker")]
        public string CustomerType { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string Phone { get; set; }

      
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        [RegularExpression("Active|Inactive", ErrorMessage = "Status must be either Active or Inactive")]
        public string Status { get; set; }

      
        [StringLength(255, ErrorMessage = "Permanent address cannot exceed 255 characters")]
        public string PermanentAddress { get; set; }

        [StringLength(255, ErrorMessage = "Current address cannot exceed 255 characters")]
        public string CurrentAddress { get; set; }

    
        [Display(Name = "Profile Image Path")]
        [StringLength(255, ErrorMessage = "Image path cannot exceed 255 characters")]
        public string ProfileImagePath { get; set; }

        [JsonIgnore]
        public ICollection<Notification>? Notifications { get; set; }

    }
}