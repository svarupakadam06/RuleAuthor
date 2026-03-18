using FraudMonitoringSystem.Models.Investigator;
using System.Collections.Generic;






namespace FraudMonitoringSystem.Services.Customer.Interfaces.Investigator
{
    public interface IRiskScoreService
    {
        IEnumerable<RiskScore> GetAllRiskScores();
        RiskScore GetRiskScoreByTransactionId(int txnId);
        RiskScore GetRiskScoreByScoreId(int id);
        void GenerateRiskScores();
        Transaction GetTransactionById(int txnId);
    }
}
