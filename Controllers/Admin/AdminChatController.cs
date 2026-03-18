using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [Authorize(Roles = "Customer,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public AdminChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

      
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetChat(long customerId)
        {
            var chat = await _chatService.GetChatByCustomerAsync(customerId);
            return Ok(chat);
        }


        [HttpPost("send")]
        public async Task<ActionResult> SendMessage(long customerId, string message)
        {
            try
            {
                await _chatService.SendMessageAsync(customerId, "Admin", message);
                return Ok(new { Message = "Message sent by admin." });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
