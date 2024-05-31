using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class AssistanceService : IAssistanceService
    {
        private readonly IAssistanceRepository _assistanceRepository;

        public AssistanceService(IAssistanceRepository assistanceRepository)
        {
            _assistanceRepository = assistanceRepository;
        }

        public async Task<IEnumerable<AssistanceDTO>> GetAllAssistances()
        {
            try
            {
                return await _assistanceRepository.GetAllAssistances();
            }
            catch
            {
                throw;
            }
        }

        public async Task<AssistanceDTO> GetAssistanceById(int assistance_ID)
        {
            try
            {
                return await _assistanceRepository.GetAssistanceById(assistance_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateAssistance(AssistanceDTO assistanceDTO)
        {
            try
            {
                await _assistanceRepository.CreateAssistance(assistanceDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAssistance(AssistanceDTO assistanceDTO)
        {
            try
            {
                await _assistanceRepository.UpdateAssistance(assistanceDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAssistance(int assistance_ID)
        {
            try
            {
                await _assistanceRepository.DeleteAssistance(assistance_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
