using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class UserRoomService : IUserRoomService
    {
        private readonly IUserRoomRepository _userRoomRepository;

        public UserRoomService(IUserRoomRepository userRoomRepository)
        {
            _userRoomRepository = userRoomRepository;
        }

        public async Task<IEnumerable<UserRoomDTO>> GetAllUserRooms()
        {
            try
            {
                return await _userRoomRepository.GetAllUserRooms();
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserRoomDTO> GetUserRoomById(int user_ID, int room_ID)
        {
            try
            {
                return await _userRoomRepository.GetUserRoomById(user_ID, room_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateUserRoom(UserRoomDTO userRoomDTO)
        {
            try
            {
                await _userRoomRepository.CreateUserRoom(userRoomDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUserRoom(int user_ID, int room_ID)
        {
            try
            {
                await _userRoomRepository.DeleteUserRoom(user_ID, room_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}