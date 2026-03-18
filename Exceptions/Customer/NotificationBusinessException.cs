using System;

namespace FraudMonitoringSystem.Models.Customer
{
    public class NotificationBusinessException : Exception
    {
        public NotificationBusinessException(string message) : base(message) { }
    }
}
