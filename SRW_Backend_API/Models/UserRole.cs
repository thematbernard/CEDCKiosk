namespace SRW_Backend_API.Models
{
    public class UserRole
    {
        public int User_ID { get; set; }
        public int Role_ID { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}