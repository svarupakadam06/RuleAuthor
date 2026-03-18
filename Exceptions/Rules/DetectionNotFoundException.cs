namespace FraudMonitoringSystem.Exceptions.Rules
{
    public class DetectionNotFoundException : Exception
    {
        public DetectionNotFoundException(string message) : base(message) { }
    }
}