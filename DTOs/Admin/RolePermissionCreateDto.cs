namespace FraudMonitoringSystem.DTOs.Admin
{
    public class RolePermissionCreateDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public int? AssignedBy { get; set; }
    }
}