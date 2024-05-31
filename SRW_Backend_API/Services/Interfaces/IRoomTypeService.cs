using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypes();
        Task<RoomTypeDTO> GetRoomTypeById(int roomType_ID);
        Task CreateRoomType(RoomTypeDTO roomTypeDTO);
        Task UpdateRoomType(RoomTypeDTO roomTypeDTO);
        Task DeleteRoomType(int roomType_ID);
    }
}