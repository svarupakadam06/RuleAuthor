using FraudMonitoringSystem.Models.Investigator;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator
{
    public interface IRiskScoreRepository
    {
        IEnumerable<RiskScore> GetAll();
        RiskScore GetById(int id);
        void GenerateRiskScores();
        RiskScore GetByTransactionId(int txnId);
        RiskScore GetByScoreId(int id);
    }
}