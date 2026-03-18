namespace FraudMonitoringSystem.Exceptions.Customer
{
    public class ChatNotFoundException : Exception
    {
        public ChatNotFoundException(string message) : base(message) { }
    }

 
    public class ChatValidationException : Exception
    {
        public ChatValidationException(string message) : base(message) { }
    }
}
