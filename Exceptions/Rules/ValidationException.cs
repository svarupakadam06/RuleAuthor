namespace FraudMonitoringSystem.Exceptions.Rules
{
    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message) { }
    }
}
