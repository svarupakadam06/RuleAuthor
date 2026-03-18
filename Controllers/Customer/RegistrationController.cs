using Microsoft.AspNetCore.Mvc;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Interfaces;

namespace FraudMonitoringSystem.Controllers
{
    /// <summary>
    /// API Controller for registration endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            var response = await _service.RegisterAsync(registration);
            return Ok(response);
        }

        [HttpGet("role/{role}")]
        public async Task<IActionResult> GetUserByRole(RegisterRole role)
        {
            var user = await _service.GetUserByRoleAsync(role);
            return Ok(user);
        }

        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = Enum.GetNames(typeof(RegisterRole));
            return Ok(roles);
            // Returns ["Analyst","Investigator","Compliance","Modeler","Admin"]
        }
        //[HttpGet("admin/system-users")]
        //public async Task<IActionResult> GetSystemUsers()
        //{
        //    var users = await _service.GetSystemUsersAsync();
        //    return Ok(users);
        //}
    }
}
