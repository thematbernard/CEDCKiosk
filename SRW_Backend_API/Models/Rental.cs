using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Rental
    {
        public int Rental_ID { get; set; }

        public int User_ID { get; set; }

        public int Equipment_ID { get; set; }

        public DateTime? Rental_Start_Date { get; set; }

        public DateTime? Rental_End_Date { get; set; }

        [Required]
        public bool Rental_Approved { get; set; }

        [Required]
        public bool Rental_Returned { get; set; }

        public User? User { get; set; }
        public Equipment? Equipment { get; set; }
    }
}
