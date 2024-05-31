namespace SRW_Frontend_Server.DTOs
{
    public class UserRoomDTO
    {
        public int User_ID { get; set; }
        public int Room_ID { get; set; }

        public UserDTO? User { get; set; }
        public RoomDTO? Room { get; set; }
    }
}
