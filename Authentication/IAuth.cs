using FraudMonitoringSystem.DTOs;

namespace FraudMonitoringSystem.Authentication
{
    public interface IAuth
    {
        Task<string> LoginAsync(LoginDto dto);
    }
}