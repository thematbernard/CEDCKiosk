using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SRW_Backend_API.Repository.Repositories
{
    public class OpportunityTypeRepository : IOpportunityTypeRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public OpportunityTypeRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpportunityTypeDTO>> GetAllOpportunityTypes()
        {
            try
            {
                var opportunityTypeDTOs = await _context.OpportunityTypes
                    .Select(ot => new OpportunityTypeDTO
                    {
                        OpportunityType_ID = ot.OpportunityType_ID,
                        OpportunityType_Name = ot.OpportunityType_Name
                    })
                    .ToListAsync();

                return opportunityTypeDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OpportunityTypeDTO> GetOpportunityTypeById(int opportunityType_ID)
        {
            try
            {
                var opportunityTypeDTO = await _context.OpportunityTypes
                    .Where(ot => ot.OpportunityType_ID == opportunityType_ID)
                    .Select(ot => new OpportunityTypeDTO
                    {
                        OpportunityType_ID = ot.OpportunityType_ID,
                        OpportunityType_Name = ot.OpportunityType_Name
                    })
                    .SingleOrDefaultAsync();

                return opportunityTypeDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateOpportunityType(OpportunityTypeDTO opportunityTypeDTO)
        {
            try
            {
                var opportunityType = new OpportunityType
                {
                    OpportunityType_Name = opportunityTypeDTO.OpportunityType_Name
                };

                await _context.OpportunityTypes.AddAsync(opportunityType);
                await _context.SaveChangesAsync();

                opportunityTypeDTO.OpportunityType_ID = opportunityType.OpportunityType_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateOpportunityType(OpportunityTypeDTO opportunityTypeDTO)
        {
            try
            {
                var opportunityType = await _context.OpportunityTypes
                    .Where(ot => ot.OpportunityType_ID == opportunityTypeDTO.OpportunityType_ID)
                    .FirstOrDefaultAsync();

                if (opportunityType == null)
                {
                    throw new Exception("Not Found");
                }

                opportunityType.OpportunityType_Name = opportunityTypeDTO.OpportunityType_Name;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteOpportunityType(int opportunityType_ID)
        {
            try
            {
                var opportunityType = await _context.OpportunityTypes
                    .Where(ot => ot.OpportunityType_ID == opportunityType_ID)
                    .FirstOrDefaultAsync();

                if (opportunityType == null)
                {
                    throw new Exception("Not Found");
                }

                _context.OpportunityTypes.Remove(opportunityType);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
