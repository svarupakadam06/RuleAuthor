using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly WebContext _context;

        public NotificationRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsByCustomerAsync(long customerId)
        {
            return await _context.Notifications
                .Where(n => n.CustomerId == customerId)
                .Include(n => n.Customer)
                .ToListAsync();
        }

        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }
    }
}
