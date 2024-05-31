using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Sector
    {
        public int Sector_ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sector_Name { get; set; }
    }
}
