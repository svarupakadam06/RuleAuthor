namespace FraudMonitoringSystem.DTOs.Admin
{
    public class PermissionResponseDto
    {
        public int PermissionId { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
    }
}