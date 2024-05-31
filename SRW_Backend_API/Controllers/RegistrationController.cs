using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        // GET: api/Registration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationDTO>>> GetAll()
        {
            try
            {
                var registrationDTOs = await _registrationService.GetAllRegistrations();

                return Ok(registrationDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Registration/{registration_ID}
        [HttpGet("{registration_ID}")]
        public async Task<ActionResult<RegistrationDTO>> Get(int registration_ID)
        {
            try
            {
                var registrationDTO = await _registrationService.GetRegistrationById(registration_ID);

                if (registrationDTO == null)
                {
                    return NotFound();
                }

                return Ok(registrationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<ActionResult<RegistrationDTO>> Create(RegistrationDTO newRegistrationDTO)
        {
            try
            {
                await _registrationService.CreateRegistration(newRegistrationDTO);

                return CreatedAtAction(nameof(Get), new { registration_ID = newRegistrationDTO.Registration_ID }, newRegistrationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Registration/{registration_ID}
        [HttpPut("{registration_ID}")]
        public async Task<IActionResult> Update(int registration_ID, RegistrationDTO newRegistrationDTO)
        {
            try
            {
                var registrationDTO = await _registrationService.GetRegistrationById(registration_ID);

                if (registrationDTO == null)
                {
                    return NotFound();
                }

                await _registrationService.UpdateRegistration(newRegistrationDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Registration/{registration_ID}
        [HttpDelete("{registration_ID}")]
        public async Task<IActionResult> Delete(int registration_ID)
        {
            try
            {
                var registrationDTO = await _registrationService.GetRegistrationById(registration_ID);

                if (registrationDTO == null)
                {
                    return NotFound();
                }

                // Remove registration
                await _registrationService.DeleteRegistration(registration_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}