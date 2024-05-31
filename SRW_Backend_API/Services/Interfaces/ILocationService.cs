using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAllLocations();
        Task<LocationDTO> GetLocationById(int locaiton_ID);
        Task CreateLocation(LocationDTO locationDTO);
        Task UpdateLocation(LocationDTO locationDTO);
        Task DeleteLocation(int locaiton_ID);
    }
}