using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Repositories.Customer.Interfaces;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Services.Customer.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;

        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ChatMessage>> GetChatByCustomerAsync(long customerId)
        {
            return await _repository.GetChatByCustomerAsync(customerId);
        }

        public async Task SendMessageAsync(long customerId, string sender, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty");

            var chatMessage = new ChatMessage
            {
                CustomerId = customerId,
                Sender = sender, // "Customer" or "Admin"
                Message = message,
                SentAt = DateTime.UtcNow
            };

            await _repository.AddChatMessageAsync(chatMessage);
        }
    }
}
