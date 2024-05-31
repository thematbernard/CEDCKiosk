using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<EquipmentDTO>> GetAllEquipment();
        Task<EquipmentDTO> GetEquipmentById(int equipment_ID);
        Task CreateEquipment(EquipmentDTO equipmentDTO);
        Task UpdateEquipment(EquipmentDTO equipmentDTO);
        Task DeleteEquipment(int equipment_ID);
    }
}