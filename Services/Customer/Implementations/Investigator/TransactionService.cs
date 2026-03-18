using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator;
using FraudMonitoringSystem.Services.Customer.Interfaces.Investigator;
using System.ComponentModel.DataAnnotations;
using FraudMonitoringSystem.Models.Investigator;



namespace FraudMonitoringSystem.Services.Customer.Implementations.Investigator
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            var transactions = _repository.GetAll();
            if (transactions == null || !transactions.Any())
                throw new NotFoundException("No transactions found.");
            return transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            var transaction = _repository.GetById(id);
            if (transaction == null)
                throw new NotFoundException($"Transaction with ID {id} not found.");
            return transaction;
        }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0)
                throw new ValidationException("Amount must be greater than zero.");
            _repository.Add(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            if (transaction.TransactionID == 0)
                throw new ValidationException("Transaction ID is required for update.");
            _repository.Update(transaction);
        }

        public void DeleteTransaction(int id)
        {
            if (id == 0)
                throw new ValidationException("Transaction ID cannot be zero.");
            _repository.Delete(id);
        }
    }
}

