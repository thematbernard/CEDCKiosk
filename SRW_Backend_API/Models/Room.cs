using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Room
    {
        public int Room_ID { get; set; }

        public int RoomType_ID { get; set; }

        public int Image_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Room_Name { get; set; }

        public int? Room_Number { get; set; }

        [Required]
        public int Room_Floor { get; set; }

        [MaxLength(500)]
        public string? Room_Description { get; set; }

        public RoomType? RoomType { get; set; }
        public Image? Image { get; set; }
    }
}
