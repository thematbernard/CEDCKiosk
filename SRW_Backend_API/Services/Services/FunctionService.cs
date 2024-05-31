using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }

        public async Task<IEnumerable<FunctionDTO>> GetAllFunctions()
        {
            try
            {
                return await _functionRepository.GetAllFunctions();
            }
            catch
            {
                throw;
            }
        }

        public async Task<FunctionDTO> GetFunctionById(int function_ID)
        {
            try
            {
                return await _functionRepository.GetFunctionById(function_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateFunction(FunctionDTO functionDTO)
        {
            try
            {
                await _functionRepository.CreateFunction(functionDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateFunction(FunctionDTO functionDTO)
        {
            try
            {
                await _functionRepository.UpdateFunction(functionDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteFunction(int function_ID)
        {
            try
            {
                await _functionRepository.DeleteFunction(function_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
