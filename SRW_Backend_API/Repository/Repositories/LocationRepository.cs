using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{

    public class LocationRepository : ILocationRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public LocationRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationDTO>> GetAllLocations()
        {
            try
            {
                var locationDTOs = await _context.Locations
                .Select(l => new LocationDTO
                {
                    Location_ID = l.Location_ID,
                    Location_Name = l.Location_Name,
                    Location_Street = l.Location_Street,
                    Location_City = l.Location_City,
                    Location_County = l.Location_County,
                    Location_State = l.Location_State,
                    Location_Country = l.Location_Country,
                    Location_Zip = l.Location_Zip
                }).ToListAsync();

                return locationDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<LocationDTO> GetLocationById(int location_ID)
        {
            try
            {
                var locationDTO = await _context.Locations
                .Where(l => l.Location_ID == location_ID)
                .Select(l => new LocationDTO
                {
                    Location_ID = l.Location_ID,
                    Location_Name = l.Location_Name,
                    Location_Street = l.Location_Street,
                    Location_City = l.Location_City,
                    Location_County = l.Location_County,
                    Location_State = l.Location_State,
                    Location_Country = l.Location_Country,
                    Location_Zip = l.Location_Zip
                }).SingleOrDefaultAsync();

                return locationDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateLocation(LocationDTO locationDTO)
        {
            try
            {
                var location = new Location();


                location.Location_Name = locationDTO.Location_Name;
                location.Location_Street = locationDTO.Location_Street;
                location.Location_City = locationDTO.Location_City;
                location.Location_County = locationDTO.Location_County;
                location.Location_State = locationDTO.Location_State;
                location.Location_Country = locationDTO.Location_Country;
                location.Location_Zip = locationDTO.Location_Zip;

                await _context.Locations.AddAsync(location);
                await _context.SaveChangesAsync();

                locationDTO.Location_ID = location.Location_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateLocation(LocationDTO locationDTO)
        {
            try
            {
                var location = await _context.Locations
                .Where(l => l.Location_ID == locationDTO.Location_ID).FirstOrDefaultAsync();

                if (location == null)
                {
                    throw new Exception("Not Found");
                }

                location.Location_Name = string.IsNullOrWhiteSpace(locationDTO.Location_Name) ? null : locationDTO.Location_Name;
                location.Location_Street = string.IsNullOrWhiteSpace(locationDTO.Location_Street) ? null : locationDTO.Location_Street;
                location.Location_City = string.IsNullOrWhiteSpace(locationDTO.Location_City) ? null : locationDTO.Location_City;
                location.Location_County = string.IsNullOrWhiteSpace(locationDTO.Location_County) ? null : locationDTO.Location_County;
                location.Location_State = string.IsNullOrWhiteSpace(locationDTO.Location_State) ? null : locationDTO.Location_State;
                location.Location_Country = string.IsNullOrWhiteSpace(locationDTO.Location_Country) ? null : locationDTO.Location_Country;
                location.Location_Zip = string.IsNullOrWhiteSpace(locationDTO.Location_Zip) ? null : locationDTO.Location_Zip;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteLocation(int location_ID)
        {
            try
            {
                _context.Locations.Remove(await _context.Locations.FindAsync(location_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}