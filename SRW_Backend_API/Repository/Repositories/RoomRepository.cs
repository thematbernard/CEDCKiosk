using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SRW_Backend_API.Repository.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public RoomRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            try
            {
                var roomDTOs = await _context.Rooms
                    .Include(r => r.RoomType)
                    .Include(r => r.Image)
                    .Select(r => new RoomDTO
                    {
                        Room_ID = r.Room_ID,
                        RoomType_ID = r.RoomType_ID,
                        Image_ID = r.Image_ID,
                        Room_Name = r.Room_Name,
                        Room_Number = r.Room_Number,
                        Room_Floor = r.Room_Floor,
                        Room_Description = r.Room_Description,

                        RoomType = r.RoomType != null
                            ? new RoomTypeDTO
                            {
                                RoomType_ID = r.RoomType.RoomType_ID,
                                RoomType_Name = r.RoomType.RoomType_Name
                            }
                            : null,

                        Image = r.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = r.Image.Image_ID,
                                Image_Name = r.Image.Image_Name,
                                Image_Address = r.Image.Image_Address
                            }
                            : null
                    })
                    .ToListAsync();

                return roomDTOs;
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
                var roomDTO = await _context.Rooms
                    .Include(r => r.RoomType)
                    .Include(r => r.Image)
                    .Where(r => r.Room_ID == room_ID)
                    .Select(r => new RoomDTO
                    {
                        Room_ID = r.Room_ID,
                        RoomType_ID = r.RoomType_ID,
                        Image_ID = r.Image_ID,
                        Room_Name = r.Room_Name,
                        Room_Number = r.Room_Number,
                        Room_Floor = r.Room_Floor,
                        Room_Description = r.Room_Description,

                        RoomType = r.RoomType != null
                            ? new RoomTypeDTO
                            {
                                RoomType_ID = r.RoomType.RoomType_ID,
                                RoomType_Name = r.RoomType.RoomType_Name
                            }
                            : null,

                        Image = r.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = r.Image.Image_ID,
                                Image_Name = r.Image.Image_Name,
                                Image_Address = r.Image.Image_Address
                            }
                            : null
                    })
                    .SingleOrDefaultAsync();

                return roomDTO;
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
                var room = new Room
                {
                    RoomType = await _context.RoomTypes.FindAsync(roomDTO.RoomType_ID),
                    Image = await _context.Images.FindAsync(roomDTO.Image_ID),
                    Room_Name = roomDTO.Room_Name,
                    Room_Number = roomDTO.Room_Number,
                    Room_Floor = roomDTO.Room_Floor,
                    Room_Description = roomDTO.Room_Description
                };

                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();

                roomDTO.Room_ID = room.Room_ID;
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
                var room = await _context.Rooms
                    .Include(r => r.RoomType)
                    .Include(r => r.Image)
                    .Where(r => r.Room_ID == roomDTO.Room_ID)
                    .FirstOrDefaultAsync();

                if (room == null)
                {
                    throw new Exception("Not Found");
                }

                if (room.RoomType.RoomType_ID != roomDTO.RoomType_ID)
                {
                    room.RoomType = await _context.RoomTypes.FindAsync(roomDTO.RoomType_ID);
                }

                if (room.Image.Image_ID != roomDTO.Image_ID)
                {
                    room.Image = await _context.Images.FindAsync(roomDTO.Image_ID);
                }

                room.Room_Name = roomDTO.Room_Name;
                room.Room_Number = roomDTO.Room_Number;
                room.Room_Floor = roomDTO.Room_Floor;
                room.Room_Description = roomDTO.Room_Description;

                await _context.SaveChangesAsync();
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
                var room = await _context.Rooms.FindAsync(room_ID);

                if (room == null)
                {
                    throw new Exception("Not Found");
                }

                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
