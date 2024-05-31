﻿using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IOpportunityService
    {
        Task<IEnumerable<OpportunityDTO>> GetAllOpportunities();
        Task<OpportunityDTO> GetOpportunityById(int opportunity_ID);
        Task CreateOpportunity(OpportunityDTO opportunityDTO);
        Task UpdateOpportunity(OpportunityDTO opportunityDTO);
        Task DeleteOpportunity(int opportunity_ID);
    }
}