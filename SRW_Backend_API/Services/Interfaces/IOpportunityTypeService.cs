using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IOpportunityTypeService
    {
        Task<IEnumerable<OpportunityTypeDTO>> GetAllOpportunityTypes();
        Task<OpportunityTypeDTO> GetOpportunityTypeById(int opportunityType_ID);
        Task CreateOpportunityType(OpportunityTypeDTO opportunityTypeDTO);
        Task UpdateOpportunityType(OpportunityTypeDTO opportunityTypeDTO);
        Task DeleteOpportunityType(int opportunityType_ID);
    }
}