namespace FraudMonitoringSystem.DTOs.Admin
{
    public class PermissionCreateDto
    {
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
    }
}