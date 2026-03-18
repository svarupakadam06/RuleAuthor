using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Investigator;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Investigator;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Investigator
{
    public class RiskScoreRepository : IRiskScoreRepository
    {
        private readonly WebContext _context;

        public RiskScoreRepository(WebContext context)
        {
            _context = context;
        }

        public IEnumerable<RiskScore> GetAll()
        {
            return _context.RiskScore
                           .Include(r => r.Transaction)
                           .ToList();
        }

        public RiskScore GetByScoreId(int id)
        {
            return _context.RiskScore
                           .Include(r => r.Transaction)
                           .FirstOrDefault(r => r.ScoreID == id);
        }

        public RiskScore GetByTransactionId(int txnId)
        {
            return _context.RiskScore
                           .Include(r => r.Transaction)
                           .FirstOrDefault(r => r.TransactionID == txnId);
        }

        public void GenerateRiskScores()
        {
            var transactions = _context.Transaction.ToList();
            var rules = _context.DetectionRule.Where(r => r.IsActive).ToList();

            var riskScores = new List<RiskScore>();

            foreach (var txn in transactions)
            {
                if (_context.RiskScore.Any(r => r.TransactionID == txn.TransactionID))
                    continue;

                decimal scoreValue = 0;
                var reasons = new List<string>();

                // ✅ Group all amount thresholds exceeded
                var amountThresholds = rules
                    .Where(r => r.Expression.Contains("Amount") && txn.Amount > r.Threshold)
                    .Select(r => r.Threshold)
                    .ToList();

                if (amountThresholds.Any())
                {
                    // Adjust scoring logic if needed
                    scoreValue += 30; // flat severity, or scale based on highest threshold
                    reasons.Add($"Transaction amount {txn.Amount} exceeded thresholds: {string.Join(", ", amountThresholds)}.");
                }

                // ✅ Currency rule
                foreach (var rule in rules.Where(r => r.Expression.Contains("Currency")))
                {
                    if (txn.Currency == rule.Expression.Split('=')[1].Trim())
                    {
                        scoreValue += 20;
                        reasons.Add($"Transaction used currency {txn.Currency}, which may be considered risky.");
                    }
                }

                // ✅ Status rule
                foreach (var rule in rules.Where(r => r.Expression.Contains("Status")))
                {
                    if (txn.Status == rule.Expression.Split('=')[1].Trim())
                    {
                        scoreValue += 15;
                        reasons.Add($"Transaction status is {txn.Status}, which may indicate suspicious activity.");
                    }
                }

                // ✅ Channel rule
                foreach (var rule in rules.Where(r => r.Expression.Contains("Channel")))
                {
                    if (txn.Channel == rule.Expression.Split('=')[1].Trim())
                    {
                        scoreValue += 10;
                        reasons.Add($"Transaction was made using {txn.Channel}, which is more prone to fraud.");
                    }
                }

                if (scoreValue > 100) scoreValue = 100;

                var riskScore = new RiskScore
                {
                    TransactionID = txn.TransactionID,
                    Transaction = txn,
                    ScoreValue = scoreValue,
                    ReasonsJSON = JsonSerializer.Serialize(reasons.Distinct()),
                    EvaluatedAt = DateTime.UtcNow
                };

                riskScores.Add(riskScore);
            }

            if (riskScores.Any())
            {
                _context.RiskScore.AddRange(riskScores);
                _context.SaveChanges();
            }
        }

        public RiskScore GetById(int id)
        {
            return _context.RiskScore
                           .Include(r => r.Transaction)
                           .FirstOrDefault(r => r.ScoreID == id);
        }
    }
}

