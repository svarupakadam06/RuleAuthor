namespace FraudMonitoringSystem.DTOs.Admin
{
    public class PermissionUpdateDto
    {
        public int PermissionId { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
    }
}