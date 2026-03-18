namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class PermissionNotFoundException : Exception
    {
        public PermissionNotFoundException(int id)
            : base($"Permission with Id {id} not found.")
        {
        }
    }
}