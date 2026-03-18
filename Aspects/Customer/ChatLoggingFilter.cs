using Microsoft.AspNetCore.Mvc.Filters;

namespace FraudMonitoringSystem.Aspects.Customer
{
    public class ChatLoggingFilter : IActionFilter
    {
        private readonly ILogger<ChatLoggingFilter> _logger;

        public ChatLoggingFilter(ILogger<ChatLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Chat action starting: {Action}", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Chat action finished: {Action}", context.ActionDescriptor.DisplayName);
        }
    }
}
