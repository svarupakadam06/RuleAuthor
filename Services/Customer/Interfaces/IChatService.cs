using FraudMonitoringSystem.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Services.Customer.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessage>> GetChatByCustomerAsync(long customerId);
        Task SendMessageAsync(long customerId, string sender, string message);
    }
}
