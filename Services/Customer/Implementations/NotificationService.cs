using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(long customerId)
        {
            return await _repository.GetNotificationsByCustomerAsync(customerId);
        }

        public async Task SendNotificationAsync(long customerId, string message)
        {
            var notification = new Notification
            {
                CustomerId = customerId,
                Message = message,
                Category = "Compliance",   // correct category
                Status = "Unread",         // new notifications start as Unread
                CreatedAt = DateTime.UtcNow,
                ReadAt = null
            };

            await _repository.AddNotificationAsync(notification);
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _repository.GetNotificationByIdAsync(notificationId);
            if (notification != null && notification.Status == "Unread")
            {
                notification.Status = "Read";
                notification.ReadAt = DateTime.UtcNow;
                await _repository.UpdateNotificationAsync(notification);
            }
        }
    }
}
