using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public EquipmentRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EquipmentDTO>> GetAllEquipment()
        {
            try
            {
                var equipmentDTOs = await _context.Equipments
                    .Include(e => e.Image) // Include the related Image
                    .Include(e => e.Role)  // Include the related Role
                    .Select(e => new EquipmentDTO
                    {
                        Equipment_ID = e.Equipment_ID,
                        Image_ID = e.Image_ID,
                        Role_ID = e.Role_ID,
                        Equipment_Name = e.Equipment_Name,
                        Equipment_Quantity = e.Equipment_Quantity,
                        Equipment_Available = e.Equipment_Available,
                        Equipment_Description = e.Equipment_Description,

                        Role = e.Role != null
                            ? new RoleDTO
                            {
                                Role_ID = e.Role.Role_ID,
                                Role_Name = e.Role.Role_Name,
                                Role_Description = e.Role.Role_Description
                            }
                            : null,

                        Image = e.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = e.Image.Image_ID,
                                Image_Name = e.Image.Image_Name,
                                Image_Address = e.Image.Image_Address
                            }
                            : null
                    }).ToListAsync();

                return equipmentDTOs;
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
                var equipmentDTO = await _context.Equipments
                    .Include(e => e.Image) // Include the related Image
                    .Include(e => e.Role)  // Include the related Role
                    .Where(e => e.Equipment_ID == equipment_ID)
                    .Select(e => new EquipmentDTO
                    {
                        Equipment_ID = e.Equipment_ID,
                        Image_ID = e.Image_ID,
                        Role_ID = e.Role_ID,
                        Equipment_Name = e.Equipment_Name,
                        Equipment_Quantity = e.Equipment_Quantity,
                        Equipment_Available = e.Equipment_Available,
                        Equipment_Description = e.Equipment_Description,

                        Role = e.Role != null
                            ? new RoleDTO
                            {
                                Role_ID = e.Role.Role_ID,
                                Role_Name = e.Role.Role_Name,
                                Role_Description = e.Role.Role_Description
                            }
                            : null,

                        Image = e.Image != null
                            ? new ImageDTO
                            {
                                Image_ID = e.Image.Image_ID,
                                Image_Name = e.Image.Image_Name,
                                Image_Address = e.Image.Image_Address
                            }
                            : null
                    }).SingleOrDefaultAsync();

                return equipmentDTO;
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
                var equipment = new Equipment();

                equipment.Image = await _context.Images.FindAsync(equipmentDTO.Image_ID);
                equipment.Role = await _context.Roles.FindAsync(equipmentDTO.Role_ID);
                equipment.Equipment_Name = equipmentDTO.Equipment_Name;
                equipment.Equipment_Quantity = equipmentDTO.Equipment_Quantity;
                equipment.Equipment_Available = equipmentDTO.Equipment_Available;
                equipment.Equipment_Description = equipmentDTO.Equipment_Description;

                await _context.Equipments.AddAsync(equipment);
                await _context.SaveChangesAsync();

                equipmentDTO.Equipment_ID = equipment.Equipment_ID;
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
                var equipment = await _context.Equipments
                    .Include(e => e.Image)
                    .Include(e => e.Role)
                    .Where(e => e.Equipment_ID == equipmentDTO.Equipment_ID)
                    .FirstOrDefaultAsync();

                if (equipment == null)
                {
                    throw new Exception("Not Found");
                }

                if (equipment.Image.Image_ID != equipmentDTO.Image_ID)
                {
                    equipment.Image = await _context.Images.FindAsync(equipmentDTO.Image_ID);
                }

                if (equipment.Role.Role_ID != equipmentDTO.Role_ID)
                {
                    equipment.Role = await _context.Roles.FindAsync(equipmentDTO.Role_ID);
                }

                equipment.Equipment_Name = equipmentDTO.Equipment_Name;
                equipment.Equipment_Quantity = equipmentDTO.Equipment_Quantity;
                equipment.Equipment_Available = equipmentDTO.Equipment_Available;
                equipment.Equipment_Description = equipmentDTO.Equipment_Description;

                await _context.SaveChangesAsync();
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
                _context.Equipments.Remove(await _context.Equipments.FindAsync(equipment_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}