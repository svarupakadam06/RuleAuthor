namespace FraudMonitoringSystem.DTOs.Admin
{
    public class SystemUserResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
