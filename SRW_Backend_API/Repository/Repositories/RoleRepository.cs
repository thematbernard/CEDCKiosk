using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SRW_Backend_API.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public RoleRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            try
            {
                var roleDTOs = await _context.Roles
                    .Select(r => new RoleDTO
                    {
                        Role_ID = r.Role_ID,
                        Role_Name = r.Role_Name,
                        Role_Description = r.Role_Description
                    })
                    .ToListAsync();

                return roleDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RoleDTO> GetRoleById(int role_ID)
        {
            try
            {
                var roleDTO = await _context.Roles
                    .Where(r => r.Role_ID == role_ID)
                    .Select(r => new RoleDTO
                    {
                        Role_ID = r.Role_ID,
                        Role_Name = r.Role_Name,
                        Role_Description = r.Role_Description
                    })
                    .SingleOrDefaultAsync();

                return roleDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRole(RoleDTO roleDTO)
        {
            try
            {
                var role = new Role
                {
                    Role_Name = roleDTO.Role_Name,
                    Role_Description = roleDTO.Role_Description
                };

                await _context.Roles.AddAsync(role);
                await _context.SaveChangesAsync();
                
                roleDTO.Role_ID = role.Role_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRole(RoleDTO roleDTO)
        {
            try
            {
                var role = await _context.Roles
                    .Where(r => r.Role_ID == roleDTO.Role_ID)
                    .FirstOrDefaultAsync();

                if (role == null)
                {
                    throw new Exception("Not Found");
                }

                role.Role_Name = roleDTO.Role_Name;
                role.Role_Description = roleDTO.Role_Description;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRole(int role_ID)
        {
            try
            {
                var role = await _context.Roles
                    .Where(r => r.Role_ID == role_ID)
                    .FirstOrDefaultAsync();

                if (role == null)
                {
                    throw new Exception("Not Found");
                }

                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}