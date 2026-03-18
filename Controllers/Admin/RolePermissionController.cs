using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [ApiController]
    [Route("api/role-permissions")]
    public class RolePermissionsController : ControllerBase
    {
        private readonly IRolePermissionService _service;
        public RolePermissionsController(IRolePermissionService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolePermissionCreateDto dto)
        {
            var msg = await _service.AssignPermissionAsync(dto);
            return StatusCode(201, new { message = msg });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var msg = await _service.RemovePermissionAsync(id);
            return NoContent();
        }
    }
}