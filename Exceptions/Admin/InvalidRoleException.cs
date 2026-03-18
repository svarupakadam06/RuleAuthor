namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException(string message) : base(message) { }
    }
}