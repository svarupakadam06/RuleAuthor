using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator;
using FraudMonitoringSystem.Models.Investigator;
using System.Collections.Generic;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Investigator
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WebContext _context;

        public TransactionRepository(WebContext context)
        {
            _context = context;
        }

        // Use the singular DbSet name "Transaction"
        public IEnumerable<Transaction> GetAll() => _context.Transaction.ToList();

        // EF Core's Find works on DbSet<Transaction>
        public Transaction GetById(int id) => _context.Transaction.Find(id);

        public void Add(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            _context.SaveChanges();
        }

        public void Update(Transaction transaction)
        {
            _context.Transaction.Update(transaction);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var transaction = _context.Transaction.Find(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}
