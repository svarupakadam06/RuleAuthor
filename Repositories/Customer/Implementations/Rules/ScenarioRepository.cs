using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Rules
{
    public class ScenarioRepository : IScenarioRepository
    {
        private readonly WebContext _context;

        public ScenarioRepository(WebContext context)
        {
            _context = context;
        }

        public Scenario GetById(int id) => _context.Scenarios.Find(id);

        public IEnumerable<Scenario> GetAll() => _context.Scenarios.ToList();

        public void Add(Scenario scenario)
        {
            _context.Scenarios.Add(scenario);
            _context.SaveChanges();
        }

        public void Update(Scenario scenario)
        {
            _context.Scenarios.Update(scenario);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var scenario = _context.Scenarios.Find(id);
            if (scenario != null)
            {
                _context.Scenarios.Remove(scenario);
                _context.SaveChanges();
            }
        }
    }
}