using System;

namespace FraudMonitoringSystem.Exceptions.Customer
{
    /// <summary>
    /// Exception thrown when a database operation fails during registration.
    /// </summary>
    public class RegisterDatabaseException : Exception
    {
        public RegisterDatabaseException(string message) : base(message) { }
    }
}
