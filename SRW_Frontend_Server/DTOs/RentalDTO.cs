namespace SRW_Frontend_Server.DTOs
{
    public class RentalDTO
    {
        public int Rental_ID { get; set; }

        public int User_ID { get; set; }

        public int Equipment_ID { get; set; }

        public DateTime? Rental_Start_Date { get; set; }

        public DateTime? Rental_End_Date { get; set; }

        public bool Rental_Approved { get; set; }

        public bool Rental_Returned { get; set; }

        public UserDTO? User { get; set; }
        public EquipmentDTO? Equipment { get; set; }
    }
}
