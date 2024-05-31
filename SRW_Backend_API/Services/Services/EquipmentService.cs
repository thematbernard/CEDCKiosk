using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<EquipmentDTO>> GetAllEquipment()
        {
            try
            {
                return await _equipmentRepository.GetAllEquipment();
            }
            catch
            {
                throw;
            }
        }

        public async Task<EquipmentDTO> GetEquipmentById(int equipment_ID)
        {
            try
            {
                return await _equipmentRepository.GetEquipmentById(equipment_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateEquipment(EquipmentDTO equipmentDTO)
        {
            try
            {
                await _equipmentRepository.CreateEquipment(equipmentDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEquipment(EquipmentDTO equipmentDTO)
        {
            try
            {
                await _equipmentRepository.UpdateEquipment(equipmentDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteEquipment(int equipment_ID)
        {
            try
            {
                await _equipmentRepository.DeleteEquipment(equipment_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
