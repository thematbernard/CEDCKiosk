using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDTO>> GetAllTraining();
        Task<TrainingDTO> GetTrainingById(int training_ID);
        Task CreateTraining(TrainingDTO trainingDTO);
        Task UpdateTraining(TrainingDTO trainingDTO);
        Task DeleteTraining(int training_ID);
    }
}
