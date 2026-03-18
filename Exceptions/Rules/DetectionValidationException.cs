namespace FraudMonitoringSystem.Exceptions.Rules
{
    public class DetectionValidationException : Exception
    {
        public DetectionValidationException(string message) : base(message) { }
    }
}