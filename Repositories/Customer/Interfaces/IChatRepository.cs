using FraudMonitoringSystem.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces
{
    public interface IChatRepository
    {
        Task<IEnumerable<ChatMessage>> GetChatByCustomerAsync(long customerId);
        Task AddChatMessageAsync(ChatMessage message);
    }
}
