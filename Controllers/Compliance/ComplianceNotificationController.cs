using Microsoft.AspNetCore.Mvc;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplianceNotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public ComplianceNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // POST: api/compliance/send-notification
        [HttpPost("send-notification")]
        public async Task<ActionResult> SendNotification([FromQuery] long customerId, [FromQuery] string message)
        {
            await _notificationService.SendNotificationAsync(customerId, message);
            return Ok(new { Message = "Notification sent successfully." });
        }
    }
}
