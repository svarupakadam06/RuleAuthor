using FraudMonitoringSystem.Services.Customer.Interfaces.Investigator;
using Microsoft.AspNetCore.Mvc;
using FraudMonitoringSystem.Models.Investigator;


namespace FraudMonitoringSystem.Controllers.Investigator
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllTransactions());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.GetTransactionById(id));

        [HttpPost]
        public IActionResult Create([FromBody] Transaction transaction)
        {
            _service.CreateTransaction(transaction);
            return Ok("Transaction created successfully.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Transaction transaction)
        {
            _service.UpdateTransaction(transaction);
            return Ok("Transaction updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteTransaction(id);
            return Ok("Transaction deleted successfully.");
        }
    }
}

