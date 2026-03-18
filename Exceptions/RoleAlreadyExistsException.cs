namespace FraudMonitoringSystem.Exceptions
{
    [Serializable]
    internal class RoleAlreadyExistsException : Exception
    {
        public RoleAlreadyExistsException()
        {
        }

        public RoleAlreadyExistsException(string? message) : base(message)
        {
        }

        public RoleAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}