using System;

namespace FraudMonitoringSystem.Exceptions.Customer
{
    /// <summary>
    /// Exception thrown when registration input validation fails.
    /// Example: mismatched passwords, missing required fields.
    /// </summary>
    public class RegisterValidationException : Exception
    {
        public RegisterValidationException(string message) : base(message) { }
    }
}
