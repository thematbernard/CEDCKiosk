using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IFunctionRepository
    {
        Task<IEnumerable<FunctionDTO>> GetAllFunctions();
        Task<FunctionDTO> GetFunctionById(int function_ID);
        Task CreateFunction(FunctionDTO functionDTO);
        Task UpdateFunction(FunctionDTO functionDTO);
        Task DeleteFunction(int function_ID);
    }
}