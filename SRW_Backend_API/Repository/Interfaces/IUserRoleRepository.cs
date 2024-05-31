﻿using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoles();
        Task<UserRoleDTO> GetUserRoleById(int user_ID, int role_ID);
        Task CreateUserRole(UserRoleDTO userRoleDTO);
        Task DeleteUserRole(int user_ID, int role_ID);
    }
}