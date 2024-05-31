namespace SRW_Backend_API.Models
{
    public class UserRoom
    {
        public int User_ID { get; set; }
        public int Room_ID { get; set; }

        public User? User { get; set; }
        public Room? Room { get; set; }
    }
}
