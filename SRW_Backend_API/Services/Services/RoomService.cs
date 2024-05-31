using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            try
            {
                return await _roomRepository.GetAllRooms();
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoomDTO> GetRoomById(int room_ID)
        {
            try
            {
                return await _roomRepository.GetRoomById(room_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRoom(RoomDTO roomDTO)
        {
            try
            {
                await _roomRepository.CreateRoom(roomDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRoom(RoomDTO roomDTO)
        {
            try
            {
                await _roomRepository.UpdateRoom(roomDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRoom(int room_ID)
        {
            try
            {
                await _roomRepository.DeleteRoom(room_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
