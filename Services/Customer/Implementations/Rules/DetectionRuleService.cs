using FraudMonitoringSystem.Exceptions.Rules;
using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;
using FraudMonitoringSystem.Services.Customer.Interfaces.Rules;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Rules
{
    public class DetectionRuleService : IDetectionRuleService
    {
        private readonly IDetectionRuleRepository _repository;

        public DetectionRuleService(IDetectionRuleRepository repository)
        {
            _repository = repository;
        }

        public DetectionRule GetRuleById(int id)
        {
            var rule = _repository.GetById(id);
            if (rule == null)
                throw new DetectionNotFoundException($"DetectionRule with ID {id} not found.");
            return rule;
        }

        public IEnumerable<DetectionRule> GetAllRules() => _repository.GetAll();

        public void CreateRule(DetectionRule rule)
        {
            if (string.IsNullOrWhiteSpace(rule.Expression))
                throw new DetectionValidationException("Rule expression cannot be empty.");
            if (rule.Threshold <= 0)
                throw new DetectionValidationException("Threshold must be greater than zero.");

            _repository.Add(rule);
        }

        public void UpdateRule(DetectionRule rule)
        {
            if (rule.RuleId == 0)
                throw new DetectionValidationException("Rule ID must be provided.");

            var existingRule = _repository.GetById(rule.RuleId);
            if (existingRule == null)
                throw new DetectionNotFoundException($"DetectionRule with ID {rule.RuleId} not found.");

            existingRule.Expression = rule.Expression;
            existingRule.Threshold = rule.Threshold;
            existingRule.Version = rule.Version;
            existingRule.CustomerType = rule.CustomerType;
            existingRule.IsActive = rule.IsActive;

            _repository.Update(existingRule);
        }

        public void DeleteRule(int id)
        {
            if (id <= 0)
                throw new DetectionValidationException("Invalid Rule ID.");

            var existingRule = _repository.GetById(id);
            if (existingRule == null)
                throw new DetectionNotFoundException($"DetectionRule with ID {id} not found.");

            _repository.Delete(id);
        }

        public IEnumerable<DetectionRule> GetRulesByScenario(int scenarioId)
        {
            if (scenarioId <= 0)
                throw new DetectionValidationException("Invalid Scenario ID.");

            var rules = _repository.GetRulesByScenario(scenarioId);

            if (rules == null || !rules.Any())
                throw new DetectionNotFoundException($"No rules found for ScenarioId {scenarioId}.");

            return rules;
        }


    }
}