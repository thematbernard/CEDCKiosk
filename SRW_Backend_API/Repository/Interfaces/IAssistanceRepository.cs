using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IAssistanceRepository
    {
        Task<IEnumerable<AssistanceDTO>> GetAllAssistances();
        Task<AssistanceDTO> GetAssistanceById(int assistance_ID);
        Task CreateAssistance(AssistanceDTO assistanceDTO);
        Task UpdateAssistance(AssistanceDTO assistanceDTO);
        Task DeleteAssistance(int assistance_ID);
    }
}