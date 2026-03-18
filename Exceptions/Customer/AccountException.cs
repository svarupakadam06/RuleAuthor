namespace FraudMonitoringSystem.Exceptions.Customer
{
    public class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException(string message) : base(message) { }
    }

    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }
    }

    public class AccountValidationException : Exception
    {
        public AccountValidationException(string message) : base(message) { }
    }

    public class AccountDatabaseException : Exception
    {
        public AccountDatabaseException(string message, Exception inner = null) : base(message, inner) { }
    }

    public class DuplicateAccountException : Exception
    {
        public DuplicateAccountException(string message) : base(message) { }
    }
}
