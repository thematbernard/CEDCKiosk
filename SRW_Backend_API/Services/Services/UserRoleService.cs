using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoles()
        {
            try
            {
                return await _userRoleRepository.GetAllUserRoles();
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
                return await _userRoleRepository.GetUserRoleById(user_ID, role_ID);
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
                await _userRoleRepository.CreateUserRole(userRoleDTO);
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
                await _userRoleRepository.DeleteUserRole(user_ID, role_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}