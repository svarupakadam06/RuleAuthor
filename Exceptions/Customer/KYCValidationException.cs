namespace FraudMonitoringSystem.Exceptions.Customer
{
    public class KYCValidationException : Exception
    {
        public KYCValidationException(string message) : base(message) { }
    }
}