using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Customer
{

    [ApiController]
    [Route("api/[controller]")]
    public class KYCProfilesController : ControllerBase
    {
        private readonly IKYCService _service;

        public KYCProfilesController(IKYCService service)
        {
            _service = service;
        }

        
        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get(long id)
        {
            var profile = await _service.GetByIdAsync(id);
            if (profile == null)
                return NotFound(new { Message = $"KYC profile {id} not found" });

            return Ok(profile);
        }

       
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create(
            [FromForm] long customerId,
            [FromForm] List<IFormFile> documents,
            [FromForm] List<string> requiredDocs)
        {
            var profile = await _service.CreateAsync(customerId, documents, requiredDocs);


            Console.WriteLine($"[NOTIFY] Compliance office: New KYC created for Customer {customerId}");

            return Ok(new { Message = "KYC created successfully", Profile = profile });
        }

        [HttpGet("search")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _service.SearchAsync(query);
            return Ok(results);
        }
    }
}

