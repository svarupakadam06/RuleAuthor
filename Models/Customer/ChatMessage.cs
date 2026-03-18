using System;

namespace FraudMonitoringSystem.Models.Customer
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public long CustomerId { get; set; }
        public string Sender { get; set; }   // "Customer" or "Admin"
        public string Message { get; set; }
        public DateTime SentAt { get; set; }

        // Navigation property
        public PersonalDetails Customer { get; set; }
    }
}
