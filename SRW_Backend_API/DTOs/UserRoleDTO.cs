namespace SRW_Backend_API.DTOs
{
    public class UserRoleDTO
    {
        public int User_ID { get; set; }
        public int Role_ID { get; set; }

        public UserDTO? User { get; set; }
        public RoleDTO? Role { get; set; }
    }
}