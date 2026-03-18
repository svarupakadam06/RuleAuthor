namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class RolePermissionNotFoundException : Exception
    {
        public RolePermissionNotFoundException(int id)
            : base($"RolePermission with Id {id} not found.")
        {
        }
    }
}