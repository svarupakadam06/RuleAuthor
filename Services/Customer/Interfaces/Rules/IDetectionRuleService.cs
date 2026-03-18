using FraudMonitoringSystem.Models.Rules;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Rules
{
    public interface IDetectionRuleService
    {
        DetectionRule GetRuleById(int id);
        IEnumerable<DetectionRule> GetAllRules();
        void CreateRule(DetectionRule rule);
        void UpdateRule(DetectionRule rule);
        void DeleteRule(int id);

        IEnumerable<DetectionRule> GetRulesByScenario(int scenarioId);

    }
}