namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class PermissionAlreadyExistsException : Exception
    {
        public PermissionAlreadyExistsException(string module, string action)
            : base($"Permission already exists for Module '{module}' and Action '{action}'.")
        {
        }
    }
}
