using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocations()
        {
            try
            {
                return await _locationRepository.GetAllLocations();
            }
            catch
            {
                throw;
            }
        }

        public async Task<LocationDTO> GetLocationById(int locaiton_ID)
        {
            try
            {
                return await _locationRepository.GetLocationById(locaiton_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateLocation(LocationDTO locationDTO)
        {
            try
            {
                await _locationRepository.CreateLocation(locationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateLocation(LocationDTO locationDTO)
        {
            try
            {
                await _locationRepository.UpdateLocation(locationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteLocation(int locaiton_ID)
        {
            try
            {
                await _locationRepository.DeleteLocation(locaiton_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
