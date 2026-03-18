using FraudMonitoringSystem.DTOs.Admin;
using FraudMonitoringSystem.Services.Customer.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace FraudMonitoringSystem.Controllers.Admin
{
    [ApiController]

    //[Authorize(Roles = "Admin")]

    [Route("api/roles")]

    public class RoleController : ControllerBase

    {

        private readonly IRoleService _service;

        public RoleController(IRoleService service) => _service = service;

        [HttpGet]

        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] RoleCreateDto dto)

        {

            var msg = await _service.CreateAsync(dto);

            return StatusCode(201, new { message = msg });

        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Update(int id, [FromBody] RoleUpdateDto dto)

        {

            var msg = await _service.UpdateAsync(id, dto);

            return Ok(new { message = msg });

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)

        {

            var msg = await _service.DeleteAsync(id);

            return Ok(new { message = msg });

        }

    }

}
