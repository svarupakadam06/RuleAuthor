using FraudMonitoringSystem.Models.Rules;

namespace FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules
{
    public interface IScenarioRepository
    {
        Scenario GetById(int id);
        IEnumerable<Scenario> GetAll();
        void Add(Scenario scenario);
        void Update(Scenario scenario);
        void Delete(int id);
    }
}
