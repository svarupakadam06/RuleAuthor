using System;

namespace FraudMonitoringSystem.Models.Customer
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public long CustomerId { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string Status { get; set; } // "Unread" or "Read"
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }

        // Navigation property
        public PersonalDetails Customer { get; set; }
    }
}
