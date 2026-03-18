namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class RoleAlreadyExistsException : ApplicationException
    {
        public RoleAlreadyExistsException(string message) : base(message) { }
    }
}