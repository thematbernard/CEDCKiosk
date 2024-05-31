using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Reservation
    {
        public int Reservation_ID { get; set; }

        public int User_ID { get; set; }

        public int Room_ID { get; set; }

        [Required]
        public DateTime Reservation_Start_Date { get; set; }

        [Required]
        public DateTime Reservation_End_Date { get; set; }

        [Required]
        public bool Reservation_Notification { get; set; }

        public User? User { get; set; }
        public Room? Room { get; set; }
    }
}
