using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IOpportunityRepository _opportunityRepository;

        public OpportunityService(IOpportunityRepository opportunityRepository)
        {
            _opportunityRepository = opportunityRepository;
        }

        public async Task<IEnumerable<OpportunityDTO>> GetAllOpportunities()
        {
            try
            {
                return await _opportunityRepository.GetAllOpportunities();
            }
            catch
            {
                throw;
            }
        }

        public async Task<OpportunityDTO> GetOpportunityById(int opportunity_ID)
        {
            try
            {
                return await _opportunityRepository.GetOpportunityById(opportunity_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateOpportunity(OpportunityDTO opportunityDTO)
        {
            try
            {
                await _opportunityRepository.CreateOpportunity(opportunityDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateOpportunity(OpportunityDTO opportunityDTO)
        {
            try
            {
                await _opportunityRepository.UpdateOpportunity(opportunityDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteOpportunity(int opportunity_ID)
        {
            try
            {
                await _opportunityRepository.DeleteOpportunity(opportunity_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}