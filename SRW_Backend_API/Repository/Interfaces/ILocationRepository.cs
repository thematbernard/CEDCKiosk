using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationDTO>> GetAllLocations();
        Task<LocationDTO> GetLocationById(int locaiton_ID);
        Task CreateLocation(LocationDTO locationDTO);
        Task UpdateLocation(LocationDTO locationDTO);
        Task DeleteLocation(int locaiton_ID);
    }
}