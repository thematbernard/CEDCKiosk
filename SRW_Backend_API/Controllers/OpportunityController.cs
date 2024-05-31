using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunityController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService;
        }

        // GET: api/Opportunity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityDTO>>> GetAll()
        {
            try
            {
                var opportunityDTOs = await _opportunityService.GetAllOpportunities();
                return Ok(opportunityDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Opportunity/{opportunity_ID}
        [HttpGet("{opportunity_ID}")]
        public async Task<ActionResult<OpportunityDTO>> Get(int opportunity_ID)
        {
            try
            {
                var opportunityDTO = await _opportunityService.GetOpportunityById(opportunity_ID);

                if (opportunityDTO == null)
                {
                    return NotFound();
                }

                return Ok(opportunityDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Opportunity
        [HttpPost]
        public async Task<ActionResult<OpportunityDTO>> Create(OpportunityDTO newOpportunityDTO)
        {
            try
            {
                await _opportunityService.CreateOpportunity(newOpportunityDTO);

                return CreatedAtAction(nameof(Get), new { opportunity_ID = newOpportunityDTO.Opportunity_ID }, newOpportunityDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Opportunity/{opportunity_ID}
        [HttpPut("{opportunity_ID}")]
        public async Task<IActionResult> Update(int opportunity_ID, OpportunityDTO newOpportunityDTO)
        {
            try
            {
                var opportunityDTO = await _opportunityService.GetOpportunityById(opportunity_ID);

                if (opportunityDTO == null)
                {
                    return NotFound();
                }

                await _opportunityService.UpdateOpportunity(newOpportunityDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Opportunity/{opportunity_ID}
        [HttpDelete("{opportunity_ID}")]
        public async Task<IActionResult> Delete(int opportunity_ID)
        {
            try
            {
                var opportunityDTO = await _opportunityService.GetOpportunityById(opportunity_ID);

                if (opportunityDTO == null)
                {
                    return NotFound();
                }

                // Remove opportunity
                await _opportunityService.DeleteOpportunity(opportunity_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
