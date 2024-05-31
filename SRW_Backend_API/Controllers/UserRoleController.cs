using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        // GET: api/UserRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDTO>>> GetAll()
        {
            try
            {
                var userRoleDTOs = await _userRoleService.GetAllUserRoles();

                return Ok(userRoleDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/UserRole/{user_ID}/{role_ID}
        [HttpGet("{user_ID}/{role_ID}")]
        public async Task<ActionResult<UserRoleDTO>> Get(int user_ID, int role_ID)
        {
            try
            {
                var userRoleDTO = await _userRoleService.GetUserRoleById(user_ID, role_ID);

                if (userRoleDTO == null)
                {
                    return NotFound();
                }

                return Ok(userRoleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/UserRole
        [HttpPost]
        public async Task<ActionResult<UserRoleDTO>> Create(UserRoleDTO newUserRoleDTO)
        {
            try
            {
                await _userRoleService.CreateUserRole(newUserRoleDTO);

                return CreatedAtAction(nameof(Get), new { user_ID = newUserRoleDTO.User_ID, role_ID = newUserRoleDTO.Role_ID }, newUserRoleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/UserRole/{user_ID}/{role_ID}
        [HttpDelete("{user_ID}/{role_ID}")]
        public async Task<IActionResult> Delete(int user_ID, int role_ID)
        {
            try
            {
                var userRoleDTO = await _userRoleService.GetUserRoleById(user_ID, role_ID);

                if (userRoleDTO == null)
                {
                    return NotFound();
                }

                await _userRoleService.DeleteUserRole(user_ID, role_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
