using FraudMonitoringSystem.Models.Investigator;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator;
using FraudMonitoringSystem.Services.Customer.Interfaces.Investigator;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Investigator
{
    public class RiskScoreService : IRiskScoreService
    {
        private readonly IRiskScoreRepository _repo;

        public RiskScoreService(IRiskScoreRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<RiskScore> GetAllRiskScores()
        {
            return _repo.GetAll();
        }

        public RiskScore GetRiskScoreByScoreId(int id)
        {
            return _repo.GetByScoreId(id);
        }

        public RiskScore GetRiskScoreByTransactionId(int txnId)
        {
            return _repo.GetByTransactionId(txnId);
        }

        public void GenerateRiskScores()
        {
            _repo.GenerateRiskScores();
        }

        public Transaction GetTransactionById(int txnId)
        {
            // Implement repository call if you have Transaction persistence
            throw new NotImplementedException();
        }
    }
}

