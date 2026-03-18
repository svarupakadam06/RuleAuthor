namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class InvalidPermissionException : Exception
    {
        public InvalidPermissionException(string message)
            : base(message)
        {
        }
    }
}