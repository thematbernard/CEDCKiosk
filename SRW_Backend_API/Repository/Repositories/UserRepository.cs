using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public UserRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                var userDTOs = await _context.Users
                    .Select(u => new UserDTO
                    {
                        User_ID = u.User_ID,
                        User_First_Name = u.User_First_Name,
                        User_Last_Name = u.User_Last_Name,
                        User_Phone = u.User_Phone,
                        User_Email = u.User_Email,
                        User_Password = u.User_Password
                    })
                    .ToListAsync();

                return userDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserDTO> GetUserById(int user_ID)
        {
            try
            {
                var userDTO = await _context.Users
                    .Where(u => u.User_ID == user_ID)
                    .Select(u => new UserDTO
                    {
                        User_ID = u.User_ID,
                        User_First_Name = u.User_First_Name,
                        User_Last_Name = u.User_Last_Name,
                        User_Phone = u.User_Phone,
                        User_Email = u.User_Email,
                        User_Password = u.User_Password
                    })
                    .SingleOrDefaultAsync();

                return userDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateUser(UserDTO userDTO)
        {
            try
            {
                var user = new User
                {
                    User_First_Name = userDTO.User_First_Name,
                    User_Last_Name = userDTO.User_Last_Name,
                    User_Phone = userDTO.User_Phone,
                    User_Email = userDTO.User_Email,
                    User_Password = userDTO.User_Password
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                
                userDTO.User_ID = user.User_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.User_ID == userDTO.User_ID)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("Not Found");
                }

                user.User_First_Name = userDTO.User_First_Name;
                user.User_Last_Name = userDTO.User_Last_Name;
                user.User_Phone = userDTO.User_Phone;
                user.User_Email = userDTO.User_Email;
                user.User_Password = userDTO.User_Password;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUser(int user_ID)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.User_ID == user_ID)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("Not Found");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
