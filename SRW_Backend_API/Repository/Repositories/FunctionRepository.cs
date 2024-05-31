using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class FunctionRepository : IFunctionRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public FunctionRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FunctionDTO>> GetAllFunctions()
        {
            try
            {
                var functionDTOs = await _context.Functions
                .Include(f => f.Image) // Include the related Image
                .Select(f => new FunctionDTO
                {
                    Function_ID = f.Function_ID,
                    Image_ID = f.Image_ID,
                    Function_Name = f.Function_Name,
                    Function_Address = f.Function_Address,
                    Function_Description = f.Function_Description,

                    Image = f.Image != null
                        ? new ImageDTO
                        {
                            Image_ID = f.Image.Image_ID,
                            Image_Name = f.Image.Image_Name,
                            Image_Address = f.Image.Image_Address
                        }
                        : null
                }).ToListAsync();

                return functionDTOs;
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
                var functionDTO = await _context.Functions
                .Include(f => f.Image) // Include the related Image
                .Where(f => f.Function_ID == function_ID)
                .Select(f => new FunctionDTO
                {
                    Function_ID = f.Function_ID,
                    Image_ID = f.Image_ID,
                    Function_Name = f.Function_Name,
                    Function_Address = f.Function_Address,
                    Function_Description = f.Function_Description,

                    Image = f.Image != null
                        ? new ImageDTO
                        {
                            Image_ID = f.Image.Image_ID,
                            Image_Name = f.Image.Image_Name,
                            Image_Address = f.Image.Image_Address
                        }
                        : null
                }).SingleOrDefaultAsync();

                return functionDTO;
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
                var function = new Function();

                function.Image = await _context.Images.FindAsync(functionDTO.Image_ID);
                function.Function_Name = functionDTO.Function_Name;
                function.Function_Address = functionDTO.Function_Address;
                function.Function_Description = functionDTO.Function_Description;

                await _context.Functions.AddAsync(function);
                await _context.SaveChangesAsync();

                functionDTO.Function_ID = function.Function_ID;
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
                var function = await _context.Functions
                .Include(f => f.Image)
                .Where(f => f.Function_ID == functionDTO.Function_ID).FirstOrDefaultAsync();

                if (function == null)
                {
                    throw new Exception("Not Found");
                }

                if (function.Image.Image_ID != functionDTO.Image_ID)
                {
                    function.Image = await _context.Images.FindAsync(functionDTO.Image_ID);
                }

                function.Function_Name = functionDTO.Function_Name;
                function.Function_Address = string.IsNullOrWhiteSpace(functionDTO.Function_Address) ? null : functionDTO.Function_Address;
                function.Function_Description = string.IsNullOrWhiteSpace(functionDTO.Function_Description) ? null : functionDTO.Function_Description;

                await _context.SaveChangesAsync();
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
                _context.Functions.Remove(await _context.Functions.FindAsync(function_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
