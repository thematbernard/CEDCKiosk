using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleById(int role_ID);
        Task CreateRole(RoleDTO roleDTO);
        Task UpdateRole(RoleDTO roleDTO);
        Task DeleteRole(int role_ID);
    }
}