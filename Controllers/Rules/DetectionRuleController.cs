using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Services.Customer.Interfaces.Rules;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Rules
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class DetectionRuleController : ControllerBase
    {
        private readonly IDetectionRuleService _service;

        public DetectionRuleController(IDetectionRuleService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetRule(int id) => Ok(_service.GetRuleById(id));

        [HttpGet]
        public IActionResult GetAllRules() => Ok(_service.GetAllRules());

        [HttpPost]
        public IActionResult CreateRule([FromBody] DetectionRule rule)
        {
            _service.CreateRule(rule);
            return Ok("Rule created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRule(int id, [FromBody] DetectionRule rule)
        {
            if (id != rule.RuleId)
                return BadRequest("Rule ID mismatch.");
            _service.UpdateRule(rule);
            return Ok("Rule updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRule(int id)
        {
            _service.DeleteRule(id);
            return Ok("Rule deleted successfully.");
        }

        [HttpGet("scenario/{scenarioId}/rules")]
        public IActionResult GetRulesByScenario(int scenarioId)
        {
            var rules = _service.GetRulesByScenario(scenarioId);
            if (rules == null || !rules.Any())
                return NotFound($"No rules found for scenarioId {scenarioId}");

            return Ok(rules);
        }

    }
}