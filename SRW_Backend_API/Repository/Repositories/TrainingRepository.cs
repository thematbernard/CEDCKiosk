using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public TrainingRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingDTO>> GetAllTraining()
        {
            try
            {
                var trainingDTOs = await _context.Training
                    .Include(e => e.Image) // Include the related Image
                    .Select(e => new TrainingDTO
                    {
                        Training_ID = e.Training_ID,
                        Image_ID = e.Image_ID,
                        Training_Name = e.Training_Name,
                        Training_Certificate = e.Training_Certificate,
                        Training_Link = e.Training_Link,
                        Training_Description = e.Training_Description,

                        Image = e.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = e.Image.Image_ID,
                                Image_Name = e.Image.Image_Name,
                                Image_Address = e.Image.Image_Address
                            }
                            : null
                    }).ToListAsync();

                return trainingDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TrainingDTO> GetTrainingById(int training_ID)
        {
            try
            {
                var trainingDTO = await _context.Training
                    .Include(e => e.Image) // Include the related Image
                    .Where(e => e.Training_ID == training_ID)
                    .Select(e => new TrainingDTO
                    {
                        Training_ID = e.Training_ID,
                        Image_ID = e.Image_ID,
                        Training_Name = e.Training_Name,
                        Training_Certificate = e.Training_Certificate,
                        Training_Link = e.Training_Link,
                        Training_Description = e.Training_Description,

                        Image = e.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = e.Image.Image_ID,
                                Image_Name = e.Image.Image_Name,
                                Image_Address = e.Image.Image_Address
                            }
                            : null
                    }).SingleOrDefaultAsync();

                return trainingDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateTraining(TrainingDTO trainingDTO)
        {
            try
            {
                var training = new Training();

                training.Training_Name = trainingDTO.Training_Name;
                training.Training_Certificate = trainingDTO.Training_Certificate;
                training.Training_Link = trainingDTO.Training_Link;
                training.Training_Description = trainingDTO.Training_Description;

                await _context.Training.AddAsync(training);
                await _context.SaveChangesAsync();

                trainingDTO.Training_ID = training.Training_ID;

            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateTraining(TrainingDTO trainingDTO)
        {
            try
            {
                var training = await _context.Training
                    .Include(e => e.Image)
                    .Where(e => e.Training_ID == trainingDTO.Training_ID)
                    .FirstOrDefaultAsync();

                if (training == null)
                {
                    throw new Exception("Not Found");
                }

                if (training.Image.Image_ID != trainingDTO.Image_ID)
                {
                    training.Image = await _context.Images.FindAsync(trainingDTO.Image_ID);
                }


                training.Training_Name = trainingDTO.Training_Name;
                training.Training_Certificate = trainingDTO.Training_Certificate;
                training.Training_Link = trainingDTO.Training_Link;
                training.Training_Description = trainingDTO.Training_Description;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteTraining(int training_ID)
        {
            try
            {
                _context.Training.Remove(await _context.Training.FindAsync(training_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}

