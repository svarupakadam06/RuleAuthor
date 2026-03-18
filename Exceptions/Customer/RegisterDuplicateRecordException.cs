using System;

namespace FraudMonitoringSystem.Exceptions.Customer
{
    /// <summary>
    /// Exception thrown when a duplicate record is detected during registration.
    /// Example: duplicate phone number or duplicate role assignment.
    /// </summary>
    public class RegisterDuplicateRecordException : Exception
    {
        public RegisterDuplicateRecordException(string message) : base(message) { }
    }
}
