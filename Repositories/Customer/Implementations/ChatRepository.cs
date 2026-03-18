using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations
{
    public class ChatRepository : IChatRepository
    {
        private readonly WebContext _context;

        public ChatRepository(WebContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatByCustomerAsync(long customerId)
        {
            return await _context.ChatMessages
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Customer)
                .OrderBy(c => c.SentAt)
                .ToListAsync();
        }

        public async Task AddChatMessageAsync(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }
    }
}
