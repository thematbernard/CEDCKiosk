using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AssistanceController : ControllerBase
    {
        private readonly IAssistanceService _assistanceService;

        public AssistanceController(IAssistanceService assistanceService)
        {
            _assistanceService = assistanceService;
        }

        // GET: api/Assistance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssistanceDTO>>> GetAll()
        {
            try
            {
                var assistanceDTOs = await _assistanceService.GetAllAssistances();
                
                return Ok(assistanceDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Assistance/{assistance_ID}
        [HttpGet("{assistance_ID}")]
        public async Task<ActionResult<AssistanceDTO>> Get(int assistance_ID)
        {
            try
            {
                var assistanceDTO = await _assistanceService.GetAssistanceById(assistance_ID);

                if (assistanceDTO == null)
                {
                    return NotFound();
                }

                return Ok(assistanceDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Assistance
        [HttpPost]
        public async Task<ActionResult<AssistanceDTO>> Create(AssistanceDTO newAssistanceDTO)
        {
            try
            {
                await _assistanceService.CreateAssistance(newAssistanceDTO);

                return CreatedAtAction(nameof(Get), new { assistance_ID = newAssistanceDTO.Assistance_ID }, newAssistanceDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Assistance/{assistance_ID}
        [HttpPut("{assistance_ID}")]
        public async Task<IActionResult> Update(int assistance_ID, AssistanceDTO newAssistanceDTO)
        {
            try
            {
                var assistanceDTO = await _assistanceService.GetAssistanceById(assistance_ID);

                if (assistanceDTO == null)
                {
                    return NotFound();
                }

                await _assistanceService.UpdateAssistance(newAssistanceDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Assistance/{assistance_ID}
        [HttpDelete("{assistance_ID}")]
        public async Task<IActionResult> Delete(int assistance_ID)
        {
            try
            {
                var assistanceDTO = await _assistanceService.GetAssistanceById(assistance_ID);

                if (assistanceDTO == null)
                {
                    return NotFound();
                }

                await _assistanceService.DeleteAssistance(assistance_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}