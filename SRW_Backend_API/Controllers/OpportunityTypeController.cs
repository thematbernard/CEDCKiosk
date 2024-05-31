using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpportunityTypeController : ControllerBase
    {
        private readonly IOpportunityTypeService _opportunityTypeService;

        public OpportunityTypeController(IOpportunityTypeService opportunityTypeService)
        {
            _opportunityTypeService = opportunityTypeService;
        }

        // GET: api/OpportunityType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpportunityTypeDTO>>> GetAll()
        {
            try
            {
                var opportunityTypeDTOs = await _opportunityTypeService.GetAllOpportunityTypes();

                return Ok(opportunityTypeDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/OpportunityType/{opportunityType_ID}
        [HttpGet("{opportunityType_ID}")]
        public async Task<ActionResult<OpportunityTypeDTO>> Get(int opportunityType_ID)
        {
            try
            {
                var opportunityTypeDTO = await _opportunityTypeService.GetOpportunityTypeById(opportunityType_ID);

                if (opportunityTypeDTO == null)
                {
                    return NotFound();
                }

                return Ok(opportunityTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/OpportunityType
        [HttpPost]
        public async Task<ActionResult<OpportunityTypeDTO>> Create(OpportunityTypeDTO newOpportunityTypeDTO)
        {
            try
            {
                await _opportunityTypeService.CreateOpportunityType(newOpportunityTypeDTO);

                return CreatedAtAction(nameof(Get), new { opportunityType_ID = newOpportunityTypeDTO.OpportunityType_ID }, newOpportunityTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/OpportunityType/{opportunityType_ID}
        [HttpPut("{opportunityType_ID}")]
        public async Task<IActionResult> Update(int opportunityType_ID, OpportunityTypeDTO newOpportunityTypeDTO)
        {
            try
            {
                var opportunityTypeDTO = await _opportunityTypeService.GetOpportunityTypeById(opportunityType_ID);

                if (opportunityTypeDTO == null)
                {
                    return NotFound();
                }

                await _opportunityTypeService.UpdateOpportunityType(newOpportunityTypeDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/OpportunityType/{opportunityType_ID}
        [HttpDelete("{opportunityType_ID}")]
        public async Task<IActionResult> Delete(int opportunityType_ID)
        {
            try
            {
                var opportunityTypeDTO = await _opportunityTypeService.GetOpportunityTypeById(opportunityType_ID);

                if (opportunityTypeDTO == null)
                {
                    return NotFound();
                }

                // Remove opportunityType
                await _opportunityTypeService.DeleteOpportunityType(opportunityType_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
