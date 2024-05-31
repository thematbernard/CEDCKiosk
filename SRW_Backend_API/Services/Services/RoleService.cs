using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            try
            {
                return await _roleRepository.GetAllRoles();
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
                return await _roleRepository.GetRoleById(role_ID);
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
                await _roleRepository.CreateRole(roleDTO);
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
                await _roleRepository.UpdateRole(roleDTO);
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
                await _roleRepository.DeleteRole(role_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
