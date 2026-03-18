using FraudMonitoringSystem.Models.Rules;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules
{
    public interface IDetectionRuleRepository
    {
        DetectionRule GetById(int id);
        IEnumerable<DetectionRule> GetAll();
        void Add(DetectionRule rule);
        void Update(DetectionRule rule);
        void Delete(int id);

        IEnumerable<DetectionRule> GetRulesByScenario(int scenarioId);


    }
}