using System;

namespace FraudMonitoringSystem.Exceptions.Customer
{
    /// <summary>
    /// Exception thrown when a registration record is not found.
    /// </summary>
    public class RegisterUserAlreadyExistsException : Exception
    {
        public RegisterUserAlreadyExistsException(string message) : base(message) { }
    }
}
