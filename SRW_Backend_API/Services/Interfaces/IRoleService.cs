using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleById(int role_ID);
        Task CreateRole(RoleDTO roleDTO);
        Task UpdateRole(RoleDTO roleDTO);
        Task DeleteRole(int role_ID);
    }
}