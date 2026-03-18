namespace FraudMonitoringSystem.DTOs.Admin
{
    public class RolePermissionResponseDto
    {
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PermissionId { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}