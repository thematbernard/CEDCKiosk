using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Repository.Repositories;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class TrainingService    : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<IEnumerable<TrainingDTO>> GetAllTraining()
        {
            try
            {
                return await _trainingRepository.GetAllTraining();
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
                return await _trainingRepository.GetTrainingById(training_ID);
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
                await _trainingRepository.CreateTraining(trainingDTO);
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
                await _trainingRepository.UpdateTraining(trainingDTO);
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
                await _trainingRepository.DeleteTraining(training_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}

