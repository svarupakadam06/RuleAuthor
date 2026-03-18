namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}