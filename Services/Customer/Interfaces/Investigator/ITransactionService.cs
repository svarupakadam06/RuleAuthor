using FraudMonitoringSystem.Models.Investigator; 

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Investigator
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int id);
    }
}
