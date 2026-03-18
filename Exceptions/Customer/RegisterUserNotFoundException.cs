using System;

namespace FraudMonitoringSystem.Exceptions
{
    /// <summary>
    /// Exception thrown when a registration record is not found.
    /// Example: searching for a user by role or email that does not exist.
    /// </summary>
    public class RegisterUserNotFoundException : Exception
    {
        public RegisterUserNotFoundException(string message) : base(message) { }
    }
}
