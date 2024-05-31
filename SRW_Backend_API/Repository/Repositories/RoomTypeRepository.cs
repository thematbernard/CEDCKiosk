using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SRW_Backend_API.Repository.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public RoomTypeRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypes()
        {
            try
            {
                var roomTypeDTOs = await _context.RoomTypes
                    .Select(rt => new RoomTypeDTO
                    {
                        RoomType_ID = rt.RoomType_ID,
                        RoomType_Name = rt.RoomType_Name
                    })
                    .ToListAsync();

                return roomTypeDTOs;
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
                var roomTypeDTO = await _context.RoomTypes
                    .Where(rt => rt.RoomType_ID == roomType_ID)
                    .Select(rt => new RoomTypeDTO
                    {
                        RoomType_ID = rt.RoomType_ID,
                        RoomType_Name = rt.RoomType_Name
                    })
                    .SingleOrDefaultAsync();

                return roomTypeDTO;
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
                var roomType = new RoomType
                {
                    RoomType_Name = roomTypeDTO.RoomType_Name
                };

                await _context.RoomTypes.AddAsync(roomType);
                await _context.SaveChangesAsync();

                roomTypeDTO.RoomType_ID = roomType.RoomType_ID;
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
                var roomType = await _context.RoomTypes
                    .Where(rt => rt.RoomType_ID == roomTypeDTO.RoomType_ID)
                    .FirstOrDefaultAsync();

                if (roomType == null)
                {
                    throw new Exception("Not Found");
                }

                roomType.RoomType_Name = roomTypeDTO.RoomType_Name;

                await _context.SaveChangesAsync();
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
                var roomType = await _context.RoomTypes
                    .Where(rt => rt.RoomType_ID == roomType_ID)
                    .FirstOrDefaultAsync();

                if (roomType == null)
                {
                    throw new Exception("Not Found");
                }

                _context.RoomTypes.Remove(roomType);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
