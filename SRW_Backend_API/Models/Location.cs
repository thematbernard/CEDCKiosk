using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Location
    {
        public int Location_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_County { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location_Zip { get; set; }
    }
}