using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public UserRoleRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoles()
        {
            try
            {
                var userRoleDTOs = await _context.UserRoles
                .Include(ur => ur.User) // Include the related User
                .Include(ur => ur.Role) // Include the related Role
                .Select(ur => new UserRoleDTO
                {
                    User_ID = ur.User_ID,
                    Role_ID = ur.Role_ID,

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

                    Role = ur.Role != null
                        ? new RoleDTO
                        {
                            Role_ID = ur.Role_ID,
                            Role_Name = ur.Role.Role_Name,
                            Role_Description = ur.Role.Role_Description
                        }
                        : null
                }).ToListAsync();

                return userRoleDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserRoleDTO> GetUserRoleById(int user_ID, int role_ID)
        {
            try
            {
                var userRoleDTO = await _context.UserRoles
                .Include(ur => ur.User) // Include the related User
                .Include(ur => ur.Role) // Include the related Role
                .Where(ur => ur.User_ID == user_ID && ur.Role_ID == role_ID)
                .Select(ur => new UserRoleDTO
                {
                    User_ID = ur.User_ID,
                    Role_ID = ur.Role_ID,

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

                    Role = ur.Role != null
                        ? new RoleDTO
                        {
                            Role_ID = ur.Role_ID,
                            Role_Name = ur.Role.Role_Name,
                            Role_Description = ur.Role.Role_Description
                        }
                        : null
                }).SingleOrDefaultAsync();

                return userRoleDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateUserRole(UserRoleDTO userRoleDTO)
        {
            try
            {
                var userRole = new UserRole();

                userRole.User = await _context.Users.FindAsync(userRoleDTO.User_ID);
                userRole.Role = await _context.Roles.FindAsync(userRoleDTO.Role_ID);

                await _context.UserRoles.AddAsync(userRole);
                await _context.SaveChangesAsync();
                //set User Data
                userRoleDTO.User = new UserDTO();
                userRoleDTO.User.User_ID = userRole.User.User_ID;
                userRoleDTO.User.User_Phone = userRole.User.User_Phone;
                userRoleDTO.User.User_First_Name = userRole.User.User_First_Name;
                userRoleDTO.User.User_Last_Name = userRole.User.User_Last_Name;
                userRoleDTO.User.User_Email = userRole.User.User_Email;

                //set Role Data
                userRoleDTO.Role = new RoleDTO();
                userRoleDTO.Role.Role_ID = userRole.Role.Role_ID;
                userRoleDTO.Role.Role_Name = userRole.Role.Role_Name;
                userRoleDTO.Role.Role_Description = userRole.Role.Role_Description;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteUserRole(int user_ID, int role_ID)
        {
            try
            {
                _context.UserRoles.Remove(await _context.UserRoles.FindAsync(user_ID, role_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}