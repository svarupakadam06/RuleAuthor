using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Rules
{
    public class DetectionRuleRepository : IDetectionRuleRepository
    {
        private readonly WebContext _context;

        public DetectionRuleRepository(WebContext context)
        {
            _context = context;
        }

        public DetectionRule GetById(int id)
        {
            return _context.DetectionRule
                           .Include(r => r.Scenario)           
                           .FirstOrDefault(r => r.RuleId == id);
        }

        public IEnumerable<DetectionRule> GetAll()
        {
            return _context.DetectionRule
                           .Include(r => r.Scenario)   
                           .ToList();
        }

        public void Add(DetectionRule rule)
        {
            _context.DetectionRule.Add(rule);
            _context.SaveChanges();
        }

        public void Update(DetectionRule rule)
        {
            _context.DetectionRule.Update(rule);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rule = _context.DetectionRule.Find(id);
            if (rule != null)
            {
                _context.DetectionRule.Remove(rule);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DetectionRule> GetRulesByScenario(int scenarioId)
        {
            return _context.DetectionRule
                           .Include(r => r.Scenario)
                           .Where(r => r.ScenarioId == scenarioId && r.IsActive)
                           .ToList();
        }


    }
}

