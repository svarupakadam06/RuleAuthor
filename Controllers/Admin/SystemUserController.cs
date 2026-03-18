using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Models.Admin;
using FraudMonitoringSystem.Models.Customer;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [ApiController]
    [Route("api/system-users")]
    public class SystemUsersController : ControllerBase
    {
        private readonly ISystemUserService _service;
        public SystemUsersController(ISystemUserService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10) =>
            Ok(await _service.GetAllAsync(page, pageSize));

        [HttpGet("by-role/{roleId:int}")]
        public async Task<IActionResult> GetByRoleId(int roleId) =>
            Ok(await _service.GetByRoleIdAsync(roleId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SystemUserCreateDto dto)
        {
            await _service.AddAsync(dto);
            return StatusCode(201);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}