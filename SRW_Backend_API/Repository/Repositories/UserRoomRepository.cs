using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class UserRoomRepository : IUserRoomRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public UserRoomRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<UserRoomDTO>> GetAllUserRooms()
        {
            try
            {
                var userRoomDTOs = await _context.UserRooms
                .Include(ur => ur.User) // Include the related User
                .Include(ur => ur.Room) // Include the related Room
                .Select(ur => new UserRoomDTO
                {
                    User_ID = ur.User_ID,
                    Room_ID = ur.Room_ID,

                    User = ur.User != null
                        ? new UserDTO
                        {
                            User_ID = ur.User_ID,
                            User_First_Name = ur.User.User_First_Name,
                            User_Last_Name = ur.User.User_Last_Name,
                            User_Phone = ur.User.User_Phone,
                            User_Email = ur.User.User_Email,
                            User_Password = ur.User.User_Password
                        }
                        : null,

                    Room = ur.Room != null
                        ? new RoomDTO
                        {
                            Room_ID = ur.Room_ID,
                            RoomType_ID = ur.Room.RoomType_ID,
                            Image_ID = ur.Room.Image_ID,
                            Room_Name = ur.Room.Room_Name,
                            Room_Number = ur.Room.Room_Number,
                            Room_Floor = ur.Room.Room_Floor,
                            Room_Description = ur.Room.Room_Description,

                            RoomType = ur.Room.RoomType != null
                            ? new RoomTypeDTO
                            {
                                RoomType_ID = ur.Room.RoomType.RoomType_ID,
                                RoomType_Name = ur.Room.RoomType.RoomType_Name
                            }
                            : null,

                            Image = ur.Room.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = ur.Room.Image.Image_ID,
                                Image_Name = ur.Room.Image.Image_Name,
                                Image_Address = ur.Room.Image.Image_Address
                            }
                            : null
                        }
                        : null
                }).ToListAsync();

                return userRoomDTOs;
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
                var userRoomDTO = await _context.UserRooms
                .Include(ur => ur.User) // Include the related User
                .Include(ur => ur.Room) // Include the related Room
                .Where(ur => ur.User_ID == user_ID && ur.Room_ID == room_ID)
                .Select(ur => new UserRoomDTO
                {
                    User_ID = ur.User_ID,
                    Room_ID = ur.Room_ID,

                    User = ur.User != null
                        ? new UserDTO
                        {
                            User_ID = ur.User_ID,
                            User_First_Name = ur.User.User_First_Name,
                            User_Last_Name = ur.User.User_Last_Name,
                            User_Phone = ur.User.User_Phone,
                            User_Email = ur.User.User_Email,
                            User_Password = ur.User.User_Password
                        }
                        : null,

                    Room = ur.Room != null
                        ? new RoomDTO
                        {
                            Room_ID = ur.Room_ID,
                            RoomType_ID = ur.Room.RoomType_ID,
                            Image_ID = ur.Room.Image_ID,
                            Room_Name = ur.Room.Room_Name,
                            Room_Number = ur.Room.Room_Number,
                            Room_Floor = ur.Room.Room_Floor,
                            Room_Description = ur.Room.Room_Description,

                            RoomType = ur.Room.RoomType != null
                            ? new RoomTypeDTO
                            {
                                RoomType_ID = ur.Room.RoomType.RoomType_ID,
                                RoomType_Name = ur.Room.RoomType.RoomType_Name
                            }
                            : null,

                            Image = ur.Room.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = ur.Room.Image.Image_ID,
                                Image_Name = ur.Room.Image.Image_Name,
                                Image_Address = ur.Room.Image.Image_Address
                            }
                            : null
                        }
                        : null
                }).SingleOrDefaultAsync();

                return userRoomDTO;
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
                var userRoom = new UserRoom();

                userRoom.User = await _context.Users.FindAsync(userRoomDTO.User_ID);
                userRoom.Room = await _context.Rooms.FindAsync(userRoomDTO.Room_ID);

                await _context.UserRooms.AddAsync(userRoom);
                await _context.SaveChangesAsync();
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
                _context.UserRooms.Remove(await _context.UserRooms.FindAsync(user_ID, room_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}