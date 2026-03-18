namespace FraudMonitoringSystem.Exceptions.Customer
{
   
    public class UserAlreadyExistsException : Exception
    { public UserAlreadyExistsException(string message) : base(message) { } }
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message) { }
    }

    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message) : base(message) { }
    }
}
