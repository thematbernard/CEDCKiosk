namespace SRW_Backend_API.DTOs
{
    public class UserRoomDTO
    {
        public int User_ID { get; set; }
        public int Room_ID { get; set; }

        public UserDTO? User { get; set; }
        public RoomDTO? Room { get; set; }
    }
}
