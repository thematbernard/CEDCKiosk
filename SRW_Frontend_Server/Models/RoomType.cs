using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class RoomType
    {
        public int RoomType_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoomType_Name { get; set; }
    }
}
