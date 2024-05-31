using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();
        Task<RoomDTO> GetRoomById(int room_ID);
        Task CreateRoom(RoomDTO roomDTO);
        Task UpdateRoom(RoomDTO roomDTO);
        Task DeleteRoom(int room_ID);
    }
}