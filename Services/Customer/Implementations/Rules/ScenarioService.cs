using FraudMonitoringSystem.Exceptions.Admin;
using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;
using FraudMonitoringSystem.Services.Customer.Interfaces.Rules;
using System.ComponentModel.DataAnnotations;

namespace FraudMonitoringSystem.Services.Customer.Implementations.Rules
{
    public class ScenarioService : IScenarioService
    {
        private readonly IScenarioRepository _repository;

        public ScenarioService(IScenarioRepository repository)
        {
            _repository = repository;
        }

        public Scenario GetScenarioById(int id)
        {
            var scenario = _repository.GetById(id);
            if (scenario == null)
                throw new NotFoundException($"Scenario with ID {id} not found.");
            return scenario;
        }

        public IEnumerable<Scenario> GetAllScenarios() => _repository.GetAll();

        public void CreateScenario(Scenario scenario)
        {
            if (string.IsNullOrEmpty(scenario.Name))
                throw new ValidationException("Scenario name cannot be empty.");
            _repository.Add(scenario);
        }

        public void UpdateScenario(Scenario scenario)
        {
            if (scenario.ScenarioId == 0)
                throw new ValidationException("Scenario ID must be provided.");

            var existingScenario = _repository.GetById(scenario.ScenarioId);
            if (existingScenario == null)
                throw new NotFoundException($"Scenario with ID {scenario.ScenarioId} not found.");

            existingScenario.Name = scenario.Name;
            existingScenario.Description = scenario.Description;
            existingScenario.RiskDomain = scenario.RiskDomain;
            existingScenario.IsActive = scenario.IsActive;

            _repository.Update(existingScenario);
        }


        public void DeleteScenario(int id)
        {
            if (id == 0)
                throw new ValidationException("Invalid Scenario ID.");
            _repository.Delete(id);
        }
    }
}