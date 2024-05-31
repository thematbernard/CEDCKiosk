namespace SRW_Frontend_Server.DTOs
{
    public class ReservationDTO
    {
        public int Reservation_ID { get; set; }

        public int User_ID { get; set; }

        public int Room_ID { get; set; }

        public DateTime Reservation_Start_Date { get; set; }

        public DateTime Reservation_End_Date { get; set; }

        public bool Reservation_Notification { get; set; }

        public UserDTO? User { get; set; }
        public RoomDTO? Room { get; set; }
    }
}
