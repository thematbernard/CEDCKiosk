using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDTO>> GetAllRegistrations();
        Task<RegistrationDTO> GetRegistrationById(int registration_ID);
        Task CreateRegistration(RegistrationDTO registrationDTO);
        Task UpdateRegistration(RegistrationDTO registrationDTO);
        Task DeleteRegistration(int registration_ID);
    }
}