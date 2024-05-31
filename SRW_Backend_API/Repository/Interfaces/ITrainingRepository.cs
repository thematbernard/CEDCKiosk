using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<TrainingDTO>> GetAllTraining();
        Task<TrainingDTO> GetTrainingById(int training_ID);
        Task CreateTraining(TrainingDTO trainingDTO);
        Task UpdateTraining(TrainingDTO trainingDTO);
        Task DeleteTraining(int training_ID);
    }
}
