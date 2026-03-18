using System.Collections.Generic;
using System.Threading.Tasks;
using FraudMonitoringSystem.Models.Customer;

namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(long customerId);
        Task SendNotificationAsync(long customerId, string message);
        Task MarkAsReadAsync(int notificationId);
    }
}
