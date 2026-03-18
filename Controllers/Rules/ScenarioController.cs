using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Services.Customer.Interfaces.Rules;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Rules
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioService _service;

        public ScenarioController(IScenarioService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetScenario(int id) => Ok(_service.GetScenarioById(id));

        [HttpGet]
        public IActionResult GetAllScenarios() => Ok(_service.GetAllScenarios());

        [HttpPost]
        public IActionResult CreateScenario([FromBody] Scenario scenario)
        {
            _service.CreateScenario(scenario);
            return Ok("Scenario created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateScenario(int id, [FromBody] Scenario scenario)
        {
            if (id != scenario.ScenarioId)
            {
                return BadRequest("Scenario ID mismatch.");
            }

            _service.UpdateScenario(scenario);
            return Ok("Scenario updated successfully.");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteScenario(int id)
        {
            _service.DeleteScenario(id);
            return Ok("Scenario deleted successfully.");
        }
    }
}