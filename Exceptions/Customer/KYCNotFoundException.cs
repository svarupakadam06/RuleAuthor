namespace FraudMonitoringSystem.Exceptions.Customer
{
    public class KYCNotFoundException : Exception
    {
        public KYCNotFoundException(string message) : base(message) { }
    }
}
