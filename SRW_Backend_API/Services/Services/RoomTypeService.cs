using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypes()
        {
            try
            {
                return await _roomTypeRepository.GetAllRoomTypes();
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoomTypeDTO> GetRoomTypeById(int roomType_ID)
        {
            try
            {
                return await _roomTypeRepository.GetRoomTypeById(roomType_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRoomType(RoomTypeDTO roomTypeDTO)
        {
            try
            {
                await _roomTypeRepository.CreateRoomType(roomTypeDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRoomType(RoomTypeDTO roomTypeDTO)
        {
            try
            {
                await _roomTypeRepository.UpdateRoomType(roomTypeDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRoomType(int roomType_ID)
        {
            try
            {
                await _roomTypeRepository.DeleteRoomType(roomType_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
