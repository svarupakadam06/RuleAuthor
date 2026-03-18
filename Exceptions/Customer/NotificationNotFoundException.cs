using System;

namespace FraudMonitoringSystem.Models.Customer
{
    public class NotificationNotFoundException : Exception
    {
        public NotificationNotFoundException(string message) : base(message) { }
    }
}
