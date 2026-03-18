using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerNotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public CustomerNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet("{customerId}/notifications")]

        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications(long customerId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(customerId);
            return Ok(notifications);
        }

        [HttpPut("notifications/{notificationId}/read")]

        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> MarkNotificationAsRead(int notificationId)
        {
            await _notificationService.MarkAsReadAsync(notificationId);
            return Ok(new { Message = "Notification marked as read." });
        }
    }
}
