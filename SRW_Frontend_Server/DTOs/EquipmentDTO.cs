namespace SRW_Frontend_Server.DTOs
{
    public class EquipmentDTO
    {
        public int Equipment_ID { get; set; }

        public int? Image_ID { get; set; }

        public int? Role_ID { get; set; }

        public string Equipment_Name { get; set; }

        public int Equipment_Quantity { get; set; }

        public int Equipment_Available { get; set; }

        public string Equipment_Description { get; set; }

        public ImageDTO? Image { get; set; }
        public RoleDTO? Role { get; set; }
    }
}
