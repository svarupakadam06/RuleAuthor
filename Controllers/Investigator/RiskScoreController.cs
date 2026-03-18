using FraudMonitoringSystem.Services.Customer.Interfaces.Investigator;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Investigator
{
    public class RiskScoreController : ControllerBase
    {
        private readonly IRiskScoreService _service;

        public RiskScoreController(IRiskScoreService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllRiskScores());


        // ✅ Fetch by ScoreID
        [HttpGet("{id}")]
        public IActionResult GetByScoreId(int id)
        {
            var score = _service.GetRiskScoreByScoreId(id);
            if (score == null) return NotFound($"RiskScore with ScoreID {id} not found.");
            return Ok(score);
        }

        // ✅ Fetch by TransactionID
        [HttpGet("transaction/{txnId}")]
        public IActionResult GetByTransactionId(int txnId)
        {
            var score = _service.GetRiskScoreByTransactionId(txnId);
            if (score == null) return NotFound($"RiskScore for Transaction {txnId} not found.");
            return Ok(score);
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            _service.GenerateRiskScores();
            return Ok("Risk scores generated successfully.");
        }
    }
}

