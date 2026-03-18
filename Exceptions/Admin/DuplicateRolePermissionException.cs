namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class DuplicateRolePermissionException : Exception
    {
        public DuplicateRolePermissionException()
            : base("Permission already assigned to this role.")
        {
        }
    }
}