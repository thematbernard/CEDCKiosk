using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllRegistrations()
        {
            try
            {
                return await _registrationRepository.GetAllRegistrations();
            }
            catch
            {
                throw;
            }
        }

        public async Task<RegistrationDTO> GetRegistrationById(int registration_ID)
        {
            try
            {
                return await _registrationRepository.GetRegistrationById(registration_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                await _registrationRepository.CreateRegistration(registrationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                await _registrationRepository.UpdateRegistration(registrationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRegistration(int registration_ID)
        {
            try
            {
                await _registrationRepository.DeleteRegistration(registration_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
