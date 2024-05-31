using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAll()
        {
            try
            {
                var roleDTOs = await _roleService.GetAllRoles();

                return Ok(roleDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Role/{role_ID}
        [HttpGet("{role_ID}")]
        public async Task<ActionResult<RoleDTO>> Get(int role_ID)
        {
            try
            {
                var roleDTO = await _roleService.GetRoleById(role_ID);

                if (roleDTO == null)
                {
                    return NotFound();
                }

                return Ok(roleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> Create(RoleDTO newRoleDTO)
        {
            try
            {
                await _roleService.CreateRole(newRoleDTO);

                return CreatedAtAction(nameof(Get), new { role_ID = newRoleDTO.Role_ID }, newRoleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Role/{role_ID}
        [HttpPut("{role_ID}")]
        public async Task<IActionResult> Update(int role_ID, RoleDTO newRoleDTO)
        {
            try
            {
                var roleDTO = await _roleService.GetRoleById(role_ID);

                if (roleDTO == null)
                {
                    return NotFound();
                }

                await _roleService.UpdateRole(newRoleDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Role/{role_ID}
        [HttpDelete("{role_ID}")]
        public async Task<IActionResult> Delete(int role_ID)
        {
            try
            {
                var roleDTO = await _roleService.GetRoleById(role_ID);

                if (roleDTO == null)
                {
                    return NotFound();
                }

                // Remove role
                await _roleService.DeleteRole(role_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
