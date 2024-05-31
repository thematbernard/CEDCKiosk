using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.Services.Interfaces;
using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController: ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        //GET: api/Sector
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectorDTO>>> GetAll()
        {
            try
            {
                var sectorDTOs = await _sectorService.GetAllSectors();
                return Ok(sectorDTOs);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //GET: api/Sector/{sector_ID}
        [HttpGet("{sector_ID}")]
        public async Task<ActionResult<SectorDTO>> Get(int sector_ID)
        {
            try
            {
                var sectorDTO = await _sectorService.GetSectorById(sector_ID);
                return Ok(sectorDTO);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST: api/Sector
        [HttpPost]
        public async Task<ActionResult> Create(SectorDTO newsectorDTO)
        {
            try
            {
                await _sectorService.CreateSector(newsectorDTO);
                return CreatedAtAction(nameof(Get), new { sector_ID = newsectorDTO.Sector_ID }, newsectorDTO);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT: api/Sector/{sector_ID}
        [HttpPut("{sector_ID}")]
        public async Task<ActionResult> Update(int sector_ID,SectorDTO newsectorDTO)
        {
            try
            {
                var sectorDTO = await _sectorService.GetSectorById(sector_ID);
                if(sectorDTO == null)
                {
                    return NotFound();
                }

                await _sectorService.UpdateSector(newsectorDTO);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE: api/Sector/{sector_ID}
        [HttpDelete("{sector_ID}")]
        public async Task<ActionResult> Delete(int sector_ID)
        {
            try
            {
                var sectorDTO = await _sectorService.GetSectorById(sector_ID);
                if(sectorDTO == null)
                {
                    return NotFound();
                }

                await _sectorService.DeleteSector(sector_ID);
                return NoContent();
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
