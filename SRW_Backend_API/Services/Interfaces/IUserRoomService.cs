using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IUserRoomService
    {
        Task<IEnumerable<UserRoomDTO>> GetAllUserRooms();
        Task<UserRoomDTO> GetUserRoomById(int user_ID, int room_ID);
        Task CreateUserRoom(UserRoomDTO userRoomDTO);
        Task DeleteUserRoom(int user_ID, int room_ID);
    }
}