using FraudMonitoringSystem.Models.Investigator;


namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        Transaction GetById(int id);
        void Add(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(int id);
    }
}
