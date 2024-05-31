using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IUserRoomRepository
    {
        Task<IEnumerable<UserRoomDTO>> GetAllUserRooms();
        Task<UserRoomDTO> GetUserRoomById(int user_ID, int room_ID);
        Task CreateUserRoom(UserRoomDTO userRoomDTO);
        Task DeleteUserRoom(int user_ID, int room_ID);
    }
}