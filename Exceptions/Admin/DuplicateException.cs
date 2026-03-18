namespace FraudMonitoringSystem.Exceptions.Admin
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message) { }
    }
}