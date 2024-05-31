using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                return await _userRepository.GetAllUsers();
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
                return await _userRepository.GetUserById(user_ID);
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
                await _userRepository.CreateUser(userDTO);
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
                await _userRepository.UpdateUser(userDTO);
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
                await _userRepository.DeleteUser(user_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}