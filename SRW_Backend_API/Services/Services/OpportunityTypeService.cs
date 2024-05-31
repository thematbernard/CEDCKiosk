using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class OpportunityTypeService : IOpportunityTypeService
    {
        private readonly IOpportunityTypeRepository _opportunityTypeRepository;

        public OpportunityTypeService(IOpportunityTypeRepository opportunityTypeRepository)
        {
            _opportunityTypeRepository = opportunityTypeRepository;
        }

        public async Task<IEnumerable<OpportunityTypeDTO>> GetAllOpportunityTypes()
        {
            try
            {
                return await _opportunityTypeRepository.GetAllOpportunityTypes();
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
                return await _opportunityTypeRepository.GetOpportunityTypeById(opportunityType_ID);
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
                await _opportunityTypeRepository.CreateOpportunityType(opportunityTypeDTO);
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
                await _opportunityTypeRepository.UpdateOpportunityType(opportunityTypeDTO);
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
                await _opportunityTypeRepository.DeleteOpportunityType(opportunityType_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
